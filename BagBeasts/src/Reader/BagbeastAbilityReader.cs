
namespace src.Reader;

public class BagBeastAbilityReader
{
    #region Properties

    // Cached Abilities der Bagbeasts aus der Datenbank
    // uint BagbeastId, List<uint> Abilities des Bagbeast
    private readonly Dictionary<uint, List<uint>> BagBeastAbilityCache {get;} = new Dictionary<uint, List<uint>>();

    #endregion // Properties

    #region Public Methods

    public List<uint> GetBagBeastAbilities(uint bagBeastId)
    {
        LeseBagBeastAbilities(bagBeastId);
        return BagBeastAbilityCache[bagBeastId];
    }

    #endregion // Public Methods

    #region Private Methods
    
    // Ließt einen Eintrag in den Cache ein
    private void LeseBagBeastAbilities(uint bagBeastId)
    {
        // Wenn die Ability bereits eingelesen wurden, dann müssen diese nicht nochmal eingelesen werden
        if (BagBeastAbilityCache.Contains(bagBeastId))
        {
            return;
        }

        // TODO: Datenbankabfrage und Cache mit dem einen Eintrag Füllen
        return;
    }

    #endregion // Private Methods
}