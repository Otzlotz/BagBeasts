

namespace src.StatusEffect;

/// <summary>
/// Die Primären Statuseffekte (es kann nur einen geben...)
/// </summary>
public enum StatusEffectEnum
{
    /// <summary>
    /// Kein Primärer Statuseffekt
    /// </summary>
    No = 0,

    /// <summary>
    /// Unmächtig
    /// </summary>
    EternalEep = 1,

    /// <summary>
    /// Schlaf.
    /// Random 1 - 3 Runden nicht angreifen (Dauer wird durch Switchen nicht resettet!)
    /// </summary>
    Eep = 2,

    /// <summary>
    /// Paralyse.
    /// Initiative wird halbiert und 25% Chance nicht anzugreifen.
    /// </summary>
    Paralysis = 3,

    /// <summary>
    /// Schwache vergiftung.
    /// Pokemon verliert 1/8 seiner HP zu jedem Ende seines Zugs (wird auf ganze Zahlen abgerundet, macht aber mindestens 1 schaden).
    /// </summary>
    Poison = 4,

    /// <summary>
    /// Starke vergiftung.
    /// Pokemon verliert X/16 seiner HP zu jedem Ende seines Zugs (wird auf ganze Zahlen abgerundet, macht aber mindestens 1 schaden).
    /// X ist ein Counter, welcher bei 1 startet und nach jedem Zug um 1 steigt (wird nach Switch auf 1 resettet).
    /// </summary>
    Toxic = 5,

    /// <summary>
    /// Brennen.
    /// Physische Angriffe werden halbiert.
    /// Pokemon verliert 1/16 seiner HP zu jedem Ende seines Zugs (wird auf ganze Zahlen abgerundet, macht aber mindestens 1 schaden).
    /// </summary>
    Burn = 6,

    /// <summary>
    /// Brennen.
    /// Spezial Angriffe werden halbiert.
    /// Pokemon verliert 1/16 seiner HP zu jedem Ende seines Zugs (wird auf ganze Zahlen abgerundet, macht aber mindestens 1 schaden).
    /// </summary>
    FrostBurn = 7,
}