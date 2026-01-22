using src.Move.Base;
using src.Battle;

namespace src.Move.TMs;

public class MuddyWater : MoveBase
{
    /// <inheritdoc/>
    public override ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        ExecuteResult executeResult = base.Execute(executingBeast, defendingBeast, out moveExecuteMessage, switchInBeast);

        if (executeResult.MoveHit)
        {
            // 30% Chance Genauigkeit zu senken
            if (Rnd.Next(1, 100) <= 30)
            {
                moveExecuteMessage += "\n" + StatChangeService.ChangeAcc(defendingBeast, -1);
            }
        }

        return executeResult;
    }
}