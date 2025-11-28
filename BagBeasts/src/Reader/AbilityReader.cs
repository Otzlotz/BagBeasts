
namespace src.Reader;

/// <summary>
/// Klasse für Methoden mit Datenbankabfragen für die Tabelle Ability (besitzt einen Cache!)
/// </summary>
public class AbilityReader
{
    #region Properties

    /// <summary>
    /// Cached Abilities aus der Datenbank
    /// </summary>
    /// <remarks>uint = ID, string = Name</remarks>
    private Dictionary<uint, string> AbilityCache {get;} = new Dictionary<uint, string>();

    #endregion // Properties

    #region Public Methods

    /// <summary>
    /// Ermittelt den Namen der Ability aus der Datenbank
    /// </summary>
    /// <param name="abilityId">Ability-ID</param>
    /// <returns>Name aus der Datenbank</returns>
    public string GetName(uint abilityId)
    {
        ReadAbilityInCache(abilityId);
        return AbilityCache[abilityId];
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
    /// <param name="abilityId">Ability-ID</param>
    private void ReadAbilityInCache(uint abilityId)
    {
        // Wenn die Ability bereits eingelesen wurden, dann muss diese nicht nochmal eingelesen werden
        if (AbilityCache.Contains(abilityId))
        {
            return;
        }

        // TODO: Datenbankabfrage und Cache mit dem einen Eintrag Füllen
        return;
    }

    #endregion // Private Methods
}