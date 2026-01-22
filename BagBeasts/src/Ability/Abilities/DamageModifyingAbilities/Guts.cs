using src.Ability.AbilityBase;
using src.Move.Base;

namespace src.Ability.AbilityBase;
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