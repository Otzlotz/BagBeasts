
namespace src.Reader;

public class TypeMatchupReader
{
    #region Properties

    // Cached Multiplier aus der Datenbank
    // Type (1) = TypeIDAtk, Type (2) = TypeIdDef, decimal = Multiplier
    private readonly Dictionary<Tuple<Type, Type>, decimal> MultiplierCache {get;} = new Dictionary<Tuple<uint, uint>, decimal>();

    #endregion // Properties

    #region Public Methods

    public decimal GetMultiplier(Type attackType, Type defenderType1, Type? defenderType2)
    {
        decimal multiplier1 = MultiplierCache[new Tuple<Type, Type>(attackType, defenderType1)];
        decimal multiplier2 = defenderType2 != null ? MultiplierCache[new Tuple<Type, Type>(attackType, defenderType2)] : 1;

        return multiplier1 * multiplier2;
    }

    // TODO: Muss einmal im Programm gegen Anfang Ausgelöst werden!

    // Ließt alle Datenbankeinträge in den Cache ein
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