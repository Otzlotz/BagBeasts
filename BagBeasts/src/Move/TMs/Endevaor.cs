using BagBeasts.src.Battle;
using BagBeasts.src.Move.Base;

namespace BagBeasts.src.Move.TMs;

public class Endeavor : MoveBase
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

        // Versuchen die HP des Gegner auf die eigenen zu senken
        if (defendingBeast.CurrentHP <= executingBeast.CurrentHP)
        {
            moveExecuteMessage += "\n" + $"{Name} failed!";
        }
        else
        {
            int damage = executingBeast.CurrentHP - defendingBeast.CurrentHP;
            ExcecuteHit(executingBeast, defendingBeast, this, damage, out string executeHitMessage);
        }

        return new ExecuteResult(true);
    }

    #endregion // Methods
}