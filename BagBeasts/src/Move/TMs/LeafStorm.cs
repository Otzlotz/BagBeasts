using BagBeasts.src.Move.Base;
using BagBeasts.src.Battle;

namespace BagBeasts.src.Move.TMs;

public class LeafStorm : MoveBase
{
    /// <inheritdoc/>
    public override ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        ExecuteResult executeResult = base.Execute(executingBeast, defendingBeast, out moveExecuteMessage, switchInBeast);

        if (executeResult.MoveHit)
        {
            // Eigenen Spezial Angriff um 2 zu senken
            moveExecuteMessage += "\n" + StatChangeService.ChangeSpa(executingBeast, -2);
        }

        return executeResult;
    }
}