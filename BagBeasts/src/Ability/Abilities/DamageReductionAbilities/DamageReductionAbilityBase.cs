

using src.Move.Base;

namespace src.Ability.AbilityBase;

public abstract class DamageReductionAbilityBase : AbilityBase
{
    #region Methods

    /// <summary>
    /// Effekt für Abilities nach der Schadenskalkulation
    /// </summary>
    /// <param name="holderBeast">Besitzer der Ability</param>
    /// <param name="attackMove">Attacke</param>
    /// <param name="damage">Kalkulierter Schaden</param>
    /// <returns>Neuer Schaden</returns>
    public abstract string AbilityEffect(BagBeastObject holderBeast, MoveBase attackMove, ref int damage);

    #endregion // Methods
}