using src.Battle;
using src.Move.Base;
using src.StatusEffect;

namespace src.Move.TMs;

public class Splash : MoveBase
{
    #region Methods

    /// <inheritdoc/>
    public override bool Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, BagBeastObject? switchInBeast = null)
    {
        // TODO: Der müsste irgendwie als Singleton angelegt werden
        BattleCalculationService battleCalculationService = new BattleCalculationService();
        StatusEffectService statusEffectService = new StatusEffectService();

        PP--;

        // Prüfen, ob der Angriff trifft
        if (!battleCalculationService.MoveHit())
        {
            return false;
        }

        // TODO: Irgendwie StatusEffect.StatusEffect, trotz des using oben. Robin fixt das schon

        // Random ermitteln, welcher Statuseffekt ausgelöst wird
        Random rnd = new Random();
        StatusEffect.StatusEffect statusEffect = (StatusEffect.StatusEffect)rnd.Next(2, 7);

        return statusEffectService.TryApplyStatusEffekt(defendingBeast, statusEffect);
    }

    #endregion // Methods
}