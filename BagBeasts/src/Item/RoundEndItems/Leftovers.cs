using BagBeasts.src.Move.Base;
using BagBeasts.src.Item.ItemBase;

namespace BagBeasts.src.Item.ItemBase;
public abstract class Leftovers : RoundEndItemBase
{
    #region Methods

    public override void ItemEffect(BagBeastObject holderBeast)
    {
        holderBeast.CurrentHP += holderBeast.MAXHP * 1/8;
    }

    #endregion //Methods
}