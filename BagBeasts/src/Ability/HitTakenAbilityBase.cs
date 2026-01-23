using BagBeasts.src.Ability.AbilityBase;
using BagBeasts.src.Move.Base;

namespace BagBeasts.src.Ability.AbilityBase;
public abstract class HitTakenAbilityBase : AbilityBase
{
    #region Methods

    public abstract string AbilityEffect(ref BagBeastObject holderBeast, ref BagBeastObject attackingBeast, MoveBase attackingMove);

    #endregion //Methods
}