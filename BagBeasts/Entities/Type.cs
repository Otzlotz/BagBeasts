using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BagBeasts.Entities;

public partial class Type
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }
}
