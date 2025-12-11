



// TODO: Namespace muss vermutlich noch angepasst werden

using src.Move.Base;
using src.Reader;
using src.StatusEffect;

namespace src.Battle;

/// <summary>
/// Service zum Berechnen des Schaden
/// </summary>
public class DamageCalculationService
{
    
    
    #region Public Methods

    public decimal HitDamage(BagBeastObject attacker, BagBeastObject defender, MoveBase attackMove, bool critTriggered)
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

        // TODO: Muss das Endergebnis, oder sogar die zwischenergebnisse, gerundet werden?

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

        return damage;
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

    #endregion // Private Methods
}