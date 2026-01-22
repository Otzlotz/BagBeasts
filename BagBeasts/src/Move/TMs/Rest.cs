using src.Move.Base;
using src.StatusEffect;

namespace src.Move.TMs;

public class Rest : MoveBase
{
    #region Methods

    /// <inheritdoc/>
    public override ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        moveExecuteMessage = $"{executingBeast.Name} has used {Name}.";

        PP--;

        if (executingBeast.StatusEffect == StatusEffectEnum.Eep)
        {
            moveExecuteMessage += $"{executingBeast.Name} failed!";
        }

        executingBeast.CurrentHP = executingBeast.MAXHP;

        if (executingBeast.StatusEffect != StatusEffectEnum.No)
        {
            StatusEffectService.RemoveStatusEffect(executingBeast, out string removeStatusMessage);
            moveExecuteMessage += "\n" + removeStatusMessage;
        }

        StatusEffectService.TryApplyStatusEffekt(executingBeast, StatusEffectEnum.Eep, out string statusMessage);
        moveExecuteMessage += "\n" + statusMessage;
        return new ExecuteResult(true);
    }

    #endregion // Methods
}