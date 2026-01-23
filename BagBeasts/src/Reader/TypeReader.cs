

namespace BagBeasts.src.Reader;

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
    private Dictionary<TypeDB, string> TypeCache {get;} = new Dictionary<TypeDB, string>();

    #endregion // Properties

    #region Public Methods

    /// <summary>
    /// Ermittelt den Namen des Typen aus der Datenbank
    /// </summary>
    /// <param name="type">Typ</param>
    /// <returns>Name aus der Datenbank</returns>
    public string GetName(TypeDB type)
    {
        ReadTypeInCache(type);
        return TypeCache[type];
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
    /// <param name="type">Type</param>
    private void ReadTypeInCache(TypeDB type)
    {
        // Wenn der Type bereits eingelesen wurde, dann muss dieser nicht nochmal eingelesen werden
        if (TypeCache.ContainsKey(type))
        {
            return;
        }

        // TODO: Datenbankabfrage und Cache mit dem einen Eintrag Füllen
        return;
    }

    #endregion // Private Methods
}