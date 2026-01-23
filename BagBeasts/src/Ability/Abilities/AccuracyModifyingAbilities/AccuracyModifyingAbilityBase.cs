




using src.Move.Base;

namespace src.Ability.AbilityBase;

public abstract class AccuracyModifyingAbilityBase : AbilityBase
{
    #region Methods

    /// <summary>
    /// Effekt für Abilities, welche die Accuracy beeinflussen
    /// </summary>
    /// <param name="holderBeast">Besitzer der Ability</param>
    /// <param name="enemyBeast">Gegner Bagbeast</param>
    /// <param name="attackMove">Attacke</param>
    /// <param name="isAttacker">true: <see cref="holderBeast"/> ist der Angreifer | false: <see cref="enemyBeast"/> ist der Angreifer</param>
    /// <param name="accuracy">Genauigkeit der Attacke (ggf. bereits angepasst)</param>
    /// <returns>Neue Accuracy</returns>
    public abstract decimal? AbilityEffect(BagBeastObject holderBeast, BagBeastObject enemyBeast, MoveBase attackMove, bool isAttacker, decimal? accuracy);

    #endregion // Methods
}