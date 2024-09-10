using System;
using System.Collections.Generic;

namespace SkillSwap.Models;

/* Model detailing a request an user have done */
public partial class Request
{
    public int Id { get; set; }

    public string? DisponibilitySchedule { get; set; }

    public string? Description { get; set; }

    public int? IdStateRequest { get; set; }

    public int? IdReceivingUser { get; set; }

    public int? IdRequestingUser { get; set; }

    public virtual User? IdReceivingUserNavigation { get; set; }

    public virtual User? IdRequestingUserNavigation { get; set; }

    public virtual StateRequest? IdStateRequestNavigation { get; set; }
}
