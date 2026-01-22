

using src.Battle;
using src.Move.Base;
using src.StatusEffect;

namespace src.Move.TMs;


public class Struggle : MoveBase
{
    #region Methods

    /// <inheritdoc/>
    public override bool Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, out string moveExecuteMessage, BagBeastObject? switchInBeast = null)
    {
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

        // TODO: Recoil Message

        // 25% Recoil
        executingBeast.CurrentHP =- executingBeast.MAXHP / 4;
        moveExecuteMessage += "\n" + $"{executingBeast.Name} was damaged by recoil!";

        if (executingBeast.CurrentHP == 0)
        {
            moveExecuteMessage += "\n" + StatusEffectService.SetEternalEep(executingBeast);
        }

        // Struggle trifft immer
        return true;

        // INFO: Struggle verliert keine PP und trifft immer
    }

    #endregion // Methods
}