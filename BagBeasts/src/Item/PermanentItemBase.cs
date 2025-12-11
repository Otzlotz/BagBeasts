using BagBeasts.src.Beast;

namespace src.Item.ItemBase;
public abstract class PermanentItemBase : ItemBase
{
    #region Methods
    public abstract void ItemEffect(BagBeastObject holderBeast);

    #endregion //Methods
}