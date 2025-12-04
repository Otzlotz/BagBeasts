

using src.Move.Base;

namespace src.Move.TMs;

public class Return : MoveBase
{
    #region Properties 

    public readonly uint ID {get;} = 1;

    public readonly uint Damage {get;} = 100;

    public readonly uint? Accuracy {get;} = 100;

    public readonly uint CritChanceTier {get;} = 1;

    public readonly uint PP {get;} = 20;

    public readonly Type Type {get;} = Type.Normal;

    public readonly Category Category {get;} = Category.Physical;

    #endregion // Properties

    #region Methods

    public void Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast)
    {
        // TODO: DO
    }

    #endregion // Methods
}