using BagBeasts.src.Move.Base;
using BagBeasts.src.StatusEffect;

namespace BagBeasts.src.Move.TMs;

public class Blizzard : MoveBase
{
    /// <inheritdoc/>
    public override ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        ExecuteResult executeResult = base.Execute(executingBeast, defendingBeast, out moveExecuteMessage, switchInBeast);

        if (executeResult.MoveHit)
        {
            // 20% Chance Frostbrand zuzufügen (wenn es Fehlschlägt muss die Message nicht hinzugefügt werden!)
            if (Rnd.Next(1, 100) <= 20 && StatusEffectService.TryApplyStatusEffekt(defendingBeast, StatusEffectEnum.FrostBurn, out string statusMessage))
            {
                moveExecuteMessage += "\n" + statusMessage;
            }
        }

        return executeResult;
    }
}