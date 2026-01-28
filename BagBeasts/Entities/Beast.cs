using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BagBeasts.Entities;

public partial class Beast
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Type1 { get; set; }

    public int? Type2 { get; set; }

    public int? MaxHp { get; set; }

    public int? Atk { get; set; }

    public int? Spa { get; set; }

    public int? Def { get; set; }

    public int? Spd { get; set; }

    public int? Initiative { get; set; }
}
