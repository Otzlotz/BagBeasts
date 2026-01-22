using src.Move.Base;
using src.Item.ItemBase;
using src.Move.Base;

namespace src.Item.ItemBase;
public abstract class ChoiceScarf : ItemBase
{
    #region Methods

    public override void ItemEffect(BagBeastObject holderBeast, MoveBase attackMove)
    {
        if (holderBeast.Move1 != attackMove)
        {
            holderBeast.Move1.Lock = true;
        }

        if (holderBeast.Move2 != attackMove)
        {
            holderBeast.Move2.Lock = true;
        }

        if (holderBeast.Move3 != attackMove)
        {
            holderBeast.Move3.Lock = true;
        }

        if (holderBeast.Move4 != attackMove)
        {
            holderBeast.Move4.Lock = true;
        }
    }

    #endregion //Methods
}