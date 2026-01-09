using src.StatusEffect;

namespace src.Move.Base;

public abstract class MoveBase : ActionBase
{
    #region Properties 

    public string Description{get; protected set;}

    public uint Damage {get; protected set;} 

    // 0 - 100. Null trifft immer
    public uint? Accuracy {get; protected set;}

    // 1 - 4
    public uint CritChanceTier {get; protected set;}

    public uint PP {get; protected set;}

    public Type Type {get; protected set;}

    public Category Category {get; protected set;}

    public bool Contact {get; protected set;}

    #endregion // Properties

    #region Public Methods

    /// <summary>
    /// Ausführen eines Move
    /// </summary>
    /// <param name="executingBeast">Ausführendes Bagbeast</param>
    /// <param name="defendingBeast">Angegriffenes Bagbeast</param>
    /// <param name="switchInBeast">Optional: Babbeast, welches durch die Attacke (nach dem Angriff) eingewechselt wird</param>
    /// <param name="moveExecuteMessage">OUT: Message der ausführung des Move</param>
    /// <returns>true: Angriff hat getroffen | false: Angriff hat nicht getroffen</returns>
    public abstract bool Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, BagBeastObject? switchInBeast = null, out string moveExecuteMessage);

    /// <summary>
    /// Initialisiert die Aktion mit ihren Daten aus der Datenbank
    /// </summary>
    /// <param name="fromDB">Datenbankobjekt</param>
    public override void Init(BagBeasts.Move fromDB)
    {
        base.Init(fromDB);

        Description = fromDB.Description.Value;
        Damage = (uint)fromDB.Dmg.Value;
        Accuracy = (uint?)fromDB.Acc;
        CritChanceTier = (uint)fromDB.CritChanceTier.Value;
        PP = (uint)fromDB.Pp.Value;
        Type = (Type)fromDB.Type.Value;
        Category = (Category)fromDB.Category.Value;
        Contact = fromDB.Contact.Value;
    }

    #endregion // Public Methods

    #region Protected

    /// <summary>
    /// Führt den Hit mit dem damage aus
    /// </summary>
    /// <param name="executingBeast">Angreifendes Bagbeast</param>
    /// <param name="defendingBeast">Angegriffenes Bagbeast</param>
    /// <param name="move">Angewendeter Move</param>
    /// <param name="damage">Zuvor berechneter Schaden</param>
    /// <param name="executeHitMessage">OUT: Hit Message</param>
    protected void ExcecuteHit(BagBeastObject executingBeast, BagBeastObject defendingBeast, MoveBase move, int damage, out string executeHitMessage)
    {
        // TODO: Der müsste irgendwie als Singleton angelegt werden
        StatusEffectService statusEffectService = new StatusEffectService();

        moveHitMessage = string.Empty;
        defendingBeast.CurrentHP =- damage;

        // TODO: Diese neue Itembase von Tobias für FocusSash hier einbauen. defendingBeast.CurrentHP darf nicht davor auf 0 gesetzt werden!

        if (defendingBeast.CurrentHP == 0)
        {
             executeHitMessage = statusEffectService.SetEternalEep(defendingBeast);
        }

        if (executeHitMessage == string.Empty)
        {
            executeHitMessage = $"{defendingBeast.Name} was hit by {move.Name} for {damage} damage.";
        }
        else
        {
            executeHitMessage += "\n" + $"{defendingBeast.Name} was hit by {move.Name} for {damage} damage.";
        }
    }

    #endregion // Protected
}