


namespace src.Move.Base;

public abstract class ActionBase
{
    #region Properties
    public uint ID {get; protected set;}

    public string Name{get; protected set;}

    public int Prio{get; protected set;}

    #endregion // Properties

    #region Methods

    /// <summary>
    /// Initialisiert die Aktion mit ihren Daten aus der Datenbank
    /// </summary>
    /// <param name="fromDB">Datenbankobjekt</param>
    public virtual void Init(BagBeasts.Move fromDB)
    {
        ID = (int)fromDB.Id;
        Name = fromDB.Name.Value;
        Prio = fromDB.Prio.Value;
    }

    #endregion // Methods
}