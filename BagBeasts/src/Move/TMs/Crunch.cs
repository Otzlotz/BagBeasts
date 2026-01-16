using src.Move.Base;
using src.StatusEffect;
using src.Battle;

namespace src.Move.TMs;

public class Crunch : MoveBase
{
    public Crunch()
    {
        FlinchEnemyChance = 20;
    }

    
    /// <inheritdoc/>
    public override ExecuteResult Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
        ExecuteResult executeResult = base.Execute(executingBeast, defendingBeast, switchInBeast, out moveExecuteMessage);

        // 20% Chance Verteidigung des Gegner um 1 zu senken
        if (Rnd.Next(1, 100) <= 20)
        {
            moveExecuteMessage += "\n" + StatChangeService.ChangeDef(defendingBeast, -1);
        }

        return executeResult;
    }
}