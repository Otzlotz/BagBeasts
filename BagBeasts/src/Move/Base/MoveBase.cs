

namespace src.Move.Base;

public abstract class MoveBase
{
    #region Properties 

    public abstract readonly uint ID {get;}

    public abstract readonly uint Damage {get;}

    // 0 - 100. Null trifft immer
    public abstract readonly uint? Accuracy {get;}

    public abstract readonly uint CritChanceTier {get;}

    public abstract readonly uint PP {get;}

    public abstract readonly Type Type {get;}

    public abstract readonly Category Category {get;}

    #endregion // Properties

    #region Methods

    public abstract void Execute(MoveBase enemyMove);

    #endregion // Methods
}
