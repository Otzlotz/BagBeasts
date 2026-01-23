using BagBeasts.src.Move.Base;
using BagBeasts.src.StatusEffect;

namespace BagBeasts.src.Item.ItemBase;

public abstract class LifeOrb : DamageModifierItemBase
{
    #region Methods

    /// <summary>
    /// Mehr Schaden für Schaden
    /// </summary>
    /// <param name="holderBeast">Besitzer des Item</param>
    /// <param name="defenderBeast">Angegriffenes Bagbeast</param>
    /// <param name="attackMove">Attacke</param>
    /// <param name="damage">Kalkulierter Schaden</param>
    /// <returns>Neuer Schaden</returns>
    public override decimal ItemEffect(ref BagBeastObject holderBeast, BagBeastObject defenderBeast, MoveBase attackMove, decimal damage)
    {
        damage = damage * 1.3m;
        holderBeast.CurrentHP -= holderBeast.MAXHP / 10;

        if (holderBeast.CurrentHP <= 0)
        {
            StatusEffectService.SetEternalEep(holderBeast);
        }

        return damage;
    }

    #endregion // Methods
}