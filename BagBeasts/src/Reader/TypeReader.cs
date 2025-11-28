

namespace src.Reader;

public class TypeReader
{
    #region Properties

    // Cached Namen der Types aus der Datenbank
    // Type = Typ, string = Name
    private readonly Dictionary<Type, string> TypeCache {get;} = new Dictionary<Type, string>();

    #endregion // Properties

    #region Public Methods

    public string GetName(Type type)
    {
        return TypeCache[type];
    }

    // TODO: Muss einmal im Programm gegen Anfang Ausgelöst werden!

    // Ließt alle Datenbankeinträge in den Cache ein
    public void AlleDatenEinlesen()
    {
        // Wenn die Types bereits eingelesen wurden, dann müssen diese nicht nochmal eingelesen werden
        if (TypeCache.Any())
        {
            return;
        }

        // TODO: Datenbankabfrage und Cache Füllen
        return;
    }

    #endregion // Public Methods
}