

using BagBeasts.src.Battle;
using BagBeasts.src.Move.Base;

namespace BagBeasts.src.Ability.AbilityBase;

public abstract class Intimidate : SwitchInAbilityBase
{
    #region Methods

    /// <summary>
    /// Effekt für Abilities nach der Schadenskalkulation
    /// </summary>
    /// <param name="holderBeast">Besitzer der Ability</param>
    /// <param name="defenderBeast">Angegriffenes Bagbeast</param>
    /// <param name="attackMove">Attacke</param>
    /// <param name="damage">Kalkulierter Schaden</param>
    /// <returns>Neuer Schaden</returns>
    public override string AbilityEffect(BagBeastObject holderBeast, BagBeastObject defenderBeast)
    {
        var resultMessage = StatChangeService.ChangeAtk(defenderBeast, -1);
        return resultMessage;
    }

    #endregion // Methods
}