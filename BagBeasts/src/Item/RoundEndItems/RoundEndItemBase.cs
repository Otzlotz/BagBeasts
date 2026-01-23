using BagBeasts.src.Move.Base;
using BagBeasts.src.Item.ItemBase;

namespace BagBeasts.src.Item.ItemBase;
public abstract class RoundEndItemBase : ItemBase
{
    #region Methods

    public abstract void ItemEffect(BagBeastObject holderBeast);

    #endregion //Methods
}