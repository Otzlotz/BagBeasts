namespace src.Move.Base;

public abstract class MoveBase : ActionBase
{
    #region Properties 

    public abstract uint Damage {get;}

    // 0 - 100. Null trifft immer
    public abstract uint? Accuracy {get;}

    public abstract uint CritChanceTier {get;}

    public abstract uint PP {get;}

    public abstract Type Type {get;}

    public abstract Category Category {get;}

    public abstract bool Contact {get;}

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

    #endregion // Methods
}