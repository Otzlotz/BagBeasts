using src.Beast;

namespace src.Reader;

/// <summary>
/// Klasse für Methoden mit Datenbankabfragen für die Tabelle Bagbeast (besitzt einen Cache!)
/// </summary>
public class BagbeastReader
{
    #region Properties

    /// <summary>
    /// Cached Bagbeasts aus der Datenbank
    /// </summary>
    /// <remarks>uint = ID, Bagbeast = Bagbeast</remarks>
    private Dictionary<uint, BagBeast> BagbeastCache {get;} = new Dictionary<uint, BagBeast>();

    #endregion // Properties

    #region Public Methods

    /// <summary>
    /// Ermittelt ein Bagbeast aus der Datenbank
    /// </summary>
    /// <param name="bagbeastId">Bagbeast-ID</param>
    /// <returns>Bagbeast aus der Datenbank</returns>
    public BagBeast GetBagbeast(uint bagbeastId)
    {
        ReadBagbeastInCache(bagbeastId);
        return BagbeastCache[bagbeastId];
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
    /// <param name="bagbeastId">Bagbeast-ID</param>
    private void ReadBagbeastInCache(uint bagbeastId)
    {
        // Wenn das Bagbeast bereits eingelesen wurde, dann muss dieses nicht nochmal eingelesen werden
        if (BagbeastCache.ContainsKey(bagbeastId))
        {
            return;
        }

        // TODO: Datenbankabfrage und Cache mit dem einen Eintrag Füllen
        return;
    }

    #endregion // Private Methods
}