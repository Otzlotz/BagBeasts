

using BagBeasts.src.Move.Base;

namespace BagBeasts.src.Ability.AbilityBase;

public abstract class Levitate : DamageReductionAbilityBase
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
    public override string AbilityEffect(BagBeastObject holderBeast, BagBeastObject defenderBeast, MoveBase attackMove, ref decimal damage)
    {
        if (attackMove.Type == TypeDB.Ground)
        {
            damage = 0;
        }
        return $"{attackMove.Name} had no effect on {holderBeast.Name}."; 
    }

    #endregion // Methods
}