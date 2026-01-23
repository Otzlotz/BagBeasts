using src.Battle;
using src.Move.Base;
using src.StatusEffect;

namespace src.Move.TMs;

public class WillOWisp : MoveBase
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

        // Ziel verbrennen
        bool moveHit = StatusEffectService.TryApplyStatusEffekt(defendingBeast, StatusEffectEnum.Burn, out string statusMessage);
        moveExecuteMessage += "\n" + statusMessage;

        return new ExecuteResult(moveHit);
    }

    #endregion // Methods
}