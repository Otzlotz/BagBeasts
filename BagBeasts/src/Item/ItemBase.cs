using src.Item.ItemType;

namespace src.Item.Base;

public abstract class ItemBase
{
    #region Properties
    public abstract uint ID {get;}

    public abstract string Name {get;}

    public abstract string Description {get;}

    public abstract ItemType ItemType {get; set;}

    #endregion // Properties

    #region Methods

    public abstract void ItemEffect(BagBeastObject holderBagBeast);
    
    #endregion // Methods
}