using src.Ability.AbilityBase;
using src.Move.Base;

namespace src.Ability.AbilityBase;
public class ToughClaws : DamageModifierAbilityBase
{
    #region Methods

    public override decimal AbilityEffect(BagBeastObject holderBeast, BagBeastObject defenderBeast, MoveBase attackMove, decimal damage)
    {
        if (attackMove.Category == Category.Physical)
        {
            damage = damage * 2;
        }

        return damage;
    }

    #endregion //Methods
}