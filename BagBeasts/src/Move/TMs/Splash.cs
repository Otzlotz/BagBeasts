using BagBeasts.src.Battle;
using BagBeasts.src.Move.Base;
using BagBeasts.src.StatusEffect;

namespace BagBeasts.src.Move.TMs;

public class Splash : MoveBase
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

        // Random ermitteln, welcher Statuseffekt ausgelöst wird
        StatusEffectEnum statusEffect = (StatusEffectEnum)Rnd.Next(2, 7);

        bool moveHit = StatusEffectService.TryApplyStatusEffekt(defendingBeast, statusEffect, out string statusMessage);
        moveExecuteMessage += "\n" + statusMessage;

        return new ExecuteResult(moveHit);
    }

    #endregion // Methods
}