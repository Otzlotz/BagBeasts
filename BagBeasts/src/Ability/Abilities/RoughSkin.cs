using src.Ability.AbilityBase;
using src.Move.Base;

namespace src.Ability.AbilityBase;
public class RoughSkin : HitTakenAbilityBase
{
    #region Methods

    public override void AbilityEffect(ref BagBeastObject holderBeast, ref BagBeastObject attackingBeast, MoveBase attackingMove)
    {
        if (attackingMove.Contact)
        {
            attackingBeast.CurrentHP -= attackingBeast.MAXHP / 8;
        }
    }

    #endregion //Methods
}