using System;
using BagBeasts.src.Move.Base;
using BagBeasts.src.Item.Base;
using BagBeasts.src.Item.ItemBase;
using BagBeasts.src.Ability.AbilityBase;
using BagBeasts.src.StatusEffect;

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