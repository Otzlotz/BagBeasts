

namespace src.Move.Base;

public class ExecuteResult
{
    #region Constructor

    public ExecuteResult(bool moveHit)
    {
        MoveHit = moveHit;
    }

    #endregion // Constructor

    #region Properties

    /// <summary>
    /// Ob der Move trifft
    /// </summary>
    public bool MoveHit{get; set;}

    /// <summary>
    /// Ob der Move versucht den Gegner zurückzuschrecken
    /// </summary>
    public bool FlinchEnemy{get; set;}

    #endregion // Properties
}