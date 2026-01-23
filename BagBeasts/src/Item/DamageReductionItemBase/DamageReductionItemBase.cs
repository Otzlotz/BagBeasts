using src.Move.Base;
using src.Item.ItemBase;

namespace src.Item.ItemBase;
public abstract class DamageReductionItemBase : ItemBase
{
    #region Methods

    public abstract string ItemEffect(ref BagBeastObject holderBeast, MoveBase attackingMove, ref int damage);

    #endregion //Methods
}