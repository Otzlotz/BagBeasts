namespace src.Ability.Base;

public abstract class AbilityBase
{
#region Properties

    public abstract uint ID {get;}
    public abstract string Name {get;}
    public abstract string Description {get;}

#endregion // Properties

#region Methods
    public abstract void AbilityEffect(); 
#endregion // Methods
}