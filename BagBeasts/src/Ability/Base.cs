namespace src.Ability.Base;

public abstract class AbilityBase
{
#region Properties

    public abstract readonly uint ID {get;}
    public abstract readonly string Name {get;}
    public abstract readonly string Description {get;}

#endregion // Properties

#region Methods
    public abstract void AbilityEffect(); 
#endregion // Methods
}