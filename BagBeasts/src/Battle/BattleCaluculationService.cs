



// TODO: Namespace muss vermutlich noch angepasst werden

using System;
using src.Ability.AbilityBase;
using src.Item.ItemBase;
using src.Move.Base;
using src.Reader;
using src.StatusEffect;

namespace src.Battle;

/// <summary>
/// Service zum Berechnen des Schaden
/// </summary>
public class BattleCalculationService
{
    #region Public Methods

    /// <summary>
    /// Berechnet den Schaden von einem HIT
    /// </summary>
    /// <param name="attacker">Angreifendes Bagbeast</param>
    /// <param name="defender">Angegriffenes Bagbeast</param>
    /// <param name="attackMove">Attacke</param>
    /// <param name="critTriggered">Ob ein Volltreffer ausgelöst wurde</param>
    /// <returns>Berechneter Schaden</returns>
    public int HitDamage(BagBeastObject attacker, BagBeastObject defender, MoveBase attackMove, bool critTriggered)
    {
        // TODO: Reader muss irgendwie als Singleton oder so erstellt werden!
        TypeMatchupReader typeMatchupReader = new TypeMatchupReader();

        decimal f1 = GetF1(attacker, attackMove, critTriggered);
        decimal crit = critTriggered ? 1.5 : 1;
        ushort z = GetZ();
        decimal stab = GetStab(attacker, attackMove);
        decimal typeMult = typeMatchupReader.GetMultiplier(attackMove.Type, defender.Type1, defender.Type2);
        decimal attackStat = GetAttackStat(attacker, attackMove);
        decimal defendStat = GetDefendstat(defender, attackMove, critTriggered);

        decimal damage = (42 * attackMove.Damage * (attackStat  / (50 * defendStat)) * f1 + 2) * crit * (z / 100) * stab * typeMult;

        // Itemeffekt ggf. auslösen
        if (attacker.HeldItem is DamageModifierItemBase item)
        {
            damage = item.ItemEffect(attacker, defender, attackMove, damage);
        }

        // Abilityeffekt ggf. auslösen
        if (attacker.Ability is DamageModifierAbilityBase ability)
        {
            damage = item.ItemEffect(attacker, defender, attackMove, damage);
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
    /// <returns>Ob ein Krit ausgelöst wird</returns>
    public bool CritTriggered(uint critChanceTier)
    {
        // TODO: Chancen einbauen

        switch (critChanceTier)
        {
            case 1:
            // 4,16%
            break;

            case 2:
            // 12,5%
            break;

            case 3:
            // 50%
            break;

            case 4:
            // 100%
            return true;
        }

        // Sollte nicht passieren, aber lieber false als eine Exception
        return false;
    }

    /// <summary>
    /// Berechnet, ob der Angriff
    /// </summary>
    /// <param name="attacker">Angreifendes Bagbeast</param>
    /// <param name="defender">Angegriffenes Bagbeast</param>
    /// <param name="attackMove">Attacke</param>
    /// <returns>Ob der Angriff trifft</returns>
    public bool MoveHit(BagBeastObject attacker, BagBeastObject defender, MoveBase attackMove)
    {
        // TODO: Reader muss irgendwie als Singleton oder so erstellt werden!
        TypeMatchupReader typeMatchupReader = new TypeMatchupReader();

        uint? accuracy = attackMove.Accuracy;

        // Wenn der Type Multiplier 0 ist, dann ist der Defender Immun gegen Attacken dieses Typen
        if (typeMatchupReader.GetMultiplier(attackMove.Type, defender.Type1, defender.Type2) == 0)
        {
            return false;
        }

        // Itemeffekt ggf. auslösen
        if (attacker.HeldItem is AccuracyModifyingItemBase item)
        {
            accuracy = item.ItemEffect(attacker, defender, attackMove, true, accuracy);
        }

        if (defender.HeldItem is AccuracyModifyingItemBase item)
        {
            accuracy = item.ItemEffect(attacker, defender, attackMove, false, accuracy);
        }

        // Abilityeffekt ggf. auslösen
        if (attacker.Ability is AccuracyModifyingAbilityBase ability)
        {
            accuracy = item.ItemEffect(attacker, defender, attackMove, true, accuracy);
        }

        if (defender.Ability is AccuracyModifyingAbilityBase ability)
        {
            accuracy = item.ItemEffect(attacker, defender, attackMove, false, accuracy);
        }

        // Accuracy null trifft immer
        if (!accuracy.HasValue)
        {
            return true;
        }

        // Hitchance ermitteln
        decimal hitChance = accuracy.Value * (GetAccuracyStatModifier(attacker) * GetDodgeStatModifier(defender));

        // Hitchance >= 100 trifft immer
        if (hitChance >= 100)
        {
            return true;
        }

        // Random ermitteln, ob der Move trifft
        Random rnd = new Random();
        if (rnd.Next(1, 100) > hitChance)
        {
            return false;
        }

        return true;
    }

    // TODO: Überlegen ob Statuseffekt Damage auch hier rein kommt

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// Ermittelt den passenden Attackstat
    /// </summary>
    /// <param name="attacker">Angreifendes Bagbeast</param>
    /// <param name="attackMove">Attacke</param>
    /// <returns>Passender Attackstat</returns>
    private decimal GetAttackStat(BagBeastObject attacker, MoveBase attackMove)
    {
        // TODO: Wenn Bodypress implementiert wird muss hier vielleicht Sonderbullshit rein

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

        return defendValue * (x / y);
    }

    /// <summary>
    /// Ermittelt den passenden Defensestat
    /// </summary>
    /// <param name="defender">Angegriffenes Bagbeast</param>
    /// <param name="attackMove">Attacke</param>
    /// <param name="critTriggered">Ob ein Volltreffer ausgelöst wurde</param>
    /// <returns>Passender Defensestat</returns>
    private decimal GetDefendstat(BagBeastObject defender, MoveBase attackMove, bool critTriggered)
    {
        // TODO: Wenn Psyshock implementiert wird muss hier vielleicht Sonderbullshit rein

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
    private ushort GetZ()
    {
        // TODO: Random Wert zwischen 85 - 100 berechnen und zurückgeben
        return 100;
    }

    /// <summary>
    /// Ermittelt den STAB (STAB = Same Type Attack Bonus) für die Schadenskalkulation
    /// </summary>
    /// <param name="attacker">Angreifendes Bagbeast</param>
    /// <param name="attackMove">Attacke</param>
    /// <returns>STAB (STAB = Same Type Attack Bonus)</returns>
    private decimal GetStab(BagBeastObject attacker, MoveBase attackMove)
    {
        if (attacker.Type1 == attackMove.Type
        || (attacker.Type2.HasValue && attacker.Type2 == attackMove.Type))
        {
            return 1.5;
        }

        return 1;
    }

    private decimal GetF1(BagBeastObject attacker, MoveBase attackMove)
    {
        // TODO: Noch ist geplannt, dass Reflektor und Lichtschild nicht rein kommt. Wenn doch dann war hier vorher die Damage Calculation davon drin

        // TODO: Weiß nicht wieso der StatusEffect.StatusEffect will, obwohl der namespace drin ist. Kann später von Robin gefixt werden
        
        // TODO: ggf. Ability Adrenalin beachten
        // BRT
        if ((attacker.StatusEffect == StatusEffect.StatusEffect.Burn && attackMove.Category == Category.Physical)
         || (attacker.StatusEffect == StatusEffect.StatusEffect.FrostBurn && attackMove.Category == Category.Special))
        {
            return 0.5;
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
    private decimal GetAccuracyStatModifier(BagBeastObject attacker)
    {
        int x = 3;
        int y = 3;

        if (attacker.StatChange.ACC < 0)
        {
            // Accuracy wird verringert
            y += statChange * -1;
        }
        else
        {
            // Accuracy wird erhöht (Bei StatChange = 0 bleibt es unverändert!)
            x += statChange;
        }

        return x / y;
    }

    /// <summary>
    /// Ermittelt den Stat Modifier für den Dodge Stat
    /// </summary>
    /// <param name="defender">Angegriffenes Bagbeast</param>
    /// <returns>Stat Modifier für den Dodge Stat</returns>
    private decimal GetDodgeStatModifier(BagBeastObject defender)
    {
        int x = 3;
        int y = 3;

        if (statChange < 0)
        {
            // Dodge wird erhöht
            x += statChange * -1;
        }
        else
        {
            // Dodge wird verringert (Bei StatChange = 0 bleibt es unverändert!)
            y += statChange;
        }

        return x / y;
    }

    #endregion // Private Methods
}