using System;

namespace BagBeasts.src.Move.Base
{
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
        public uint CurrentPP { get; private set; }

        /// <summary>
        /// Wenn true, dann ist der Move gesperrt
        /// </summary>
        public bool Lock { get; set; }

        #endregion // Properties
    }
}