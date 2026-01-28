using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BagBeasts.Entities;

[Table("User")]
public partial class User
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Psw { get; set; }

    public string? Auth { get; set; }

    public int? Wins { get; set; }

    public int? Loses { get; set; }
}
