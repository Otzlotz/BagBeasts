
namespace src.Reader;

public class AbilityReader
{
    #region Properties

    // Cached Multiplier aus der Datenbank
    // uint Id, string Name
    private readonly Dictionary<uint, string> AbilityCache {get;} = new Dictionary<uint, string>();

    #endregion // Properties

    #region Public Methods

    public decimal GetName(uint abilityId)
    {
        If (AbilityCache.Any())
        {
            return;
        }
    }

    // TODO: Muss einmal im Programm gegen Anfang Ausgelöst werden!

    // Muss einmal im Programm gegen Anfang Ausgelöst werden!
    public void LeseAbility(uint abilityId)
    {
        // Wenn die Multiplier bereits eingelesen wurden, dann müssen diese nicht nochmal eingelesen werden
        If (AbilityCache.Any())
        {
            return;
        }

        // TODO: Datenbankabfrage und Cache Füllen
    }

    #endregion // Public Methods
}