using src.StatusEffect;
using System;
using src.Battle;

namespace src.Move.Base;

public abstract class MoveBase : ActionBase
{
    // TODO: Diese Moves ganz am Ende einbauen: Delegator, Schlafrede (vielleicht ganz weg lassen), Schwanzabwurf, Schutzschild, Abgangsbund
    // TODO: Zuletzt Bürde Implementiert (Moves 50 - 59 fehlen)

    #region Fields

    private Random _rnd;

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
            // TODO: Der Lifesteal hier muss vermutlich gerundet werden
            executingBeast.CurrentHP += damage / 100 * LifeSteal;
        }

        // Recoil
        if (RecoilBasedOnOwnHp > 0)
        {
            // TODO: Runden?
            executingBeast.CurrentHP =- executingBeast.MAXHP / 100 * RecoilBasedOnOwnHp;
            moveExecuteMessage += "\n" + $"{executingBeast.Name} was damaged by recoil!";

            if (executingBeast.CurrentHP == 0)
            {
                moveExecuteMessage += "\n" + StatusEffectService.SetEternalEep(executingBeast);
            }
        }

        if (RecoilBasedOnDmgDealt > 0)
        {
            // TODO: Runden?
            executingBeast.CurrentHP =- damage / 100 * Recoil;
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
        defendingBeast.CurrentHP =- damage;

        // TODO: Diese neue Itembase von Tobias für FocusSash hier einbauen. defendingBeast.CurrentHP darf nicht davor auf 0 gesetzt werden!

        if (executeHitMessage == string.Empty)
        {
            executeHitMessage = $"{defendingBeast.Name} was hit by {move.Name} for {damage} damage.";
        }
        else
        {
            executeHitMessage = "\n" + $"{defendingBeast.Name} was hit by {move.Name} for {damage} damage.";
        }

        if (defendingBeast.CurrentHP == 0)
        {
             executeHitMessage += StatusEffectService.SetEternalEep(defendingBeast);
        }
    }

    #endregion // Protected
}