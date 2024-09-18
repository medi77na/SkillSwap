namespace SkillSwap.Models;

/* Model detailing the types of roles available to each user */
public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
