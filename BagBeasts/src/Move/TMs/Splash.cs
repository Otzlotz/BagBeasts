using src.Battle;
using src.Move.Base;
using src.StatusEffect;

namespace src.Move.TMs;

public class Splash : MoveBase
{
    #region Fields

    private Random _rnd;

    #endregion // Fields

    #region Properties

    private Random Rnd = _rnd ??= new Random();

    #endregion // Properties

    #region Methods

    /// <inheritdoc/>
    public override bool Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, BagBeastObject? switchInBeast = null, out string moveExecuteMessage)
    {
        // TODO: Der müsste irgendwie als Singleton angelegt werden
        BattleCalculationService battleCalculationService = new BattleCalculationService();
        StatusEffectService statusEffectService = new StatusEffectService();

        PP--;

        // Prüfen, ob der Angriff trifft
        if (!battleCalculationService.MoveHit(executingBeast, defendingBeast, this, out string moveHitMessage))
        {
            moveExecuteMessage = moveHitMessage;
            return false;
        }

        // Random ermitteln, welcher Statuseffekt ausgelöst wird
        StatusEffectEnum statusEffect = (StatusEffectEnum)Rnd.Next(2, 7);

        return statusEffectService.TryApplyStatusEffekt(defendingBeast, statusEffect, out moveExecuteMessage);
    }

    #endregion // Methods
}