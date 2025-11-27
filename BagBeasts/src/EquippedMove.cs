using System;

public class EquippedMove
{
        public Move Move { get; private set; }
        public int CurrentPP;
    
    public EquippedMove(Move mov)
	{
        Move = mov;
        CurrentPP = mov.PP;
	}
}
