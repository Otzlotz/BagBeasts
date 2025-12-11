



// TODO: Namespace muss vermutlich noch angepasst werden

using src.Move.Base;

namespace src.Battle;

/// <summary>
/// Service zum Berechnen des Schaden
/// </summary>
public class DamageCalculationService
{
    
    
    #region Public Methods

    public decimal HitDamage(BagBeastObject attacker, BagBeastObject defender, MoveBase attackMove, bool critTriggered)
    {
        var f1;
        var f2;
        var f3;
        decimal crit = critTriggered ? 1.5 : 1;
        ushort z = GetZ();
        var stab;
        var typ1;
        var typ2;


        return (42 * attackMove.Damage * GetAttackStat(attacker, attackMove) / (50 * GetDefendstat(defender, attackMove, critTriggered)) * f1 + 2) * crit * f2 * (z / 100) * stab * typ1 * typ2 * f3;
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

        // TODO: Stat Changes beachten

        return attackMove.Category == Category.Physical ? attacker.ATK : attacker.SPA;
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

        // TODO: Krit einbauen und Stat Changes beachten

        return attackMove.Category == Category.Physical ? defender.DEF : defender.SPD;
    }

    /// <summary>
    /// Berechnet Z für die Schadenskalkulation
    /// </summary>
    /// <returns>Z (zwischen 85 - 100)</returns>
    private ushort GetZ()
    {
        
    }

    #endregion // Private Methods
}