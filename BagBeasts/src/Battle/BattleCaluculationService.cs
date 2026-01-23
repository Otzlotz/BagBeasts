

using System;
using BagBeasts.src.Ability.AbilityBase;
using BagBeasts.src.Item.ItemBase;
using BagBeasts.src.Move.Base;
using BagBeasts.src.Reader;
using BagBeasts.src.StatusEffect;
using BagBeasts.src.Move.TMs;

namespace BagBeasts.src.Battle;

/// <summary>
/// Service zum Berechnen des Schaden
/// </summary>
public static class BattleCalculationService
{
    #region Fields

    private static Random _rnd;

    #endregion // Fields

    #region Properties

    private static Random Rnd {get; set;} = _rnd ??= new Random();

    #endregion // Properties

    #region Public Methods

    /// <summary>
    /// Berechnet den Schaden von einem HIT
    /// </summary>
    /// <param name="attacker">Angreifendes Bagbeast</param>
    /// <param name="defender">Angegriffenes Bagbeast</param>
    /// <param name="attackMove">Attacke</param>
    /// <param name="critTriggered">Ob ein Volltreffer ausgelöst wurde</param>
    /// <returns>Berechneter Schaden</returns>
    public static int HitDamage(BagBeastObject attacker, BagBeastObject defender, MoveBase attackMove, bool critTriggered)
    {
        decimal f1 = GetF1(attacker, attackMove);
        decimal crit = critTriggered ? 1.5m : 1m;
        ushort z = GetZ();
        decimal stab = GetStab(attacker, attackMove);
        decimal typeMult = GetMultiplier(attackMove.Type, defender.Type1, defender.Type2);
        decimal attackStat = GetAttackStat(attacker, attackMove);
        decimal defendStat = GetDefendstat(defender, attackMove, critTriggered);

        decimal damage = (42 * attackMove.Damage * (attackStat  / (50 * defendStat)) * f1 + 2) * crit * (z / 100) * stab * typeMult;

        // Itemeffekt ggf. auslösen
        if (attacker.HeldItem is DamageModifierItemBase item)
        {
            damage = item.ItemEffect(ref attacker, defender, attackMove, damage);
        }

        // Abilityeffekt ggf. auslösen
        if (attacker.Ability is DamageModifierAbilityBase ability)
        {
            damage = ability.AbilityEffect(attacker, defender, attackMove, damage);
        }

        // Wenn Damage zugefügt wird, dann wird dieser, auf mindestens 1, abgerundet
        if (damage > 0)
        {
            return (int)damage != 0 ? (int)damage : 1;
        }

        return 0;
    }

    /// <summary>
    /// Berechnet, ob ein Krit ausgelöst wird
    /// </summary>
    /// <param name="critChanceTier">Tier des Move bezüglich Krit Chance</param>
    /// <param name="critMessage">OUT: Message, wenn ein Krit ausgelöst wurde (String.Empty, wenn es nicht ausgelöst wurde)</param>
    /// <returns>Ob ein Krit ausgelöst wird</returns>
    public static bool CritTriggered(uint critChanceTier, out string critMessage)
    {
        bool critTriggerd;
        switch (critChanceTier)
        {
            case 1:
                // 4,16%
                critTriggerd = Rnd.Next(1, 10000) <= 416;
                break;

            case 2:
                // 12,5%
                critTriggerd = Rnd.Next(1, 10000) <= 1250;
                break;

            case 3:
                // 50%
                critTriggerd = Rnd.Next(1, 10000) <= 5000;
                break;

            case 4:
                // 100%
                critTriggerd = true;
                break;

            default:
                critTriggerd = false;
                break;
        }

        // Message setzen, wenn ein Krit ausgelöst wurde
        critMessage = critTriggerd ? "A critical hit!" : string.Empty;
        return critTriggerd;
    }

    /// <summary>
    /// Berechnet, ob der Angriff trifft
    /// </summary>
    /// <param name="attacker">Angreifendes Bagbeast</param>
    /// <param name="defender">Angegriffenes Bagbeast</param>
    /// <param name="attackMove">Attacke</param>
    /// <param name="moveHitMessage">OUT: Message, wenn der Angriff daneben geht (string.Empty, wenn der Angriff trifft)</param>
    /// <returns>Ob der Angriff trifft</returns>
    public static bool MoveHit(BagBeastObject attacker, BagBeastObject defender, MoveBase attackMove, out string moveHitMessage)
    {
        if (defender.StatusEffect == StatusEffectEnum.EternalEep)
        {
            moveHitMessage = $"{attackMove.Name} failed!";
            return false;
        }

        decimal? accuracy = attackMove.Accuracy;

        // Wenn der Type Multiplier 0 ist, dann ist der Defender Immun gegen Attacken dieses Typen
        if (GetMultiplier(attackMove.Type, defender.Type1, defender.Type2) == 0)
        {
            moveHitMessage = $"{attackMove.Name} has no effect on {attacker.Name}!";
            return false;
        }

        // Itemeffekt ggf. auslösen
        if (attacker.HeldItem is AccuracyModifyingItemBase item1)
        {
            accuracy = item1.ItemEffect(attacker, defender, attackMove, true, accuracy);
        }

        if (defender.HeldItem is AccuracyModifyingItemBase item2)
        {
            accuracy = item2.ItemEffect(defender, attacker, attackMove, false, accuracy);
        }

        // Abilityeffekt ggf. auslösen
        if (attacker.Ability is AccuracyModifyingAbilityBase ability1)
        {
            accuracy = ability1.AbilityEffect(attacker, defender, attackMove, true, accuracy);
        }

        if (defender.Ability is AccuracyModifyingAbilityBase ability2)
        {
            accuracy = ability2.AbilityEffect(defender, attacker, attackMove, false, accuracy);
        }

        // Accuracy null trifft immer
        if (!accuracy.HasValue)
        {
            moveHitMessage = string.Empty;
            return true;
        }

        // Hitchance ermitteln
        decimal hitChance = accuracy.Value * GetAccuracyStatModifier(attacker) * GetDodgeStatModifier(defender);

        // Hitchance >= 100 trifft immer
        if (hitChance >= 100)
        {
            moveHitMessage = string.Empty;
            return true;
        }

        // Random ermitteln, ob der Move trifft
        if (Rnd.Next(1, 100) <= hitChance)
        {
            moveHitMessage = $"{defender.Name} avoided {attackMove.Name} from {attacker.Name}.";
            return false;
        }

        moveHitMessage = string.Empty;
        return true;
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// Ermittelt den passenden Attackstat
    /// </summary>
    /// <param name="attacker">Angreifendes Bagbeast</param>
    /// <param name="attackMove">Attacke</param>
    /// <returns>Passender Attackstat</returns>
    private static decimal GetAttackStat(BagBeastObject attacker, MoveBase attackMove)
    {
        int x = 2;
        int y = 2;
        int attackValue = attackMove.Category == Category.Physical ? attacker.ATK : attacker.SPA;
        int statChange = attackMove.Category == Category.Physical ? attacker.StatChange.ATK : attacker.StatChange.SPA;

        if (statChange < 0)
        {
            // Attack wird verringert
            y += statChange * -1;
        }
        else
        {
            // Attack wird erhöht (Bei StatChange = 0 bleibt es unverändert!)
            x += statChange;
        }

        return attackValue * (x / y);
    }

    /// <summary>
    /// Ermittelt den passenden Defensestat
    /// </summary>
    /// <param name="defender">Angegriffenes Bagbeast</param>
    /// <param name="attackMove">Attacke</param>
    /// <param name="critTriggered">Ob ein Volltreffer ausgelöst wurde</param>
    /// <returns>Passender Defensestat</returns>
    private static decimal GetDefendstat(BagBeastObject defender, MoveBase attackMove, bool critTriggered)
    {
        int x = 2;
        int y = 2;
        int defendValue = attackMove.Category == Category.Physical ? defender.DEF : defender.SPD;
        int statChange = attackMove.Category == Category.Physical ? defender.StatChange.DEF : defender.StatChange.SPD;

        if (statChange < 0)
        {
            // Defense wird verringert (unabhängig davon ob ein Krit ausgelöst wurde)
            y += statChange * -1;
        }
        else if (!critTriggered)
        {
            // Defense wird erhöht, sofern kein Krit ausgelöst wurde (Bei StatChange = 0 bleibt es unverändert!)
            x += statChange;
        }

        return defendValue * (x / y);
    }

    /// <summary>
    /// Berechnet Z für die Schadenskalkulation
    /// </summary>
    /// <returns>Z (zwischen 85 - 100)</returns>
    private static ushort GetZ()
    {
        return (ushort)Rnd.Next(85, 100);
    }

    /// <summary>
    /// Ermittelt den STAB (STAB = Same Type Attack Bonus) für die Schadenskalkulation
    /// </summary>
    /// <param name="attacker">Angreifendes Bagbeast</param>
    /// <param name="attackMove">Attacke</param>
    /// <returns>STAB (STAB = Same Type Attack Bonus)</returns>
    private static decimal GetStab(BagBeastObject attacker, MoveBase attackMove)
    {
        if (attacker.Type1 == attackMove.Type
        || (attacker.Type2.HasValue && attacker.Type2 == attackMove.Type))
        {
            return 1.5m;
        }

        return 1;
    }

    private static decimal GetF1(BagBeastObject attacker, MoveBase attackMove)
    {
        // Manche Abilities oder Moves ignorieren die DMG Reduction bei Burn (und hier auch Frostburn)
        if (attacker.Ability is Guts || attackMove is Facade)
        {
            return 1;
        }

        // BRT
        if ((attacker.StatusEffect == StatusEffectEnum.Burn && attackMove.Category == Category.Physical)
         || (attacker.StatusEffect == StatusEffectEnum.FrostBurn && attackMove.Category == Category.Special))
        {
            return 0.5m;
        }
        else
        {
            return 1;
        }
    }

    /// <summary>
    /// Ermittelt den Stat Modifier für den Accuracy Stat
    /// </summary>
    /// <param name="attacker">Angreifendes Bagbeast</param>
    /// <returns>Stat Modifier für den Accuracy Stat</returns>
    private static decimal GetAccuracyStatModifier(BagBeastObject attacker)
    {
        int x = 3;
        int y = 3;

        if (attacker.StatChange.ACC < 0)
        {
            // Accuracy wird verringert
            y += attacker.StatChange.ACC * -1;
        }
        else
        {
            // Accuracy wird erhöht (Bei StatChange = 0 bleibt es unverändert!)
            x += attacker.StatChange.ACC;
        }

        return x / y;
    }

    /// <summary>
    /// Ermittelt den Stat Modifier für den Dodge Stat
    /// </summary>
    /// <param name="defender">Angegriffenes Bagbeast</param>
    /// <returns>Stat Modifier für den Dodge Stat</returns>
    private static decimal GetDodgeStatModifier(BagBeastObject defender)
    {
        int x = 3;
        int y = 3;

        if (defender.StatChange.DODGE < 0)
        {
            // Dodge wird erhöht
            x += defender.StatChange.DODGE * -1;
        }
        else
        {
            // Dodge wird verringert (Bei StatChange = 0 bleibt es unverändert!)
            y += defender.StatChange.DODGE;
        }

        return x / y;
    }

    /// <summary>
    /// Ermittelt den Type Damage Multiplier für einen Angriff
    /// </summary>
    /// <param name="attackType">Typ der Attacke</param>
    /// <param name="defenderType1">Typ 1 des angegriffenen BagBeast</param>
    /// <param name="defenderType2">Optional: Typ 2 des angegriffenen BagBeast</param>
    /// <returns>Type Damage Multiplier</returns>
    private static decimal GetMultiplier(Type attackType, Type defenderType1, Type? defenderType2)
    {
        // TODO: Nur TEmporäre Methode! Muss stattdessen aus der Datenbank gelesen werden!
        return 1;
    }

    #endregion // Private Methods
}