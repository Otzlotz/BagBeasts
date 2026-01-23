using src.StatusEffect;
using System;
using src.Battle;
using src.Ability.AbilityBase;
using src.Item.ItemBase;

namespace src.Move.Base;

public abstract class MoveBase : ActionBase
{
    // TODO: Diese Moves ganz am Ende einbauen: Delegator, Schlafrede (vielleicht ganz weg lassen), Schwanzabwurf, Schutzschild, Abgangsbund, Ausdauer

    #region Fields

    private static Random _rnd;

    #endregion // Fields

    #region Properties

    #region Datenbank

    public string Description{get; protected set;}

    public uint Damage {get; protected set;} 

    // 0 - 100. Null trifft immer
    public uint? Accuracy {get; protected set;}

    // 1 - 4
    public uint CritChanceTier {get; protected set;}

    public uint PP {get; protected set;}

    public Type Type {get; protected set;}

    public Category Category {get; protected set;}

    public bool Contact {get; protected set;}

    #endregion // Datenbank

    #region Protected

    #region Services

    protected Random Rnd {get; set;} = _rnd ??= new Random();

    #endregion // Services

    /// <summary>
    /// Recoildamage in % (Bassierend auf den eigenen HP)
    /// </summary>
    protected decimal RecoilBasedOnOwnHp {get; set;} = 0;

    /// <summary>
    /// Recoildamage in % (Basierend auf verursachten Schaden)
    /// </summary>
    protected decimal RecoilBasedOnDmgDealt {get; set;} = 0;

    /// <summary>
    /// Verliert PP (nur verliert keine Struggle)
    /// </summary>
    protected bool LosePP {get; set;} = true;

    /// <summary>
    /// Chance in % den Gegner zurückzuschrecken
    /// </summary>
    protected decimal FlinchEnemyChance {get; set;} = 0;

    /// <summary>
    /// Lifesteal des zugefügten Schaden in %
    /// </summary>
    protected decimal LifeSteal {get; set;} = 0;

    #endregion // Protected

    #endregion // Properties

    #region Public Methods

    /// <summary>
    /// Ausführen eines Move
    /// </summary>
    /// <param name="executingBeast">Ausführendes Bagbeast</param>
    /// <param name="defendingBeast">Angegriffenes Bagbeast</param>
    /// <param name="moveExecuteMessage">OUT: Message der Ausführung des Move</param>
    /// <param name="switchInBeast">Optional: Babbeast, welches durch die Attacke (nach dem Angriff) eingewechselt wird</param>
    /// <returns>Result</returns>
    public virtual ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        // INFO: Dies ist die Standard Ausführung eines Attack Move

        moveExecuteMessage = $"{executingBeast.Name} has used {Name}.";

        if (LosePP)
        {
            PP--;
        }
        
        // Prüfen, ob der Angriff trifft
        if (!BattleCalculationService.MoveHit(executingBeast, defendingBeast, this, out string moveHitMessage))
        {
            moveExecuteMessage += "\n" + moveHitMessage;
            return new ExecuteResult(false);
        }

        ExecuteResult executeResult = new ExecuteResult(true);

        // Prüfen, ob ein Krit ausgelöst wird
        bool critTriggered = BattleCalculationService.CritTriggered(CritChanceTier, out string critMessage);

        if (critTriggered)
        {
            moveExecuteMessage += "\n" + critMessage;
        }

        // Schaden am Gegner zufügen
        int damage = BattleCalculationService.HitDamage(executingBeast, defendingBeast, this, critTriggered);
        ExcecuteHit(executingBeast, defendingBeast, this, damage, out string executeHitMessage);

        moveExecuteMessage += "\n" + executeHitMessage;

        // Lifesteal
        if (LifeSteal > 0)
        {
            executingBeast.CurrentHP += Convert.ToInt32(damage / 100 * LifeSteal);
        }

        // Recoil
        if (RecoilBasedOnOwnHp > 0)
        {
            executingBeast.CurrentHP =- Convert.ToInt32(executingBeast.MAXHP / 100 * RecoilBasedOnOwnHp);
            moveExecuteMessage += "\n" + $"{executingBeast.Name} was damaged by recoil!";

            if (executingBeast.CurrentHP == 0)
            {
                moveExecuteMessage += "\n" + StatusEffectService.SetEternalEep(executingBeast);
            }
        }

        if (RecoilBasedOnDmgDealt > 0)
        {
            executingBeast.CurrentHP =- Convert.ToInt32(damage / 100 * RecoilBasedOnDmgDealt);
            moveExecuteMessage += "\n" + $"{executingBeast.Name} was damaged by recoil!";

            if (executingBeast.CurrentHP == 0)
            {
                moveExecuteMessage += "\n" + StatusEffectService.SetEternalEep(executingBeast);
            }
        }

        // Flinch
        if (FlinchEnemyChance > 0 && Rnd.Next(1, 100) <= FlinchEnemyChance)
        {
            executeResult.FlinchEnemy = true;
        }

        return executeResult;
    }

    /// <summary>
    /// Initialisiert die Aktion mit ihren Daten aus der Datenbank
    /// </summary>
    /// <param name="fromDB">Datenbankobjekt</param>
    public override void Init(BagBeasts.Move fromDB)
    {
        base.Init(fromDB);

        Description = fromDB.Description;
        Damage = (uint)fromDB.Dmg.Value;
        Accuracy = (uint?)fromDB.Acc;
        CritChanceTier = (uint)fromDB.CritChanceTier.Value;
        PP = (uint)fromDB.Pp.Value;
        Type = (Type)fromDB.Type.Value;
        Category = (Category)fromDB.Category.Value;
        Contact = fromDB.Contact.Value;
    }

    #endregion // Public Methods

    #region Protected

    /// <summary>
    /// Führt den Hit mit dem damage aus
    /// </summary>
    /// <param name="executingBeast">Angreifendes Bagbeast</param>
    /// <param name="defendingBeast">Angegriffenes Bagbeast</param>
    /// <param name="move">Angewendeter Move</param>
    /// <param name="damage">Zuvor berechneter Schaden</param>
    /// <param name="executeHitMessage">OUT: Hit Message</param>
    protected void ExcecuteHit(BagBeastObject executingBeast, BagBeastObject defendingBeast, MoveBase move, int damage, out string executeHitMessage)
    {
        executeHitMessage = string.Empty;

        // Itemeffekt ggf. auslösen
        if (defendingBeast.HeldItem is DamageReductionItemBase item)
        {
            string itemEffectMessage = item.ItemEffect(ref defendingBeast, move, ref damage);

            if (itemEffectMessage != string.Empty)
            {
                executeHitMessage = itemEffectMessage;
            }
        }

        // Abilityeffekt ggf. auslösen
        if (defendingBeast.Ability is DamageReductionAbilityBase ability)
        {
            string abilityEffectMessage = ability.AbilityEffect(ref defendingBeast, move, ref damage);

            if (abilityEffectMessage != string.Empty)
            {
                if (executeHitMessage != string.Empty)
                {
                    executeHitMessage += "\n" + abilityEffectMessage;
                }
                else
                {
                    executeHitMessage = abilityEffectMessage;
                }
            }
        }

        // Damage zufügen
        defendingBeast.CurrentHP =- damage;

        if (executeHitMessage == string.Empty)
        {
            executeHitMessage = $"{defendingBeast.Name} was hit by {move.Name} for {damage} damage.";
        }
        else
        {
            executeHitMessage += "\n" + $"{defendingBeast.Name} was hit by {move.Name} for {damage} damage.";
        }

        // Prüfen, ob das BagBeast in EternalEep gefallen ist
        if (defendingBeast.CurrentHP == 0)
        {
             executeHitMessage += StatusEffectService.SetEternalEep(defendingBeast);
        }
    }

    #endregion // Protected
}