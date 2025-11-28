

namespace src.Reader;

/// <summary>
/// Klasse für Methoden mit Datenbankabfragen für die Tabelle Item (besitzt einen Cache!)
/// </summary>
public class ItemReader
{
    #region Properties

    /// <summary>
    /// Cached Namen der Items aus der Datenbank
    /// </summary>
    /// <remarks>Type = Typ, string (1) = Name, string (2) = Beschreibung</remarks>
    private Dictionary<uint, Tuple<string, string>> ItemCache {get;} = new Dictionary<uint, Tuple<string, string>>();

    #endregion // Properties

    #region Public Methods

    /// <summary>
    /// Ermittelt den Namen des Item aus der Datenbank
    /// </summary>
    /// <param name="itemId">Item-ID</param>
    /// <returns>Name aus der Datenbank</returns>
    public string GetName(uint itemId)
    {
        ReadItemInCache(itemId);
        return ItemCache[itemId].Item1;
    }

    /// <summary>
    /// Ermittelt die Beschreibung des Item aus der Datenbank
    /// </summary>
    /// <param name="itemId">Item-ID</param>
    /// <returns>Beschreibung aus der Datenbank</returns>
    public string GetDescription(uint itemId)
    {
        ReadItemInCache(itemId);
        return ItemCache[itemId].Item2;
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
    /// <param name="itemId">Item-ID</param>
    private void ReadItemInCache(uint itemId)
    {
        // Wenn das Item bereits eingelesen wurde, dann muss dieses nicht nochmal eingelesen werden
        if (ItemCache.ContainsKey(itemId))
        {
            return;
        }

        // TODO: Datenbankabfrage und Cache mit dem einen Eintrag Füllen
        return;
    }

    #endregion // Private Methods
}