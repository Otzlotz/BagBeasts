


namespace BagBeasts.src.Move.Base;

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
    public virtual void Init(Entities.Move fromDB)
    {
        ID = (uint)fromDB.Id;
        Name = fromDB.Name;
        Prio = fromDB.Prio.Value;
    }

    #endregion // Methods
}