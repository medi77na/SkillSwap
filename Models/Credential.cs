using System;
using System.Collections.Generic;

namespace SkillSwap.Models;

public partial class Credential
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
