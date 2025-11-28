using src.Move;
using src.Move.Base;

namespace src.Item.ItemBase;

public class FocusSash : HitTakenItemBase
{
    #region Methods

    public override void ItemEffect(BagBeastObject holderBeast, BagBeastObject attackingBeast, MoveBase attackingMove)
    {

        if (holderBeast.CurrentHP == holderBeast.MAXHP)
        {

        }
    }


    #endregion // Methods
}