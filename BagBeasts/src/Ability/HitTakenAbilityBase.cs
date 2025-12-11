using src.Ability.AbilityBase;
using src.Move.Base;

namespace src.Ability.AbilityBase;
public class HitTakenAbilityBase : AbilityBase
{
    #region Methods

    public abstract void AbilityEffect(ref BagBeastObject holderBeast, ref BagBeastObject attackingBeast, MoveBase attackingMove);

    #endregion //Methods
}