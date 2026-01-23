using BagBeasts.src.Move.Base;
using BagBeasts.src.Battle;

namespace BagBeasts.src.Move.TMs;

public class EarthPower : MoveBase
{
    /// <inheritdoc/>
    public override ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        ExecuteResult executeResult = base.Execute(executingBeast, defendingBeast, out moveExecuteMessage, switchInBeast);

        if (executeResult.MoveHit)
        {
            // 10% Chance Spezial Verteidigung des Gegner um 1 zu senken
            if (Rnd.Next(1, 100) <= 10)
            {
                moveExecuteMessage += "\n" + StatChangeService.ChangeSpd(defendingBeast, -1);
            }
        }

        return executeResult;
    }
}