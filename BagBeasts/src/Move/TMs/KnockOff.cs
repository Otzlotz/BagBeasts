using src.Move.Base;
using src.StatusEffect;
using src.Battle;

namespace src.Move.TMs;

public class KnockOff : MoveBase
{
    /// <inheritdoc/>
    public override ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        if (defendingBeast.HeldItem != null)
        {
            Damage += 30;
        }

        ExecuteResult executeResult = base.Execute(executingBeast, defendingBeast, out moveExecuteMessage, switchInBeast);

        if (defendingBeast.HeldItem != null)
        {
            Damage -= 30;

            // TODO: Wenn der Gegner Delegator aktiv hat, dann soll das Item nicht Entfernt werden
            defendingBeast.HeldItem = null;
        }

        return executeResult;
    }
}