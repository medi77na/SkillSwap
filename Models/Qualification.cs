using System;
using System.Collections.Generic;

namespace SkillSwap.Models;

/* Model that is related to User, as it details the ratings that a user has received. */
public partial class Qualification
{
    public int Id { get; set; }

    public int? Count { get; set; }

    public int? AccumulatorAdition { get; set; }

    public User User{ get; set; }
}
