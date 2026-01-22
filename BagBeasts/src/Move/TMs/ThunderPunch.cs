using src.Move.Base;
using src.StatusEffect;

namespace src.Move.TMs;

public class ThunderPunch : MoveBase
{
    /// <inheritdoc/>
    public override ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        ExecuteResult executeResult = base.Execute(executingBeast, defendingBeast, out moveExecuteMessage, switchInBeast);

        if (executeResult.MoveHit)
        {
            // 10% Chance Paralyse zuzufügen (wenn es Fehlschlägt muss die Message nicht hinzugefügt werden!)
            if (Rnd.Next(1, 100) <= 10 && StatusEffectService.TryApplyStatusEffekt(defendingBeast, StatusEffectEnum.Paralysis, out string statusMessage))
            {
                moveExecuteMessage += "\n" + statusMessage;
            }
        }

        return executeResult;
    }
}