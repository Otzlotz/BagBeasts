

using src.Move.Base;

namespace src.Ability.AbilityBase;

public abstract class Levitate : DamageReductionAbilityBase
{
    #region Methods

    /// <summary>
    /// Effekt für Abilities nach der Schadenskalkulation
    /// </summary>
    /// <param name="holderBeast">Besitzer der Ability</param>
    /// <param name="attackMove">Attacke</param>
    /// <param name="damage">Kalkulierter Schaden</param>
    /// <returns>Neuer Schaden</returns>
    public override string AbilityEffect(BagBeastObject holderBeast, MoveBase attackMove, ref decimal damage)
    {
        if (attackMove.Type == Type.Ground)
        {
            damage = 0;
        }
        return $"{attackMove.Name} had no effect on {holderBeast.Name}."; 
    }

    #endregion // Methods
}