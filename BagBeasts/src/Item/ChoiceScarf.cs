using src.Move.Base;
using src.Item.ItemBase;
using src.Move.Base;

namespace src.Item.ItemBase;
public abstract class ChoiceScarf : ItemBase
{
    #region Methods

    public void ItemEffect(BagBeastObject holderBeast, ActionBase attackMove)
    {
        if (holderBeast.Move1.Move.ID != attackMove.ID)
        {
            holderBeast.Move1.Lock = true;
        }

        if (holderBeast.Move2.Move.ID != attackMove.ID)
        {
            holderBeast.Move2.Lock = true;
        }

        if (holderBeast.Move3.Move.ID != attackMove.ID)
        {
            holderBeast.Move3.Lock = true;
        }

        if (holderBeast.Move4.Move.ID != attackMove.ID)
        {
            holderBeast.Move4.Lock = true;
        }
    }

    #endregion //Methods
}