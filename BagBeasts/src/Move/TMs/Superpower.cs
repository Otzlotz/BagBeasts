using BagBeasts.src.Move.Base;
using BagBeasts.src.Battle;

namespace BagBeasts.src.Move.TMs;

public class Superpower : MoveBase
{
    /// <inheritdoc/>
    public override ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        ExecuteResult executeResult = base.Execute(executingBeast, defendingBeast, out moveExecuteMessage, switchInBeast);

        if (executeResult.MoveHit)
        {
            // Eigenen Angriff und Verteidigung um 1 zu senken
            moveExecuteMessage += "\n" + StatChangeService.ChangeAtk(executingBeast, -1);
            moveExecuteMessage += "\n" + StatChangeService.ChangeDef(executingBeast, -1);
        }

        return executeResult;
    }
}