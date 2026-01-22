using src.Move.Base;
using src.Item.ItemBase;

namespace src.Item.ItemBase;
public abstract class StatChangeItemBase : ItemBase
{
    #region Methods

    public abstract int ItemEffect(BagBeastObject holderBeast, int modifyingStat);

    #endregion //Methods
}