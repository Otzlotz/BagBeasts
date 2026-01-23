using BagBeasts.src.Battle;
using BagBeasts.src.Move.Base;

namespace BagBeasts.src.Move.TMs;

public class PainSplit : MoveBase
{
    #region Methods

    /// <inheritdoc/>
    public override ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        moveExecuteMessage = $"{executingBeast.Name} has used {Name}.";

        PP--;

        // Prüfen, ob der Angriff trifft
        if (!BattleCalculationService.MoveHit(executingBeast, defendingBeast, this, out string moveHitMessage))
        {
            moveExecuteMessage += "\n" + moveHitMessage;
            return new ExecuteResult(false);
        }

        // HP der Bagbeasts aufteilen
        int combinedHp = executingBeast.CurrentHP + defendingBeast.CurrentHP;
        executingBeast.CurrentHP = (int)(combinedHp / 2);
        defendingBeast.CurrentHP = (int)(combinedHp / 2);

        return new ExecuteResult(true);
    }

    #endregion // Methods
}