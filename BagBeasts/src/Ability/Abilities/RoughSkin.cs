using src.Ability.AbilityBase;
using src.Move.Base;

namespace src.Ability.AbilityBase;
public class RoughSkin : HitTakenAbilityBase
{
    #region Methods

    public override string AbilityEffect(ref BagBeastObject holderBeast, ref BagBeastObject attackingBeast, MoveBase attackingMove)
    {
        if (attackingMove.Contact)
        {
            attackingBeast.CurrentHP -= attackingBeast.MAXHP / 8;
            return $"{attackingBeast.Name} was hurt by {holderBeast.Name}'s {holderBeast.Ability.Name}."; 
        }
        return string.Empty;
    }

    #endregion //Methods
}