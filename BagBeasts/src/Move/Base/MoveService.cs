



using src.Move.TMs;

namespace src.Move.Base;

public static class MoveService
{
    #region Fields

    private static Random _rnd;

    #endregion // Fields

    #region Properties

    private static Random Rnd {get; set;} = _rnd ??= new Random();

    #endregion // Properties

    #region Public Method

    /// <summary>
    /// Erstellt aus dem Datenbankeintrag "Move" ein Objekt mit der passenden Klasse (löst auch dessen Init() Methode aus!)
    /// </summary>
    /// <param name="fromDB">Datenbankobjekt</param>
    /// <returns>Gefülltes ActionBase Objekt</returns>
    public static ActionBase CreateActionObject(BagBeasts.Move fromDB)
    {
        // Objekt erstellen
        ActionBase action = GetObject((uint)fromDB.Id);

        // TODO: Testen ob das funktioniert, dass der bei Attacken das Init aus MoveBase statt aus ActionBase nutzt

        // Objekt initialisieren
        action.Init(fromDB);

        return action;
    }

    #endregion // Public Method

    #region Private Method

    /// <summary>
    /// Ermittelt anhand der MoveId die Klasse der Aktion und gibt ein Objekt dieser zurück
    /// </summary>
    /// <param name="id">ID des Move</param>
    /// <returns>Passendes Objekt der Klasse</returns>
    private static ActionBase GetObject(uint id)
    {
        // TODO: Diese Moves fehlen noch: Delegator (9), Schlafrede (18) (vielleicht ganz weg lassen), Schwanzabwurf (24), Schutzschild (43), Abgangsbund (47), Ausdauer (56)

        switch (id)
        {
            case 0:
            return new Struggle();

            case 1:
            return new Switch();

            case 2:
            return new Return();

            case 3:
            return new  Splash();

            case 4:
            return new Waterfall();

            case 5:
            return new Crunch();

            case 6:
            return new DragonDance();

            case 7:
            return new Avalanche();

            case 8:
            return new IronHead();

            case 10:
            return new Earthquake();

            case 11:
            return new StoneEdge();

            case 12:
            return new ThunderWave();

            case 13:
            return new DragonClaw();

            case 14:
            return new HydroPump();

            case 15:
            return new Blizzard();

            case 16:
            return new ConfuseRay();

            case 17:
            return new Rest();

            case 19:
            return new Thunder();

            case 20:
            return new MuddyWater();

            case 21:
            return new AlluringVoice();

            case 22:
            return new Psychic();

            case 23:
            return new DragonPulse();

            case 25:
            return new LeafBlade();

            case 26:
            return new GigaDrain();

            case 27:
            return new LeafStorm();

            case 28:
            return new Endeavor();

            case 29:
            return new EnergyBall();

            case 30:
            return new XScissor();

            case 31:
            return new QuickAttack();

            case 32:
            return new SwordsDance();

            case 33:
            return new VacuumWave();

            case 34:
            return new ThunderWave();

            case 35:
            return new Superpower();

            case 36:
            return new DoubleEdge();

            case 37:
            return new PlayRough();

            case 38:
            return new Trailblaze();

            case 39:
            return new Facade();

            case 40:
            return new IceSpinner();

            case 41:
            return new Bulldoze();

            case 42:
            return new Liquidation();

            case 44:
            return new KnockOff();

            case 45:
            return new AquaJet();

            case 46:
            return new ShadowForce();

            case 48:
            return new ShadowClaw();

            case 49:
            return new Hex();

            case 50:
            return new AuraSphere();

            case 51:
            return new EarthPower();

            case 52:
            return new PainSplit();

            case 53:
            return new ShadowSneak();

            case 54:
            return new WillOWisp();

            case 55:
            return new Frostbite();

            case 57:
            return new Thunderbolt();

            case 58:
            return new ShadowBall();

            case 59:
            return new DarkPulse();

            default:
            return new Struggle();
        }
    }

    #endregion // Private Method
}