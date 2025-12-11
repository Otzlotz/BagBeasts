using src.Move.Base;
using src.Item.ItemBase;

namespace src.Item.ItemBase;
public abstract class RoundEndItemBase : ItemBase
{
    #region Methods

    public abstract void ItemEffect(BagBeastObject holderBeast);

    #endregion //Methods
}