using src.Move.Base;

namespace src.Move.TMs;

public class Return : MoveBase
{
    #region Properties 

    public override uint ID {get;} = 1;

    public override uint Damage {get;} = 100;

    public override uint? Accuracy {get;} = 100;

    public override uint CritChanceTier {get;} = 1;

    public override uint PP {get;} = 20;

    public override Type Type {get;} = Type.Normal;

    public override Category Category {get;} = Category.Physical;

    #endregion // Properties

    #region Methods

    public void Execute(MoveBase enemyMove)
    {
        // TODO: Dennis kreuzigen
    }

    public override int Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, BagBeastObject? switchInBeast = null)
    {
        throw new NotImplementedException();
    }

    #endregion // Methods
}