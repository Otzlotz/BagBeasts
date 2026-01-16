using System;
using src.Move.Base;
using src.Item.Base;
using src.Item.ItemBase;
using src.Ability.AbilityBase;
using src.StatusEffect;

public class BagBeastObject
{
    #region Fields

    private int _currentHP;

    #endregion // Fields

    #region Properties
    public int Id { get; set;  }
    public string Name { get; set;  }
    public Type Type1 { get; protected set; }
    public Type? Type2 { get; protected set; }
    public int CurrentHP
    {
        get => _currentHP;
        set
        {
            _currentHP = value;

            if (_currentHP <= 0)
            {
                _currentHP = 0;
            }
        }
    }
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
    public StatusEffectEnum StatusEffect { get; set; }
    public int StatusCounter { get; set; }
    public StatChanges StatChange { get; set; }
    public int Confusion { get; set; }

    public BagBeastObject()
    {
        foreach (var move in MoveLocks)
        {
            move = false;
        }
    }
}