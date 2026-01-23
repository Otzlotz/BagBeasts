using BagBeasts.src.Move.Base;
using BagBeasts.src.Item.ItemBase;

namespace BagBeasts.src.Item.ItemBase;
public abstract class HitTakenItemBase : ItemBase
{
    #region Methods

    public abstract string ItemEffect(BagBeastObject holderBeast, BagBeastObject attackingBeast, MoveBase attackingMove);

    #endregion //Methods
}