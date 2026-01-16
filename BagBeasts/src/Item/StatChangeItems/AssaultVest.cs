using src.Move.Base;
using src.Item.ItemBase;

namespace src.Item.ItemBase;
public abstract class AssaultVest : StatChangeItemBase
{
    #region Methods

    public override int ItemEffect(BagBeastObject holderBeast, int modifyingStat)
    {
        var resultStat = modifyingStat * 1.5;
        
        if (holderBeast.Move1.Move.Category == Category.Status)
        {
            holderBeast.Move1.Lock = true;
        }

        if (holderBeast.Move2.Move.Category == Category.Status)
        {
            holderBeast.Move2.Lock = true;
        }

        if (holderBeast.Move3.Move.Category == Category.Status)
        {
            holderBeast.Move3.Lock = true;
        }

        if (holderBeast.Move4.Move.Category == Category.Status)
        {
            holderBeast.Move4.Lock = true;
        }
    }

    #endregion //Methods
}