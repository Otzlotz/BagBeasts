using BagBeasts.src.Ability.AbilityBase;
using BagBeasts.src.Move.Base;

namespace BagBeasts.src.Ability.AbilityBase;
public class Guts : DamageModifierAbilityBase
{
    #region Methods

    public override decimal AbilityEffect(BagBeastObject holderBeast, BagBeastObject defenderBeast, MoveBase attackMove, decimal damage)
    {
        if (holderBeast.StatusEffect != StatusEffect.StatusEffectEnum.No)
        {
            damage *= 1.5m;
        }

        return damage;
    }

    #endregion //Methods
}