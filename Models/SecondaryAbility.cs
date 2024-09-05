using System;
using System.Collections.Generic;

namespace SkillSwap.Models;

public partial class SecondaryAbility
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? IdPrimaryAbilitie { get; set; }

    public virtual PrimaryAbility? IdPrimaryAbilitieNavigation { get; set; }

    public virtual ICollection<UsersSecondaryAbility> UsersSecondaryAbilities { get; set; } = new List<UsersSecondaryAbility>();
}
