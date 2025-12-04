

namespace src.StatusEffect;


/// <summary>
/// Methoden für Statuseffekte
/// </summary>
public class StatusEffectService
{
    #region Public Methods

    /// <summary>
    /// Versucht dem Bagbeast einen Statuseffekt anzuwenden
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <param name="statusEffect">Anzuwendender Statuseffekt</param>
    /// <returns>Ob der Statuseffekt erfolgreich ausgelöst wurde</returns>
    public bool TryApplyStatusEffekt(BagBeastObject bagBeastObject, StatusEffect statusEffect)
    {
        // TODO: Die verschiedenen Interaktionen müssen noch in den Battlelog geschrieben werden

        // TODO: Soll EternalEep auch hier angewendet werden?

        // Ein Bagbeast kann nur einen Primären Statuseffekt gleichzeitig haben!
        if (bagBeastObject.StatusEffect != StatusEffect.No)
        {
            return false;
        }

        switch (statusEffect)
        {
            case StatusEffect.Eep:
                return TryApplyEep(bagBeastObject);

            case StatusEffect.Paralysis:
                return TryApplyParalysis(bagBeastObject);

            case StatusEffect.Poison:
                return TryApplyPoison(bagBeastObject);

            case StatusEffect.Toxic:
                return TryApplyToxic(bagBeastObject);

            case StatusEffect.Burn:
                return TryApplyBurn(bagBeastObject);

            case StatusEffect.FrostBurn:
                return TryApplyFrostBurn(bagBeastObject);
        }

        return false;
    }

    /// <summary>
    /// Entfernt den aktuellen Statuseffekt des Bagbeast
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    public void RemoveStatusEffect(BagBeastObject bagBeastObject)
    {
        if (bagBeastObject.StatusEffect == StatusEffect.EternalEep)
        {
            return;
        }

        bagBeastObject.StatusEffect = StatusEffect.No;
        bagBeastObject.StatusEffectCounter = 0;
    }

    /// <summary>
    /// Löst den Statuseffekt des Bagbeast aus (sofern es einen hat)
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <returns>Ob das Bagbeast durch den Statuseffekt Stunned ist</returns>
    /// <remarks>Kann die HP des Bagbeast auf 0 setzen, löst aber nicht selber den EternalEep aus</remarks>
    public bool TriggerStatusEffect(BagBeastObject bagBeastObject)
    {
        switch (bagBeastObject.StatusEffect)
        {
            case StatusEffect.Eep:
                return TriggerEep(bagBeastObject);

            case StatusEffect.Paralysis:
                return TriggerParalysis(bagBeastObject);

            case StatusEffect.Poison:
                return TriggerPoison(bagBeastObject);

            case StatusEffect.Toxic:
                return TriggerToxic(bagBeastObject);

            case StatusEffect.Burn:
                return TriggerBurn(bagBeastObject);

            case StatusEffect.FrostBurn:
                return TriggerFrostBurn(bagBeastObject);
        }

        // TODO: Soll EternalEep true zurückgeben

        return false;
    }

    #endregion // Public Methods

    #region Private Methods

    #region TryApply

    /// <summary>
    /// Versucht den Statuseffekt <see cref="StatusEffect.Eep"/> auf das Bagbeast anzuwenden
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <returns>Ob der Statuseffekt erfolgreich ausgelöst wurde</returns>
    private bool TryApplyEep(BagBeastObject bagBeastObject)
    {
        bagBeastObject.StatusEffect = StatusEffect.Eep;
        //bagBeastObject.StatusEffectCounter = ;

        // TODO: Counter Random zwischen 1 - 3 setzen

        return true;
    }

    /// <summary>
    /// Versucht den Statuseffekt <see cref="StatusEffect.Paralysis"/> auf das Bagbeast anzuwenden
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <returns>Ob der Statuseffekt erfolgreich ausgelöst wurde</returns>
    private bool TryApplyParalysis(BagBeastObject bagBeastObject)
    {
        bagBeastObject.StatusEffect = StatusEffect.Paralysis;

        return true;
    }

    /// <summary>
    /// Versucht den Statuseffekt <see cref="StatusEffect.Poison"/> auf das Bagbeast anzuwenden
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <returns>Ob der Statuseffekt erfolgreich ausgelöst wurde</returns>
    private bool TryApplyPoison(BagBeastObject bagBeastObject)
    {
        bagBeastObject.StatusEffect = StatusEffect.Poison;

        return true;
    }

    /// <summary>
    /// Versucht den Statuseffekt <see cref="StatusEffect.Toxic"/> auf das Bagbeast anzuwenden
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <returns>Ob der Statuseffekt erfolgreich ausgelöst wurde</returns>
    private bool TryApplyToxic(BagBeastObject bagBeastObject)
    {
        bagBeastObject.StatusEffect = StatusEffect.Toxic;
        bagBeastObject.StatusEffectCounter = 1;

        return true;
    }

    /// <summary>
    /// Versucht den Statuseffekt <see cref="StatusEffect.Burn"/> auf das Bagbeast anzuwenden
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <returns>Ob der Statuseffekt erfolgreich ausgelöst wurde</returns>
    private bool TryApplyBurn(BagBeastObject bagBeastObject)
    {
        bagBeastObject.StatusEffect = StatusEffect.Burn;

        return true;
    }

    /// <summary>
    /// Versucht den Statuseffekt <see cref="StatusEffect.FrostBurn"/> auf das Bagbeast anzuwenden
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <returns>Ob der Statuseffekt erfolgreich ausgelöst wurde</returns>
    private bool TryApplyFrostBurn(BagBeastObject bagBeastObject)
    {
        bagBeastObject.StatusEffect = StatusEffect.FrostBurn;

        return true;
    }

    #endregion // TryApply

    #region Trigger

    // TODO: Am Ende schauen ob man die ganzen Trigger Methoden die das selbe machen in eine Methode Stecken möchte

    /// <summary>
    /// Löst <see cref="StatusEffect.Eep"/> für das Bagbeast aus
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <returns>Ob das Bagbeast durch den Statuseffekt Stunned ist</returns>
    private bool TriggerEep(BagBeastObject bagBeastObject)
    {
        if (bagBeastObject.StatusEffectCounter == 0)
        {
            RemoveStatusEffect(bagBeastObject);
            return false;
        }
        else
        {
            bagBeastObject.StatusEffectCounter--;
            return true;
        }
    }

    /// <summary>
    /// Löst <see cref="StatusEffect.Paralysis"/> für das Bagbeast aus
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <returns>Ob das Bagbeast durch den Statuseffekt Stunned ist</returns>
    private bool TriggerParalysis(BagBeastObject bagBeastObject)
    {
        // TODO: Random 25% Chance nicht anzugreifen

        // 25% Chance nicht anzugreifen
        if (true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Löst <see cref="StatusEffect.Poison"/> für das Bagbeast aus
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <returns>Ob das Bagbeast durch den Statuseffekt Stunned ist</returns>
    private bool TriggerPoison(BagBeastObject bagBeastObject)
    {
        decimal damage = bagBeastObject.MAXHP / 8;

        // TODO: Abrunden auf ganze Zahl und mindestens 1 schaden

        // TODO:Unsicher ob das auslösen des Damage doch eine eigene Methode bekommt (in einem anderen Service)

        bagBeastObject.CurrentHP =- damage;

        if (bagBeastObject.CurrentHP < 0)
        {
            bagBeastObject.CurrentHP = 0;
        }
    }

    /// <summary>
    /// Löst <see cref="StatusEffect.Toxic"/> für das Bagbeast aus
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <returns>Ob das Bagbeast durch den Statuseffekt Stunned ist</returns>
    private bool TriggerToxic(BagBeastObject bagBeastObject)
    {
        decimal damage = bagBeastObject.MAXHP / 16 * bagBeastObject.StatusEffectCounter;

        // TODO: Abrunden auf ganze Zahl und mindestens 1 schaden

        // TODO:Unsicher ob das auslösen des Damage doch eine eigene Methode bekommt (in einem anderen Service)

        bagBeastObject.CurrentHP =- damage;

        if (bagBeastObject.CurrentHP < 0)
        {
            bagBeastObject.CurrentHP = 0;
        }
    }

    /// <summary>
    /// Löst <see cref="StatusEffect.Burn"/> für das Bagbeast aus
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <returns>Ob das Bagbeast durch den Statuseffekt Stunned ist</returns>
    private bool TriggerBurn(BagBeastObject bagBeastObject)
    {
        decimal damage = bagBeastObject.MAXHP / 8;

        // TODO: Abrunden auf ganze Zahl und mindestens 1 schaden

        // TODO:Unsicher ob das auslösen des Damage doch eine eigene Methode bekommt (in einem anderen Service)

        bagBeastObject.CurrentHP =- damage;

        if (bagBeastObject.CurrentHP < 0)
        {
            bagBeastObject.CurrentHP = 0;
        }
    }

    /// <summary>
    /// Löst <see cref="StatusEffect.FrostBurn"/> für das Bagbeast aus
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <returns>Ob das Bagbeast durch den Statuseffekt Stunned ist</returns>
    private bool TriggerFrostBurn(BagBeastObject bagBeastObject)
    {
        decimal damage = bagBeastObject.MAXHP / 8;

        // TODO: Abrunden auf ganze Zahl und mindestens 1 schaden

        // TODO:Unsicher ob das auslösen des Damage doch eine eigene Methode bekommt (in einem anderen Service)

        bagBeastObject.CurrentHP =- damage;

        if (bagBeastObject.CurrentHP < 0)
        {
            bagBeastObject.CurrentHP = 0;
        }
    }

    #endregion // Trigger

    #endregion // Private Methods
}