using System;
using System.Collections.Generic;

namespace SkillSwap.Models;

public partial class StateRequest
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
