using System;

namespace BagBeasts.src.StatusEffect;


/// <summary>
/// Methoden für Statuseffekte
/// </summary>
public static class StatusEffectService
{
    #region Public Methods

    #region Primary Status

    /// <summary>
    /// Entfernt den aktuellen Statuseffekt des Bagbeast
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <param name="statusMessage">OUT: Message was passiert (string.Empty, wenn nichts passiert)</param>
    public static void RemoveStatusEffect(BagBeastObject bagBeastObject, out string statusMessage)
    {
        statusMessage = string.Empty;
        switch (bagBeastObject.StatusEffect)
        {
            case StatusEffectEnum.Eep:
                statusMessage = $"{bagBeastObject.Name} woke up!";
                break;

            case StatusEffectEnum.Paralysis:
                statusMessage = $"{bagBeastObject.Name} paralysis was removed!";
                break;

            case StatusEffectEnum.Poison:
                statusMessage = $"{bagBeastObject.Name} poison was removed!";
                break;

            case StatusEffectEnum.Toxic:
                statusMessage = $"{bagBeastObject.Name} toxic was removed!";
                break;

            case StatusEffectEnum.Burn:
                statusMessage = $"{bagBeastObject.Name} burn was removed!";
                break;

            case StatusEffectEnum.FrostBurn:
                statusMessage = $"{bagBeastObject.Name} frostburn was removed!";
                break;
        }

        bagBeastObject.StatusEffect = StatusEffectEnum.No;
        bagBeastObject.StatusCounter = 0;
    }

    /// <summary>
    /// Versucht auf dem Bagbeast einen Statuseffekt anzuwenden
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <param name="statusEffect">Anzuwendender Statuseffekt</param>
    /// <param name="statusMessage">OUT: Message was passiert</param>
    /// <returns>Ob der Statuseffekt erfolgreich angewendet wurde</returns>
    public static bool TryApplyStatusEffekt(BagBeastObject bagBeastObject, StatusEffectEnum statusEffect, out string statusMessage)
    {
        // Ein Bagbeast kann nur einen Primären Statuseffekt gleichzeitig haben!
        if (bagBeastObject.StatusEffect != StatusEffectEnum.No)
        {
            statusMessage = $"{bagBeastObject.Name} already has a statuseffect!";
            return false;
        }

        // Statuseffekt anwenden
        switch (statusEffect)
        {
            case StatusEffectEnum.Eep:
                // Schläft 1 - 3 Runden
                bagBeastObject.StatusEffect = StatusEffectEnum.Eep;
                Random Rnd = new();
                bagBeastObject.StatusCounter = Rnd.Next(2, 4);
                statusMessage = $"{bagBeastObject.Name} makes a wittle nappy :3";
                return true;

            case StatusEffectEnum.Paralysis:
                if (bagBeastObject.Type1 == TypeDB.Electric || bagBeastObject.Type2 == TypeDB.Electric)
                {
                    statusMessage = $"{bagBeastObject.Name} can not be paralysed!";
                    return false;
                }
                else
                {
                    bagBeastObject.StatusEffect = StatusEffectEnum.Paralysis;
                    statusMessage = $"{bagBeastObject.Name} became paralysed!";
                    return true;
                }

            case StatusEffectEnum.Poison:
                if (bagBeastObject.Type1 == TypeDB.Poison || bagBeastObject.Type2 == TypeDB.Poison)
                {
                    statusMessage = $"{bagBeastObject.Name} can not be poisoned!";
                    return false;
                }
                else
                {
                    bagBeastObject.StatusEffect = StatusEffectEnum.Poison;
                    statusMessage = $"{bagBeastObject.Name} became poisoned!";
                    return true;
                }


            case StatusEffectEnum.Toxic:
                if (bagBeastObject.Type1 == TypeDB.Poison || bagBeastObject.Type2 == TypeDB.Poison)
                {
                    statusMessage = $"{bagBeastObject.Name} can not be poisoned!";
                    return false;
                }
                else
                {
                    bagBeastObject.StatusEffect = StatusEffectEnum.Toxic;
                    bagBeastObject.StatusCounter = 1;
                    statusMessage = $"{bagBeastObject.Name} became badly poisoned!";
                    return true;
                }

            case StatusEffectEnum.Burn:
                bagBeastObject.StatusEffect = StatusEffectEnum.Burn;
                statusMessage = $"{bagBeastObject.Name} was burned!";
                return true;

            case StatusEffectEnum.FrostBurn:
                bagBeastObject.StatusEffect = StatusEffectEnum.FrostBurn;
                statusMessage = $"{bagBeastObject.Name} was burned (but in cool)!";
                return true;
        }
        statusMessage = string.Empty;
        return false;
    }

    /// <summary>
    /// Löst den Statuseffekt des Bagbeast aus (sofern es einen hat)
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <param name="statusMessage">OUT: Message was passiert (String.Empty, wenn es keinen Status Effekt hat)</param>
    /// <returns>Ob das Bagbeast durch den Statuseffekt Stunned ist oder in EternalEep gefallen ist</returns>
    /// <remarks>Kann die HP des Bagbeast auf 0 setzen, löst aber nicht selber den EternalEep aus!</remarks>
    public static bool TriggerStatusEffect(BagBeastObject bagBeastObject, out string statusMessage)
    {
        switch (bagBeastObject.StatusEffect)
        {
            case StatusEffectEnum.Eep:
                return TriggerEep(bagBeastObject, out statusMessage);

            case StatusEffectEnum.Paralysis:
                return TriggerParalysis(bagBeastObject, out statusMessage);

            case StatusEffectEnum.Poison:
                return TriggerPoison(bagBeastObject, out statusMessage);

            case StatusEffectEnum.Toxic:
                return TriggerToxic(bagBeastObject, out statusMessage);

            case StatusEffectEnum.Burn:
                return TriggerBurn(bagBeastObject, out statusMessage);

            case StatusEffectEnum.FrostBurn:
                return TriggerFrostBurn(bagBeastObject, out statusMessage);
        }
        statusMessage = string.Empty;
        return false;
    }

    /// <summary>
    /// Setzt den Status des Bagbeast auf <see cref="StatusEffectEnum.EternalEep"/>
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <returns>Message, dass das Bagbeast in EternalEep gefallen ist</returns>
    public static string SetEternalEep(BagBeastObject bagBeastObject)
    {
        bagBeastObject.StatusEffect = StatusEffectEnum.EternalEep;

        // Sicherheitshalber die HP auf 0 setzen
        bagBeastObject.CurrentHP = 0;

        // Ein paar Properties anpassen
        bagBeastObject.Confusion = 0;
        bagBeastObject.StatusCounter = 0;

        // Message zurückgeben
        return $"{bagBeastObject} has fallen into eternal eep!";
    }

    #endregion // Primary Status

    #region Confusion

    /// <summary>
    /// Entfernt Verwirrung des Bagbeast
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <param name="statusMessage">OUT: Message was passiert (String.Empty, wenn es nicht verwirrt war)</param>
    public static void RemoveConfusion(BagBeastObject bagBeastObject, out string statusMessage)
    {
        if (bagBeastObject.Confusion == 0)
        {
            statusMessage = string.Empty;
            return;
        }

        statusMessage = $"{bagBeastObject.Name} is no longer confused!";
        bagBeastObject.Confusion = 0;
    }

    /// <summary>
    /// Versucht auf dem Bagbeast Verwirrung anzuwenden
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <param name="statusMessage">OUT: Message was passiert</param>
    /// <returns>Ob die Verwirrung erfolgreich angewendet wurde</returns>
    public static bool TryApplyConfusion(BagBeastObject bagBeastObject, out string statusMessage)
    {
        // Wer schon verwirrt ist, kann nicht nochmal verwirrt werden
        if (bagBeastObject.Confusion > 0)
        {
            statusMessage = $"{bagBeastObject.Name} is already confused!";
            return false;
        }

        // Muss 2 - 5 Runden halten (muss also eine Random Zahl von 3 - 6 Berechnen)
        Random Rnd = new();
        bagBeastObject.Confusion = Rnd.Next(3, 6);

        statusMessage = $"{bagBeastObject.Name} was confused!";
        return true;
    }

    /// <summary>
    /// Löst Verwirrung aus (sofern es verwirrt ist)
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <param name="statusMessage">OUT: Message was passiert (String.Empty, wenn es nicht Verwirrt war)</param>
    /// <returns>Ob das Bagbeast durch die Verwirrung Stunned ist (oder in EternalEep gefallen ist)</returns>
    public static bool TriggerConfusion(BagBeastObject bagBeastObject, out string statusMessage)
    {
        // Prüfen, ob das Bagbeast überhaupt verwirrt ist
        if (bagBeastObject.Confusion == 0)
        {
            statusMessage = string.Empty;
            return false;
        }

        statusMessage = $"{bagBeastObject.Name} is confused!";
        bagBeastObject.Confusion--;

        if (bagBeastObject.Confusion == 0)
        {
            RemoveConfusion(bagBeastObject, out string removeConfusionMessage);
            statusMessage += "\n" + removeConfusionMessage;
            return false;
        }
        else
        {
            Random rnd = new Random();

            // 33% Chance sich selbst Schaden zuzufügen
            if (rnd.Next(1, 3) == 1)
            {
                statusMessage += "\n" + $"{bagBeastObject.Name} hurt itself in confusion!";

                // Damage abrunden auf ganze Zahl und mindestens 1 schaden
                bagBeastObject.CurrentHP =- RoundDownAndAtLeast1(bagBeastObject.MAXHP / 8);

                if (bagBeastObject.CurrentHP == 0)
                {
                    statusMessage += "\n" + StatusEffectService.SetEternalEep(bagBeastObject);
                }

                return true;
            }
            else
            {
                return false;
            }
            
        }
    }

    #endregion // Confusion

    #endregion // Public Methods

    #region Private Methods

    #region Trigger

    /// <summary>
    /// Löst <see cref="StatusEffectEnum.Eep"/> für das Bagbeast aus
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <param name="statusMessage">OUT: Message was passiert</param>
    /// <returns>Ob das Bagbeast durch den Statuseffekt Stunned ist</returns>
    private static bool TriggerEep(BagBeastObject bagBeastObject, out string statusMessage)
    {
        bagBeastObject.StatusCounter--;

        if (bagBeastObject.StatusCounter == 0)
        {
            RemoveStatusEffect(bagBeastObject, out statusMessage);
            return false;
        }
        else
        {
            statusMessage = $"{bagBeastObject.Name} is fast asleep!";
            return true;
        }
    }

    /// <summary>
    /// Löst <see cref="StatusEffectEnum.Paralysis"/> für das Bagbeast aus
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <param name="statusMessage">OUT: Message was passiert</param>
    /// <returns>Ob das Bagbeast durch den Statuseffekt Stunned ist</returns>
    private static bool TriggerParalysis(BagBeastObject bagBeastObject, out string statusMessage)
    {
        statusMessage = $"{bagBeastObject.Name} is paralysed!";

        // 25% Chance nicht anzugreifen
        Random Rnd = new();
        if (Rnd.Next(1, 4) == 1)
        {
            statusMessage = statusMessage + "\n" + $"{bagBeastObject.Name} is unable to move!";
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Löst <see cref="StatusEffectEnum.Poison"/> für das Bagbeast aus
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <param name="statusMessage">OUT: Message was passiert</param>
    /// <returns>Ob das Bagbeast durch den Statuseffekt in EternalEep fällt</returns>
    private static bool TriggerPoison(BagBeastObject bagBeastObject, out string statusMessage)
    {
        // Damage abrunden auf ganze Zahl und mindestens 1 schaden
        bagBeastObject.CurrentHP =- RoundDownAndAtLeast1(bagBeastObject.MAXHP / 8);
        
        statusMessage = $"{bagBeastObject.Name} was hurt by poison!";

        if (bagBeastObject.CurrentHP == 0)
        {
            statusMessage += "\n" + SetEternalEep(bagBeastObject);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Löst <see cref="StatusEffectEnum.Toxic"/> für das Bagbeast aus
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <param name="statusMessage">OUT: Message was passiert</param>
    /// <returns>Ob das Bagbeast durch den Statuseffekt in EternalEep fällt</returns>
    private static bool TriggerToxic(BagBeastObject bagBeastObject, out string statusMessage)
    {
        // Damage abrunden auf ganze Zahl und mindestens 1 schaden
        bagBeastObject.CurrentHP =- RoundDownAndAtLeast1(bagBeastObject.MAXHP / 16 * bagBeastObject.StatusCounter);

        statusMessage = $"{bagBeastObject.Name} was hurt by strong poison!";

        if (bagBeastObject.CurrentHP == 0)
        {
            statusMessage += "\n" + SetEternalEep(bagBeastObject);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Löst <see cref="StatusEffectEnum.Burn"/> für das Bagbeast aus
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <param name="statusMessage">OUT: Message was passiert</param>
    /// <returns>Ob das Bagbeast durch den Statuseffekt in EternalEep fällt</returns>
    private static bool TriggerBurn(BagBeastObject bagBeastObject, out string statusMessage)
    {
        // Damage abrunden auf ganze Zahl und mindestens 1 schaden
        bagBeastObject.CurrentHP =- RoundDownAndAtLeast1(bagBeastObject.MAXHP / 8);

        statusMessage = $"{bagBeastObject.Name} was hurt by burn!";

        if (bagBeastObject.CurrentHP == 0)
        {
            statusMessage += "\n" + SetEternalEep(bagBeastObject);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Löst <see cref="StatusEffectEnum.FrostBurn"/> für das Bagbeast aus
    /// </summary>
    /// <param name="bagBeastObject">Bagbeast</param>
    /// <param name="statusMessage">OUT: Message was passiert</param>
    /// <returns>Ob das Bagbeast durch den Statuseffekt in EternalEep fällt</returns>
    private static bool TriggerFrostBurn(BagBeastObject bagBeastObject, out string statusMessage)
    {
        // Damage abrunden auf ganze Zahl und mindestens 1 schaden
        bagBeastObject.CurrentHP =- RoundDownAndAtLeast1(bagBeastObject.MAXHP / 8);

        statusMessage = $"{bagBeastObject.Name} was hurt by burn (but cooler)!";

        if (bagBeastObject.CurrentHP == 0)
        {
            statusMessage += "\n" + SetEternalEep(bagBeastObject);
            return true;
        }
        
        return false;
    }

    #endregion // Trigger

    #region Hilfsmethoden

    /// <summary>
    /// Rundet <see cref="number"/> ab und gibt diese zurück. Es wird mindestens 1 zurückgegeben
    /// </summary>
    /// <param name="number">zu rundene Nummer</param>
    /// <returns>Gerundete Nummer</returns>
    private static int RoundDownAndAtLeast1(decimal number)
    {
        int roundedNumber = (int)number;

        if (roundedNumber == 0)
        {
            roundedNumber = 1;
        }

        return roundedNumber;
    }

    #endregion // Hilfsmethoden

    #endregion // Private Methods
}