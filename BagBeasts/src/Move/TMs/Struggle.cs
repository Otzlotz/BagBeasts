

using src.Battle;
using src.Move.Base;
using src.StatusEffect;

namespace src.Move.TMs;


public class Struggle : MoveBase
{
    #region Methods

    /// <inheritdoc/>
    public override bool Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, BagBeastObject? switchInBeast = null)
    {
        // TODO: Der müsste irgendwie als Singleton angelegt werden
        BattleCalculationService battleCalculationService = new BattleCalculationService();

        // Prüfen, ob ein Krit ausgelöst wird
        bool critTriggered = battleCalculationService.CritTriggered(CritChanceTier);

        // Schaden am Gegner zufügen
        defendingBeast.CurrentHP =- battleCalculationService.HitDamage(executingBeast, defendingBeast, this, critTriggered);

        if (defendingBeast.CurrentHP == 0)
        {
             // TODO: Irgendwie StatusEffect.StatusEffect, trotz des using oben. Robin fixt das schon
             defendingBeast.StatusEffect = StatusEffect.StatusEffectEnum.EternalEep;
        }

        // 25% Recoil
        executingBeast.CurrentHP =- executingBeast.MAXHP / 4;

        if (executingBeast.CurrentHP == 0)
        {
             // TODO: Irgendwie StatusEffect.StatusEffect, trotz des using oben. Robin fixt das schon
            executingBeast.StatusEffect = StatusEffect.StatusEffectEnum.EternalEep;
        }

        // Struggle trifft immer
        return true;

        // INFO: Struggle verliert keine PP und trifft immer
    }

    #endregion // Methods
}