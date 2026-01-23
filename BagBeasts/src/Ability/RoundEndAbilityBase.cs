using BagBeasts.src.Ability.AbilityBase;
using BagBeasts.src.Move.Base;

namespace BagBeasts.src.Ability.AbilityBase;
public abstract class RoundEndAbilityBase : AbilityBase
{
    #region Methods

    public abstract void AbilityEffect(ref BagBeastObject holderBeast);

    #endregion //Methods
}