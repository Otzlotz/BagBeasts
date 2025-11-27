using System;

public class BagBeastObject
{
    public int CurrentHP { get; set; }
    public int MAXHP { get; set; }
    public EquippedMove Move1 { get; set; }
    public EquippedMove Move2 { get; set; }
    public EquippedMove Move3 { get; set; }
    public EquippedMove Move4 { get; set; }
    public Item HeldItem { get; set; }
    public Ability Ability { get; set; }
    public int StatusEffect { get; set; }
    public StatChanges StatChange { get; set; }
    public bool Confusion { get; set; }

    public BagBeastObject()
    {
    }
}
