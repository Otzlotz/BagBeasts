using System;
using src.Move.Base;
using src.Item.Base;
using src.Item.ItemBase;
using src.Ability.AbilityBase;
using src.StatusEffect;

public class Lapras : BagBeastObject
{
    public Lapras()
    {
        Id = 131;
        Name = "Lapras"; 

        Type1 = Type.Water;
        Type2 = Type.Ice;

        MAXHP = 464;
        ATK = 226;
        SPA = 360;
        DEF = 284;
        SPD = 250;
        INT = 171;

        CurrentHP = MAXHP;
        //Ability = new NoGuard();
    }
}