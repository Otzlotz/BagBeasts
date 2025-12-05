namespace src.Move.Base;

public abstract class MoveBase
{
    #region Properties 

    public abstract uint ID {get;}

    public abstract uint Damage {get;}

    // 0 - 100. Null trifft immer
    public abstract uint? Accuracy {get;}

    public abstract uint CritChanceTier {get;}

    public abstract uint PP {get;}

    public abstract Type Type {get;}

    public abstract Category Category {get;}

    #endregion // Properties

    #region Methods

    public abstract int Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, BagBeastObject? switchInBeast = null);

    #endregion // Methods
}