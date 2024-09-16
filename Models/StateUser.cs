using System;
using System.Collections.Generic;

namespace SkillSwap.Models;

/* Model detailing if user account is active or inactive */
public partial class StateUser
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? DurationSuspension { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
