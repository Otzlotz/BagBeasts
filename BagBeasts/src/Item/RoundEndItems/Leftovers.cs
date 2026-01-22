using src.Move.Base;
using src.Item.ItemBase;

namespace src.Item.ItemBase;
public abstract class Leftovers : RoundEndItemBase
{
    #region Methods

    public override void ItemEffect(BagBeastObject holderBeast)
    {
        holderBeast.CurrentHP += holderBeast.MAXHP * 1/8;
    }

    #endregion //Methods
}