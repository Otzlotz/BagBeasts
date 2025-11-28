using src.Item.ItemBase;
using src.Item.HitTakenItemBase;
using src.Move.Base;
using src;

namespace src.Item.FocusSash;

public class FocusSash : HitTakenItemBase
{
    #region Methods

    public override void ItemEffect(BagBeastObject holderBeast)
    {
        if (holderBeast.CurrentHP == holderBeast.MAXHP)
        {
            
        }
    }

    #endregion // Methods
}