using src.Ability.AbilityBase;
using src.Move.Base;

namespace src.Ability.AbilityBase;
public class RoundEndAbilityBase : AbilityBase
{
    #region Methods

    public abstract void AbilityEffect(ref BagBeastObject holderBeast);

    #endregion //Methods
}