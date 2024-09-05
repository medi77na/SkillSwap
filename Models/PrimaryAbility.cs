using System;
using System.Collections.Generic;

namespace SkillSwap.Models;

public partial class PrimaryAbility
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<SecondaryAbility> SecondaryAbilities { get; set; } = new List<SecondaryAbility>();
}
