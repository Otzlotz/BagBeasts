
namespace src.Reader;

/// <summary>
/// Klasse für Methoden mit Datenbankabfragen für die Tabelle Move (besitzt einen Cache!)
/// </summary>
public class MoveReader
{
    #region Properties

    /// <summary>
    /// Cached Moves aus der Datenbank
    /// </summary>
    /// <remarks>uint = ID, string (1) = Name, string (2) = Beschreibung</remarks>
    private Dictionary<uint, Tuple<string, string>> MoveCache {get;} = new Dictionary<uint, Tuple<string, string>>();

    #endregion // Properties

    #region Public Methods

    /// <summary>
    /// Ermittelt den Namen des Move aus der Datenbank
    /// </summary>
    /// <param name="moveId">Move-ID</param>
    /// <returns>Name aus der Datenbank</returns>
    public string GetName(uint moveId)
    {
        LeseAbility(moveId);
        return MoveCache[moveId].item1;
    }

    /// <summary>
    /// Ermittelt die Beschreibung des Move aus der Datenbank
    /// </summary>
    /// <param name="moveId">Move-ID</param>
    /// <returns>Beschreibung aus der Datenbank</returns>
    public string GetDescription(uint moveId)
    {
        LeseAbility(moveId);
        return MoveCache[moveId].item2;
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// Ließt einen Eintrag in den Cache ein
    /// </summary>
    /// <param name="moveId">Move-ID</param>
    private void LeseMove(uint moveId)
    {
        // Wenn der Move bereits eingelesen wurden, dann müssen diese nicht nochmal eingelesen werden
        if (MoveCache.Contains(moveId))
        {
            return;
        }

        // TODO: Datenbankabfrage und Cache mit dem einen Eintrag Füllen
        return;
    }

    #endregion // Private Methods
}