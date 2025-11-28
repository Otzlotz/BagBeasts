using System;
using src.Move.Base;
using src.Item.Base;
using src.Item.ItemBase;
using src.Ability.Base;

public class BagBeastObject
{
    public int CurrentHP { get; set; }
    public int MAXHP { get; set; }
    public EquippedMove Move1 { get; set; }
    public EquippedMove Move2 { get; set; }
    public EquippedMove Move3 { get; set; }
    public EquippedMove Move4 { get; set; }
    public ItemBase HeldItem { get; set; }
    public AbilityBase Ability { get; set; }
    public int StatusEffect { get; set; }
    public StatChanges StatChange { get; set; }
    public int Confusion { get; set; }

    public BagBeastObject()
    {
    }
}
