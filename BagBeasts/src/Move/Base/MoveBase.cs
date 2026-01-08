namespace src.Move.Base;

public abstract class MoveBase : ActionBase
{
    #region Properties 

    public uint Damage {get; protected set;} 

    // 0 - 100. Null trifft immer
    public uint? Accuracy {get; protected set;}

    public uint CritChanceTier {get; protected set;}

    public uint PP {get; protected set;}

    public Type Type {get; protected set;}

    public Category Category {get; protected set;}

    public bool Contact {get; protected set;}

    #endregion // Properties

    #region Methods

    /// <summary>
    /// Ausführen eines Move
    /// </summary>
    /// <param name="executingBeast">Ausführendes Bagbeast</param>
    /// <param name="defendingBeast">Angegriffenes Bagbeast</param>
    /// <param name="switchInBeast">Optional: Babbeast, welches durch die Attacke (nach dem Angriff) eingewechselt wird</param>
    /// <returns>true: Angriff hat getroffen | false: Angriff hat nicht getroffen</returns>
    public abstract bool Execute(BagBeastObject executingBeast, BagBeastObject defendingBeast, BagBeastObject? switchInBeast = null);

    public void Init(BagBeasts.Move fromDB)
    {
        // pass
    }

    #endregion // Methods
}