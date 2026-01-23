using BagBeasts.src.Move.Base;

namespace BagBeasts.src.Move.TMs;

public class Struggle : MoveBase
{
    public Struggle()
    {
        RecoilBasedOnOwnHp = 25;
        LosePP = false;
    }

    // INFO: Nutzt das Standard Execute!
}