using BagBeasts.src.Move.Base;
using BagBeasts.src.Item.ItemBase;

namespace BagBeasts.src.Item.ItemBase;
public abstract class AssaultVest : DamageReductionItemBase
{
    #region Methods

    public override string ItemEffect(ref BagBeastObject holderBeast, BagBeastObject attackingBeast, MoveBase attackingMove, ref decimal damage)
    {
        if (attackingMove.Category == Category.Special)
        {
            damage = damage * 2/3;
        }

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
        return string.Empty;
        // ToDo: fix
    }

    #endregion //Methods
}