

using src.Move.Base;

namespace src.Item.ItemBase;

public abstract class DamageModifierItemBase : ItemBase
{
    #region Methods

    /// <summary>
    /// Effekt für Items nach der Schadenskalkulation
    /// </summary>
    /// <param name="holderBeast">Besitzer des Item</param>
    /// <param name="defenderBeast">Angegriffenes Bagbeast</param>
    /// <param name="attackMove">Attacke</param>
    /// <param name="damage">Kalkulierter Schaden</param>
    /// <returns>Neuer Schaden</returns>
    public abstract decimal ItemEffect(BagBeastObject holderBeast, BagBeastObject defenderBeast, MoveBase attackMove, decimal damage);

    #endregion // Methods
}