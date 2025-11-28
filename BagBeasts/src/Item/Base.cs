namespace src.Item.Base;
public abstract class ItemBase
{
#region Properties
    public abstract uint ID {get;}

    public abstract string Name {get;}

    public abstract string Description {get;}

#endregion // Properties

#region Methods

    public abstract void ItemEffect();
    
#endregion // Methods
}