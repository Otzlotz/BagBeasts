using BagBeasts.src.Move.Base;
using BagBeasts.src.StatusEffect;
using BagBeasts.src.Battle;

namespace BagBeasts.src.Move.TMs;

public class Avalanche : MoveBase
{
    /// <inheritdoc/>
    public override ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        if (executingBeast.StatusEffect == StatusEffectEnum.FrostBurn)
        {
            Damage += 30;
        }

        ExecuteResult executeResult = base.Execute(executingBeast, defendingBeast, out moveExecuteMessage, switchInBeast);

        if (executingBeast.StatusEffect == StatusEffectEnum.FrostBurn)
        {
            Damage -= 30;
        }

        return executeResult;

        // TODO: Für Kimon. Stärke des Move von 60 auf 90 erhöhen
    }
}