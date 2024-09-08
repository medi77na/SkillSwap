namespace SkillSwap.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string? Description { get; set; }

    public string? JobTitle { get; set; }

    public string? UrlLinkedin { get; set; }

    public string? UrlImage { get; set; }

    public string? PhoneNumber { get; set; }

    public int? IdState { get; set; }

    public int? IdRol { get; set; }

    public int? IdQualification { get; set; }

    public virtual Role? IdRolNavigation { get; set; }

    public virtual StateUser? IdStateNavigation { get; set; }

    public virtual ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();

    public virtual ICollection<Request> RequestIdReceivingUserNavigations { get; set; } = new List<Request>();

    public virtual ICollection<Request> RequestIdRequestingUserNavigations { get; set; } = new List<Request>();

    public virtual ICollection<UsersSecondaryAbility> UsersSecondaryAbilities { get; set; } = new List<UsersSecondaryAbility>();
}
