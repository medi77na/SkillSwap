using System;
using System.Collections.Generic;

namespace SkillSwap.Models;

public partial class UsersSecondaryAbility
{
    public int Id { get; set; }

    public int? IdUser { get; set; }

    public int? IdSecondaryAbilitie { get; set; }

    public virtual SecondaryAbility? IdSecondaryAbilitieNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
