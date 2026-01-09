using src.Battle;
using src.Move.Base;
using src.StatusEffect;

namespace src.Move.TMs;

public class Return : MoveBase
{
    #region Methods

    /// <inheritdoc/>
    public override bool Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, BagBeastObject? switchInBeast = null, out string moveExecuteMessage)
    {
        // TODO: Der müsste irgendwie als Singleton angelegt werden
        BattleCalculationService battleCalculationService = new BattleCalculationService();

        PP--;

        // Prüfen, ob der Angriff trifft
        if (!battleCalculationService.MoveHit(executingBeast, defendingBeast, this, out string moveHitMessage))
        {
            moveExecuteMessage = moveHitMessage;
            return false;
        }

        // Prüfen, ob ein Krit ausgelöst wird
        bool critTriggered = battleCalculationService.CritTriggered(CritChanceTier, out string critMessage);

        // Schaden am Gegner zufügen
        ExcecuteHit(executingBeast, defendingBeast, this, battleCalculationService.HitDamage(executingBeast, defendingBeast, this, critTriggered), out string executeHitMessage);

        if (critTriggered)
        {
            moveExecuteMessage = critMessage + "\n" + executeHitMessage;
        }
        else
        {
            moveExecuteMessage = executeHitMessage;
        }

        return true;
    }

    #endregion // Methods
}