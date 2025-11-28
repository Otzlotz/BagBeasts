using src.Item.ItemBase;
using src.Move.Base;

namespace src.Item.HitTakenItemBase;

public class HitTakenItemBase : ItemBase
{
    #region Methods

    public abstract void ItemEffect(BagBeastObject holderBeast, BagBeastObject attackingBeast, MoveBase attackingMove)
    {
    }

    #endregion //Methods
}