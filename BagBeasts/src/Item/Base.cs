namespace src.Item.Base;
public abstract class ItemBase
{
#region Properties
    public abstract readonly uint ID {get;}

    public abstract readonly string Name {get;}

    public abstract readonly string Description {get;}

#endregion Properties

#region Methods

    public abstract readonly void AbilityEffect();
    
#endregion Methods
}