using System;
using System.Collections.Generic;

namespace BagBeasts;

public partial class BagbeastsDB
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Type1 { get; set; }

    public int? Type2 { get; set; }

    public int Hp { get; set; }

    public int Atk { get; set; }

    public int Spa { get; set; }

    public int Def { get; set; }

    public int Spd { get; set; }

    public int Initiative { get; set; }

    public virtual ICollection<MoveDB> Moves { get; set; } = new List<MoveDB>();
}
