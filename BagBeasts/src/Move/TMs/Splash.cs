using src.Battle;
using src.Move.Base;
using src.StatusEffect;

namespace src.Move.TMs;

public class Splash : MoveBase
{
    #region Methods

    /// <inheritdoc/>
    public override ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        PP--;

        // Prüfen, ob der Angriff trifft
        if (!BattleCalculationService.MoveHit(executingBeast, defendingBeast, this, out string moveHitMessage))
        {
            moveExecuteMessage = moveHitMessage;
            return new ExecuteResult(false);
        }

        // Random ermitteln, welcher Statuseffekt ausgelöst wird
        StatusEffectEnum statusEffect = (StatusEffectEnum)Rnd.Next(2, 7);

        return new ExecuteResult(StatusEffectService.TryApplyStatusEffekt(defendingBeast, statusEffect, out moveExecuteMessage));
    }

    #endregion // Methods
}