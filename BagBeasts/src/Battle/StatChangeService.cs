

using src.Move.TMs;

namespace src.Battle;

/// <summary>
/// Methoden für State Changes
/// </summary>
public static class StatChangeService
{
    #region Nested Enums

    private enum StatType
    {
        ATK = 0,

        SPA = 1,

        DEF = 2,

        SPD = 3,

        INT = 4,

        ACC = 5,

        DODGE = 6,
    }

    #endregion // Nested Enums

    #region Public Methods

    /// <summary>
    /// Passt den ATK Stat von <paramref name="effectedBagBeast"/>
    /// </summary>
    /// <param name="effectedBagBeast">Bewirktes BagBeast</param>
    /// <param name="changeValue">Um wie viel der Wert verändert wird (+ und - geht beides)</param>
    /// <returns>Message des Statchange</returns>
    public static string ChangeAtk(BagBeastObject effectedBagBeast, int changeValue)
    {
        return ChangeStat(effectedBagBeast, changeValue, StatType.ATK);
    }

    /// <summary>
    /// Passt den SPA Stat von <paramref name="effectedBagBeast"/>
    /// </summary>
    /// <param name="effectedBagBeast">Bewirktes BagBeast</param>
    /// <param name="changeValue">Um wie viel der Wert verändert wird (+ und - geht beides)</param>
    /// <returns>Message des Statchange</returns>
    public static string ChangeSpa(BagBeastObject effectedBagBeast, int changeValue)
    {
        return ChangeStat(effectedBagBeast, changeValue, StatType.SPA);
    }

    /// <summary>
    /// Passt den DEF Stat von <paramref name="effectedBagBeast"/>
    /// </summary>
    /// <param name="effectedBagBeast">Bewirktes BagBeast</param>
    /// <param name="changeValue">Um wie viel der Wert verändert wird (+ und - geht beides)</param>
    /// <returns>Message des Statchange</returns>
    public static string ChangeDef(BagBeastObject effectedBagBeast, int changeValue)
    {
        return ChangeStat(effectedBagBeast, changeValue, StatType.DEF);
    }

    /// <summary>
    /// Passt den SPD Stat von <paramref name="effectedBagBeast"/>
    /// </summary>
    /// <param name="effectedBagBeast">Bewirktes BagBeast</param>
    /// <param name="changeValue">Um wie viel der Wert verändert wird (+ und - geht beides)</param>
    /// <returns>Message des Statchange</returns>
    public static string ChangeSpd(BagBeastObject effectedBagBeast, int changeValue)
    {
        return ChangeStat(effectedBagBeast, changeValue, StatType.SPD);
    }

    /// <summary>
    /// Passt den INT Stat von <paramref name="effectedBagBeast"/>
    /// </summary>
    /// <param name="effectedBagBeast">Bewirktes BagBeast</param>
    /// <param name="changeValue">Um wie viel der Wert verändert wird (+ und - geht beides)</param>
    /// <returns>Message des Statchange</returns>
    public static string ChangeInt(BagBeastObject effectedBagBeast, int changeValue)
    {
        return ChangeStat(effectedBagBeast, changeValue, StatType.INT);
    }

    /// <summary>
    /// Passt den ACC Stat von <paramref name="effectedBagBeast"/>
    /// </summary>
    /// <param name="effectedBagBeast">Bewirktes BagBeast</param>
    /// <param name="changeValue">Um wie viel der Wert verändert wird (+ und - geht beides)</param>
    /// <returns>Message des Statchange</returns>
    public static string ChangeAcc(BagBeastObject effectedBagBeast, int changeValue)
    {
        return ChangeStat(effectedBagBeast, changeValue, StatType.ACC);
    }

    /// <summary>
    /// Passt den DODGE Stat von <paramref name="effectedBagBeast"/>
    /// </summary>
    /// <param name="effectedBagBeast">Bewirktes BagBeast</param>
    /// <param name="changeValue">Um wie viel der Wert verändert wird (+ und - geht beides)</param>
    /// <returns>Message des Statchange</returns>
    public static string ChangeDodge(BagBeastObject effectedBagBeast, int changeValue)
    {
        return ChangeStat(effectedBagBeast, changeValue, StatType.DODGE);
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// Allgemeine Methode zum Anpassen eines Stat
    /// </summary>
    /// <param name="effectedBagBeast">Bewirktes BagBeast</param>
    /// <param name="changeValue">Um wie viel der Wert verändert wird (+ und - geht beides)</param>
    /// <param name="statType">Welcher Stat Angepasst werden soll</param>
    /// <returns>Message des Statchange</returns>
    private static string ChangeStat(BagBeastObject effectedBagBeast, int changeValue, StatType statType)
    {
        if (effectedBagBeast == null || changeValue == 0)
        {
            // Bei falschen Übergaben nichts machen
            return "Unable to change stats!";
        }

        int currentValue = GetCurrentStatValue(effectedBagBeast, statType);
        string statName = GetStatName(statType);

        if (changeValue > 0)
        {
            if (currentValue >= 6)
            {
                // Stat kann nicht weiter erhöht werden
                return $"{statName} could not be further raised!";
            }

            // Stat darf nicht auf über 6 erhöht werden!
            while (changeValue + currentValue > 6)
            {
                changeValue--;
            }
        }
        else
        {
            if (currentValue <= -6)
            {
                // Stat kann nicht weiter verringert werden
                return $"{statName} could not be further lowered!";
            }

            // Stat darf nicht auf unter -6 verringert werden!
            while (changeValue + currentValue < -6)
            {
                changeValue--;
            }
        }

        // Stat Erhöhen / Verringern
        return ChangeStatDirect(effectedBagBeast, changeValue, statType);
    }

    /// <summary>
    /// Ermittelt des Aktuellen StatChange von <paramref name="statType"/>
    /// </summary>
    /// <param name="effectedBagBeast">Bewirktes BagBeast</param>
    /// <param name="statType">Von welchem StatChange der Wert ermittelt werden soll</param>
    /// <returns>Aktueller StatChange von <paramref name="statType"/></returns>
    private static int GetCurrentStatValue(BagBeastObject effectedBagBeast, StatType statType)
    {
        switch (statType)
        {
            case StatType.ATK:
                return effectedBagBeast.StatChange.ATK;

            case StatType.SPA:
                return effectedBagBeast.StatChange.SPA;

            case StatType.DEF:
                return effectedBagBeast.StatChange.DEF;

            case StatType.SPD:
                return effectedBagBeast.StatChange.SPD;

            case StatType.INT:
                return effectedBagBeast.StatChange.INT;

            case StatType.ACC:
                return effectedBagBeast.StatChange.ACC;

            case StatType.DODGE:
                return effectedBagBeast.StatChange.DODGE;

            default:
                // Sollte nicht passieren, also 10 zurückgeben um angehalten zu werden, da der Wert über 6 ist
                return 10;
        }
    }

    /// <summary>
    /// Passt den Stat direkt ohne weitere Prüfungen an
    /// </summary>
    /// <param name="effectedBagBeast">Bewirktes BagBeast</param>
    /// <param name="changeValue">Um wie viel der Wert verändert wird (+ und - geht beides)</param>
    /// <param name="statType">Welcher Stat Angepasst werden soll</param>
    /// <returns>Message des Statchange</returns>
    private static string ChangeStatDirect(BagBeastObject effectedBagBeast, int changeValue, StatType statType)
    {
        string statName = {GetStatName(statType)};

        switch (statType)
        {
            case StatType.ATK:
                effectedBagBeast.StatChange.ATK += changeValue;

            case StatType.SPA:
                effectedBagBeast.StatChange.SPA += changeValue;

            case StatType.DEF:
                effectedBagBeast.StatChange.DEF += changeValue;

            case StatType.SPD:
                effectedBagBeast.StatChange.SPD += changeValue;

            case StatType.INT:
                effectedBagBeast.StatChange.INT += changeValue;

            case StatType.ACC:
                effectedBagBeast.StatChange.ACC += changeValue;

            case StatType.DODGE:
                effectedBagBeast.StatChange.DODGE += changeValue;
        }

        return changeValue > 0 
        ? $"{statName} of {effectedBagBeast.Name} was raised by {changeValue} stages!" 
        : $"{statName} od {effectedBagBeast.Name} was lowered by {changeValue * -1} stages!";
    }

    /// <summary>
    /// Ermittelt des Namen des Stat
    /// </summary>
    /// <param name="statType">Typ des Stat</param>
    /// <returns>Name des Stat</returns>
    private static string GetStatName(StatType statType)
    {
        switch (statType)
        {
            case StatType.ATK:
                return "Attack";

            case StatType.SPA:
                return "Special Attack";

            case StatType.DEF:
                return "Defense";

            case StatType.SPD:
                return "Special Defense";

            case StatType.INT:
                return "Initiative";

            case StatType.ACC:
                return "Accuracy";

            case StatType.DODGE:
                return "Evasiveness";

            default:
                return string.Empty;
        }
    }

    #endregion // Private Methods
}