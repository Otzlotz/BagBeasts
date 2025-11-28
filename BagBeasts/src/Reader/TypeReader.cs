

namespace src.Reader;

/// <summary>
/// Klasse für Methoden mit Datenbankabfragen für die Tabelle Type (besitzt einen Cache!)
/// </summary>
public class TypeReader
{
    #region Properties

    /// <summary>
    /// Cached Namen der Types aus der Datenbank
    /// </summary>
    /// <remarks>Type = Typ, string = Name</remarks>
    private Dictionary<Type, string> TypeCache {get;} = new Dictionary<Type, string>();

    #endregion // Properties

    #region Public Methods

    /// <summary>
    /// Ermittelt den Namen des Typen aus der Datenbank
    /// </summary>
    /// <param name="type">Typ</param>
    /// <returns>Name aus der Datenbank</returns>
    public string GetName(Type type)
    {
        return TypeCache[type];
    }

    // TODO: Muss einmal im Programm gegen Anfang Ausgelöst werden!

    /// <summary>
    /// Ließt alle Datenbankeinträge in den Cache ein
    /// </summary>
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