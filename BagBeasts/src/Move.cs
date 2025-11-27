using System;

/// <summary>
/// Attacken Klasse
/// </summary>
public class Move
{
    #region Fields
    #endregion // Fields

    #region Properties
    public Typ Typing { get; private set; }
    public string Name { get; private set; }
    public Sonderbullshit Sonder {  get; private set; }
    public int? BaseDMG { get; private set; }
    public decimal FlinchChance { get; private set; }
    public int MAXPP {  get; private set; }
    public string Description { get; private set; }
    public decimal ACC { get; private set; }
    public decimal Recoil { get; private set; }
    public bool EnemyAffected { get; private set; }
    public StatChanges StatChanges { get; private set; }
    public decimal ChangeChance { get; private set; }

    #endregion // Properties 

    /// <summary>
    /// Konstruktor
    /// </summary>
    public Move()
	{
	}
}
