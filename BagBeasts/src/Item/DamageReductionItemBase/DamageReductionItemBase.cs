using BagBeasts.src.Move.Base;
using BagBeasts.src.Item.ItemBase;

namespace BagBeasts.src.Item.ItemBase;
public abstract class DamageReductionItemBase : ItemBase
{
    #region Methods

    public abstract string ItemEffect(ref BagBeastObject holderBeast, MoveBase attackingMove, ref int damage);

    #endregion //Methods
}