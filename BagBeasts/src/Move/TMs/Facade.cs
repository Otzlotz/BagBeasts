using BagBeasts.src.Move.Base;
using BagBeasts.src.StatusEffect;
using BagBeasts.src.Battle;

namespace BagBeasts.src.Move.TMs;

public class Facade : MoveBase
{
    /// <inheritdoc/>
    public override ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        if (executingBeast.StatusEffect != StatusEffectEnum.No)
        {
            Damage *= 2;
        }

        ExecuteResult executeResult = base.Execute(executingBeast, defendingBeast, out moveExecuteMessage, switchInBeast);

        if (executingBeast.StatusEffect != StatusEffectEnum.No)
        {
            Damage /= 2;
        }

        return executeResult;
    }
}