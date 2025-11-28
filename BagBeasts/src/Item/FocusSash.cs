namespace src.Item.Base;

public class FocusSash : Base
{
    #region Properties

    public string Name {get; set;}

    public string Description {get; set;}

    public readonly ItemType ItemType {get => return ItemType.TakenHitItem;}

    #endregion // Properties

    #region Constructor

    public FocusSash()
    {
    }

    #endregion // Constructor

    #region Methods

    public void ItemEffect(BagBeastObject holderBagBeast)
    {
        if (holderBagBeast.CurrentHP == MAXHP)
        {
            
        }
    }

    #endregion // Methods
}