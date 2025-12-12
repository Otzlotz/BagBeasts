using src.Ability.AbilityBase;
using src.Move.Base;

namespace src.Ability.AbilityBase;
public class ToughClaws : DamageModifierAbilityBase
{
    #region Methods

    public decimal AbilityEffect(BagBeastObject holderBeast, BagBeastObject defenderBeast, MoveBase attackMove, decimal damage)
    {
        if (attackingMove.Contact)
        {
            damage = damage * 1.3;
        }

        return damage;
    }

    #endregion //Methods
}