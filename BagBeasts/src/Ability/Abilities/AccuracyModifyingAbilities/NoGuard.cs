using BagBeasts.src.Move.Base;

namespace BagBeasts.src.Ability.AbilityBase;

public class NoGuard : AccuracyModifyingAbilityBase
{
    #region Methods

    /// <summary>
    /// Garantiert Treffer
    /// </summary>
    /// <param name="holderBeast">Besitzer der Ability</param>
    /// <param name="enemyBeast">Gegner Bagbeast</param>
    /// <param name="attackMove">Attacke</param>
    /// <param name="isAttacker">true: <see cref="holderBeast"/> ist der Angreifer | false: <see cref="enemyBeast"/> ist der Angreifer</param>
    /// <param name="accuracy">Genauigkeit der Attacke (ggf. bereits angepasst)</param>
    /// <returns>Neue Accuracy</returns>
    public override decimal AbilityEffect(BagBeastObject holderBeast, BagBeastObject enemyBeast, MoveBase attackMove, bool isAttacker, decimal? accuracy)
    {
        return 0;
        // ToDo: return fixen
    }

    #endregion // Methods
}