using System;
using BagBeasts.src.Move.Base;
using BagBeasts.src.Item.Base;
using BagBeasts.src.Item.ItemBase;
using BagBeasts.src.Ability.AbilityBase;
using BagBeasts.src.StatusEffect;

public class Sceptile : BagBeastObject
{
    public Sceptile()
    {
        Id = 254;
        Name = "Sceptile"; 

        Type1 = Type.Grass;
        Type2 = Type.Dragon;

        MAXHP = 282;
        ATK = 230;
        SPA = 389;
        DEF = 186;
        SPD = 206;
        INT = 427;

        CurrentHP = MAXHP;        
        Ability = new ToughClaws();

        //Außerdem, bekommt das Ding die Attacke Shed Tail
    }
}