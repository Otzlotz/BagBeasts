
namespace src.Reader;

public class AbilityReader
{
    #region Properties

    // Cached Abilities aus der Datenbank
    // uint Id, string Name
    private readonly Dictionary<uint, string> AbilityCache {get;} = new Dictionary<uint, string>();

    #endregion // Properties

    #region Public Methods

    public string GetName(uint abilityId)
    {
        LeseAbility(abilityId);
        return AbilityCache[abilityId];
    }

    // Ließt alle Datenbankeinträge in den Cache ein
    public void AlleDatenEinlesen()
    {
        // Wenn die Abilities bereits eingelesen wurden, dann müssen diese nicht nochmal eingelesen werden
        if (AbilityCache.Any())
        {
            return;
        }

        // TODO: Datenbankabfrage und Cache Füllen
        return;
    }

    #endregion // Public Methods

    #region Private Methods

    // Ließt einen Eintrag in den Cache ein
    private void LeseAbility(uint abilityId)
    {
        // Wenn die Ability bereits eingelesen wurden, dann müssen diese nicht nochmal eingelesen werden
        if (AbilityCache.Contains(abilityId))
        {
            return;
        }

        // TODO: Datenbankabfrage und Cache mit dem einen Eintrag Füllen
        return;
    }

    #endregion // Private Methods
}