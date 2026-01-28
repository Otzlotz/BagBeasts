using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BagBeasts.Entities;

public partial class Move
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Dmg { get; set; }

    [Column("Acc")]
    public int? Acc { get; set; }

    public int? CritChanceTier { get; set; }

    public int? Pp { get; set; }

    public int? Kind { get; set; }

    public int? Category { get; set; }

    public int? Contact { get; set; }

    public int? Prio { get; set; }

    public int? Type { get; set; }
}
