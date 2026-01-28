using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BagBeasts.Entities;

public partial class Ability
{
    [Key]
    public int AbilityId { get; set; }

    public int? BagBeastId { get; set; }
}
