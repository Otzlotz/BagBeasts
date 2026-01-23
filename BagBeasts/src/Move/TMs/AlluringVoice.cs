using BagBeasts.src.Move.Base;

namespace BagBeasts.src.Move.TMs;

public class AlluringVoice : MoveBase
{
    /// <inheritdoc/>
    public override ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        ExecuteResult executeResult = base.Execute(executingBeast, defendingBeast, out moveExecuteMessage, switchInBeast);

        if (executeResult.MoveHit)
        {
            // TODO: Braucht noch SOnderbullshit, dass es den Gegner verwirrt, wenn er diese Runde eine Statuserhöhung erhalten hat
        }

        return executeResult;
    }
}