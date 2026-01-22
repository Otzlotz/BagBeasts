using src.Move.Base;
using src.Battle;

namespace src.Move.TMs;

public class Trailblaze : MoveBase
{
    /// <inheritdoc/>
    public override ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        ExecuteResult executeResult = base.Execute(executingBeast, defendingBeast, out moveExecuteMessage, switchInBeast);

        if (executeResult.MoveHit)
        {
            // Erhöht die eigene Initiative um 1
            moveExecuteMessage += "\n" + StatChangeService.ChangeInt(executingBeast, 1);
            
        }

        return executeResult;
    }
}