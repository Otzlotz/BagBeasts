using src.Move.Base;
using src.Item.ItemBase;

namespace src.Item.ItemBase;
public abstract class RockyHelmet : HitTakenItemBase
{
    #region Methods

    public override string ItemEffect(BagBeastObject holderBeast, BagBeastObject attackingBeast, MoveBase attackingMove)
    {
        if (attackingMove.Contact)
        {
            attackingBeast.CurrentHP -= attackingBeast.MAXHP / 8;
            return $"{attackingBeast.Name} was hurt by {holderBeast.Name}'s {holderBeast.HeldItem.Name}."; 
        }
        return string.Empty;
    }

    #endregion //Methods
}