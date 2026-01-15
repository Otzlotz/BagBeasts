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
        PP--;

        // Prüfen, ob der Angriff trifft
        if (!BattleCalculationService.MoveHit(executingBeast, defendingBeast, this, out string moveHitMessage))
        {
            moveExecuteMessage = moveHitMessage;
            return false;
        }

        // Prüfen, ob ein Krit ausgelöst wird
        bool critTriggered = BattleCalculationService.CritTriggered(CritChanceTier, out string critMessage);

        // Schaden am Gegner zufügen
        ExcecuteHit(executingBeast, defendingBeast, this, BattleCalculationService.HitDamage(executingBeast, defendingBeast, this, critTriggered), out string executeHitMessage);

        if (critTriggered)
        {
            moveExecuteMessage = critMessage + "\n" + executeHitMessage;
        }
        else
        {
            moveExecuteMessage = executeHitMessage;
        }

        // TODO: Das hier ist eigentlich das Standard Execute, könnte man vieleicht nochmal so in MoveBase packen um Doppelten Code zu verringern

        return true;
    }

    #endregion // Methods
}