using System;
using System.Collections.Generic;

namespace BagBeasts;

public partial class MoveDB
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Dmg { get; set; }

    public int? Acc { get; set; }

    public int? CritChanceTier { get; set; }

    public int? Pp { get; set; }

    public int? Type { get; set; }

    public int? Category { get; set; }

    public bool? Contact { get; set; }

    public int? Prio { get; set; }

    public virtual TypeDB? TypeNavigation { get; set; }

    public virtual ICollection<BagbeastsDB> Bagbeasts { get; set; } = new List<BagbeastsDB>();
}
