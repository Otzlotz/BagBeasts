using BagBeasts.src.Move.Base;
using BagBeasts.src.Item.ItemBase;

namespace BagBeasts.src.Item.ItemBase;
public abstract class StatChangeItemBase : ItemBase
{
    #region Methods

    public abstract int ItemEffect(BagBeastObject holderBeast, int modifyingStat);

    #endregion //Methods
}