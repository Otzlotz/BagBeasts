using src.Move.Base;
using src.StatusEffect;
using src.Battle;

namespace src.Move.TMs;

public class Hey : MoveBase
{
    /// <inheritdoc/>
    public override ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        if (defendingBeast.StatusEffect != StatusEffectEnum.No)
        {
            Damage *= 2;
        }

        ExecuteResult executeResult = base.Execute(executingBeast, defendingBeast, out moveExecuteMessage, switchInBeast);

        if (defendingBeast.StatusEffect != StatusEffectEnum.No)
        {
            Damage /= 2;
        }

        return executeResult;
    }
}