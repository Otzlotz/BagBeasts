using src.Move.Base;
using src.Item.ItemBase;

namespace src.Item.ItemBase;
public abstract class HitTakenItemBase : ItemBase
{
    #region Methods

    public abstract string ItemEffect(BagBeastObject holderBeast, BagBeastObject attackingBeast, MoveBase attackingMove);

    #endregion //Methods
}