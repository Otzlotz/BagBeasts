using System;
using src.Move.Base;
using src.Item.Base;
using src.Item.ItemBase;
using src.Ability.Base;
using src.StatusEffect;

public class BagBeastObject
{
    public readonly int Id { get; }
    public readonly string Name { get; }
    public Typ Type1 { get; private set; }
    public Typ? Type2 { get; private set; }
    public int CurrentHP { get; set; }
    public int MAXHP { get; set; }
    public int ATK { get; set; }
    public int SPA { get; set; }
    public int DEF { get; set; }
    public int SPD { get; set; }
    public int INT { get; set; }
    public EquippedMove Move1 { get; set; }
    public EquippedMove Move2 { get; set; }
    public EquippedMove Move3 { get; set; }
    public EquippedMove Move4 { get; set; }
    public ItemBase HeldItem { get; set; }
    public AbilityBase Ability { get; set; }
    public StatusEffect StatusEffect { get; set; }
    public int StatusCounter { get; set; }
    public StatChanges StatChange { get; set; }
    public int Confusion { get; set; }

    public BagBeastObject()
    {
    }
}