using System;
using System.ComponentModel.DataAnnotations;

namespace BagBeasts.src.Beast
{
    /// <summary>
    /// Klasse eines BagBeasts aus der Datenbank
    /// </summary>
    public class BagBeast
    {
        #region Properties
        public int ID { get; private set; }
        public string Name { get; private set; }
        public Type Type1 { get; private set; }
        public Type? Type2 { get; private set; }
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
        public BagBeast(string name, int hp, int atk, int spa, int def, int spd, int i, Type type1, Type? typ2 = null, int id = 0)
        {
            Name = name;
            HP = hp;
            ATK = atk;
            SPA = spa;
            DEF = def;
            SPD = spd;
            INT = i;
            Type1 = type1;
            Type2 = typ2;
            ID = id;
        }
    }
}
