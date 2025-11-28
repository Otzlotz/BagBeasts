using System;
using src.Battle

/// <summary>
/// Klasse eines BagBeasts aus der Datenbank
/// </summary>
public class BagBeast
{
    #region Properties
    public string Name { get; private set; }
    public int ID { get; private set; }
    public Typ Type1 { get; private set; }
    public Typ? Type2 { get; private set; }
    public int HP { get; private set; }
    public int ATK { get; private set; }
    public int SPA { get; private set; }
    public int DEF { get; private set; }
    public int SPD { get; private set; }
    public int INT { get; private set; }
    #endregion // Properties

    /// <summary>
    /// Konstruktor
    /// </summary>
    public BagBeast()
    {

    }

}
