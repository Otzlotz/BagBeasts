using BagBeasts.src.Ability.AbilityBase;
using BagBeasts.src.Move.Base;

namespace BagBeasts.src.Ability.AbilityBase;
public class ToughClaws : DamageModifierAbilityBase
{
    #region Methods

    public override decimal AbilityEffect(BagBeastObject holderBeast, BagBeastObject defenderBeast, MoveBase attackMove, decimal damage)
    {
        if (attackMove.Contact)
        {
            damage = damage * 1.3m;
        }

        return damage;
    }

    #endregion //Methods
}