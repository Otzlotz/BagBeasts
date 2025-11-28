
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
        decimal multiplier1 = MultiplierCache[new Tuple<Type, Type>(attackType, defenderType1)];
        decimal multiplier2 = defenderType2 != null ? MultiplierCache[new Tuple<Type, Type>(attackType, defenderType2.Value)] : 1;

        return multiplier1 * multiplier2;
    }

    // TODO: Muss einmal im Programm gegen Anfang Ausgelöst werden!

    /// <summary>
    /// Ließt alle Datenbankeinträge in den Cache ein
    /// </summary>
    public void AlleDatenEinlesen()
    {
        // Wenn die Multiplier bereits eingelesen wurden, dann müssen diese nicht nochmal eingelesen werden
        if (MultiplierCache.Any())
        {
            return;
        }

        // TODO: Datenbankabfrage und Cache Füllen
        return;
    }

    #endregion // Public Methods
}