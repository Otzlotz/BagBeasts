using BagBeasts.src.Move;
using BagBeasts.src.Move.Base;

namespace BagBeasts.src.Item.ItemBase;

public class FocusSash : DamageReductionItemBase
{
    #region Methods

    public override string ItemEffect(ref BagBeastObject holderBeast, MoveBase attackingMove, ref decimal damage)
    {
        if (damage >= holderBeast.MAXHP && holderBeast.MAXHP == holderBeast.CurrentHP)
        {
            damage = holderBeast.MAXHP - 1;
            holderBeast.HeldItem = null;

            return $"Fokussash was used.\n{holderBeast.Name} survived the hit because of Fokussash.";
        }
        return string.Empty;
    }


    #endregion // Methods
}