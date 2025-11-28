
namespace src.Reader;

/// <summary>
/// Klasse für Methoden mit Datenbankabfragen für die Tabelle TypeMatchup (besitzt einen Cache!)
/// </summary>
public class TypeMatchupReader
{
    #region Properties

    /// <summary>
    /// Cached Multiplier aus der Datenbank
    /// </summary>
    /// <remarks>Type (1) = TypeIDAtk, Type (2) = TypeIdDef, decimal = Multiplier</remarks>
    private Dictionary<Tuple<Type, Type>, decimal> MultiplierCache {get;} = new Dictionary<Tuple<Type, Type>, decimal>();

    #endregion // Properties

    #region Public Methods

    /// <summary>
    /// Ermittelt den Type Damage Multiplier für einen Angriff
    /// </summary>
    /// <param name="attackType">Typ der Attacke</param>
    /// <param name="defenderType1">Typ 1 des angegriffenen BagBeast</param>
    /// <param name="defenderType2">Optional: Typ 2 des angegriffenen BagBeast</param>
    /// <returns>Type Damage Multiplier</returns>
    public decimal GetMultiplier(Type attackType, Type defenderType1, Type? defenderType2)
    {
        ReadMultiplierInCache(attackType, defenderType1);
        decimal multiplier1 = MultiplierCache[new Tuple<Type, Type>(attackType, defenderType1)];
        decimal multiplier2 = 1;

        if (defenderType2.HasValue)
        {
            ReadMultiplierInCache(attackType, defenderType2);
            multiplier2 = MultiplierCache[new Tuple<Type, Type>(attackType, defenderType2.Value)];
        }

        return multiplier1 * multiplier2;
    }

    /// <summary>
    /// Ließt alle Datenbankeinträge in den Cache ein
    /// </summary>
    public void ReadAllDataInCache()
    {
        // TODO: Datenbankabfrage und Cache leeren und neu Füllen
        return;
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// Ließt einen Eintrag in den Cache ein
    /// </summary>
    /// <param name="attackType">Typ der Attacke</param>
    /// <param name="defenderType">Typ des angegriffenen BagBeast</param>
    private void ReadMultiplierInCache(Type attackType, Type defenderType)
    {
        // Wenn der Multiplier bereits eingelesen wurde, dann muss dieser nicht nochmal eingelesen werden
        if (MoveCache.Contains(moveId))
        {
            return;
        }

        // TODO: Datenbankabfrage und Cache mit dem einen Eintrag Füllen
        return;
    }

    #endregion // Private Methods
}