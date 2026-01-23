

using BagBeasts.src.Move.Base;

namespace BagBeasts.src.Item.ItemBase;

public abstract class AccuracyModifyingItemBase : ItemBase
{
    #region Methods

    /// <summary>
    /// Effekt für Items, welche die Accuracy beeinflussen
    /// </summary>
    /// <param name="holderBeast">Besitzer des Item</param>
    /// <param name="enemyBeast">Gegner Bagbeast</param>
    /// <param name="attackMove">Attacke</param>
    /// <param name="isAttacker">true: <see cref="holderBeast"/> ist der Angreifer | false: <see cref="enemyBeast"/> ist der Angreifer</param>
    /// <param name="accuracy">Genauigkeit der Attacke (ggf. bereits angepasst)</param>
    /// <returns>Neue Accuracy</returns>
    public abstract decimal ItemEffect(BagBeastObject holderBeast, BagBeastObject enemyBeast, MoveBase attackMove, bool isAttacker, decimal? accuracy);

    #endregion // Methods
}