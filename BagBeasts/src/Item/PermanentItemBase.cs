using src.Item.ItemBase;

namespace src.Item.PermanentItemBase;

public class PermanentItemBase : ItemBase
{
    #region Methods

    public abstract void ItemEffect(BagBeast holderBeast)
    {
    }

    #endregion //Methods
}