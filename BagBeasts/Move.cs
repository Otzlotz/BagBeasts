using System;
using System.Collections.Generic;

namespace BagBeasts;

public partial class Move
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Bagbeasts> Bagbeasts { get; set; } = new List<Bagbeasts>();
}
