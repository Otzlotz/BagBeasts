using src.Ability.AbilityBase;
using src.Move.Base;

namespace src.Ability.AbilityBase;
public abstract class RoundEndAbilityBase : AbilityBase
{
    #region Methods

    public abstract void AbilityEffect(ref BagBeastObject holderBeast);

    #endregion //Methods
}