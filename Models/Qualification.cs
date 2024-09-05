using System;
using System.Collections.Generic;

namespace SkillSwap.Models;

public partial class Qualification
{
    public int Id { get; set; }

    public int? Count { get; set; }

    public int? AccumulatorAdition { get; set; }

    public int? IdUser { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
