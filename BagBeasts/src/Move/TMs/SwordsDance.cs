using src.Battle;
using src.Move.Base;

namespace src.Move.TMs;

public class SwordsDance : MoveBase
{
    #region Methods

    /// <inheritdoc/>
    public override ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        moveExecuteMessage = $"{executingBeast.Name} has used {Name}.";

        PP--;

        moveExecuteMessage += "\n" + StatChangeService.ChangeAtk(executingBeast, 2);
        return new ExecuteResult(true);
    }

    #endregion // Methods
}