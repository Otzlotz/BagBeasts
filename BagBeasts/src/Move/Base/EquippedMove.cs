using System;

namespace src.Move.Base;

public class EquippedMove
{
    #region  Constructor

    public EquippedMove(MoveBase move)
    {
        Move = move;
        CurrentPP = move.PP;
    }

    #endregion // Constructor

    #region Properties

    public MoveBase Move { get; private set; }
    public uint CurrentPP {get; private set;}
    public MoveSonderbullshit Sonderbullshit {get;} = new MoveSonderbullshit();

    #endregion // Properties
    
    #region Methods

    public void Use(MoveBase enemyMove)
    {
        // TODO: Es muss eigentlich vorher noch geprüft werden, ob der Move überhaupt genutzt werden kann (zb. ob dieser Locked ist, ist in MoveSonderbullshit)

        //Move.Execute(enemyMove);
        //CurrentPP--;
    }

    #endregion // Methods
}