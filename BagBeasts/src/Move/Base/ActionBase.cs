


namespace src.Move.Base;

public abstract class ActionBase
{
    #region Properties
    public uint ID {get; protected set;}

    public string Name{get; protected set;}

    public string Description{get; protected set;}

    public int Prio{get; protected set;}

    #endregion // Properties
}