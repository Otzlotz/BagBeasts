using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BagBeasts.Entities;

[Table("BBMoves")]
public partial class Bbmove
{
    public int MoveId { get; set; }

    [Column("BBId")]
    public int Bbid { get; set; }

    [ForeignKey("Bbid")]
    public virtual Beast? Bb { get; set; }

    [ForeignKey("MoveId")]
    public virtual Move? Move { get; set; }
}
