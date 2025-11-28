
namespace src.Reader;

/// <summary>
/// Klasse für Methoden mit Datenbankabfragen für die Tabelle BagBeastAbility (besitzt einen Cache!)
/// </summary>
public class BagBeastAbilityReader
{
    #region Properties

    /// <summary>
    /// Cached Abilities der Bagbeasts aus der Datenbank
    /// </summary>
    /// <remarks>uint = BagbeastId, List<uint> = Abilities des Bagbeast</remarks>
    private Dictionary<uint, List<uint>> BagBeastAbilityCache {get;} = new Dictionary<uint, List<uint>>();

    #endregion // Properties

    #region Public Methods

    /// <summary>
    /// Ermittelt die Abilities, welche ein Bagbeast besitzen kann
    /// </summary>
    /// <param name="bagBeastId">Bagbeast-ID</param>
    /// <returns>IDs der Abilities, welche ein Bagbeast besitzen kann</returns>
    public List<uint> GetBagBeastAbilities(uint bagBeastId)
    {
        ReadBagBeastAbilitiesInCache(bagBeastId);
        return BagBeastAbilityCache[bagBeastId];
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
    private void ReadBagBeastAbilitiesInCache(uint bagBeastId)
    {
        // Wenn die Abilities bereits eingelesen wurden, dann müssen diese nicht nochmal eingelesen werden
        if (BagBeastAbilityCache.ContainsKey(bagBeastId))
        {
            return;
        }

        // TODO: Datenbankabfrage und Cache mit dem einen Eintrag Füllen
        return;
    }

    #endregion // Private Methods
}