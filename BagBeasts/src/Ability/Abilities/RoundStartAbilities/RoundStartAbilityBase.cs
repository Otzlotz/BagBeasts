

using src.Move.Base;

namespace src.Ability.AbilityBase;

public abstract class RoundStartAbilityBase : AbilityBase
{
    #region Methods

    /// <summary>
    /// Effekt für Abilities nach der Schadenskalkulation
    /// </summary>
    /// <param name="holderBeast">Besitzer der Ability</param>
    /// <param name="defenderBeast">Angegriffenes Bagbeast</param>
    /// <param name="attackMove">Attacke</param>
    /// <param name="damage">Kalkulierter Schaden</param>
    /// <returns>Neuer Schaden</returns>
    public abstract decimal AbilityEffect(BagBeastObject holderBeast, BagBeastObject defenderBeast, MoveBase attackMove, decimal damage);

    #endregion // Methods
}