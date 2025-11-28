
namespace src.Reader;

/// <summary>
/// Klasse für Methoden mit Datenbankabfragen für die Tabelle BagBeastMove (besitzt einen Cache!)
/// </summary>
public class BagBeastMoveReader
{
    #region Properties

    /// <summary>
    /// Cached Moves der Bagbeasts aus der Datenbank
    /// </summary>
    /// <remarks>uint = BagbeastId, List<uint> = Moves des Bagbeast</remarks>
    private Dictionary<uint, List<uint>> BagBeastMoveCache {get;} = new Dictionary<uint, List<uint>>();

    #endregion // Properties

    #region Public Methods

    /// <summary>
    /// Ermittelt die Moves, welche ein Bagbeast besitzen kann
    /// </summary>
    /// <param name="bagBeastId">Bagbeast-ID</param>
    /// <returns>IDs der Moves, welche ein Bagbeast besitzen kann</returns>
    public List<uint> GetBagBeastMoves(uint bagBeastId)
    {
        ReadBagBeastMovesInCache(bagBeastId);
        return BagBeastMoveCache[bagBeastId];
    }

    // TODO: Vielleicht noch direkt eine Methode, welche nicht nur die IDs sondern auch die Namen ließt

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
    /// <param name="bagBeastId">Bagbeast-ID</param>
    private void ReadBagBeastMovesInCache(uint bagBeastId)
    {
        // Wenn die Moves bereits eingelesen wurden, dann müssen diese nicht nochmal eingelesen werden
        if (BagBeastMoveCache.ContainsKey(bagBeastId))
        {
            return;
        }

        // TODO: Datenbankabfrage und Cache mit dem einen Eintrag Füllen
        return;
    }

    #endregion // Private Methods
}