using System;
using System.Collections.Generic;

namespace BagBeasts;

public partial class TypeDB
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MoveDB> Moves { get; set; } = new List<MoveDB>();
}
