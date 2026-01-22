using src.Ability.AbilityBase;
using src.Move.Base;

namespace src.Ability.AbilityBase;
public abstract class HitTakenAbilityBase : AbilityBase
{
    #region Methods

    public abstract string AbilityEffect(ref BagBeastObject holderBeast, ref BagBeastObject attackingBeast, MoveBase attackingMove);

    #endregion //Methods
}