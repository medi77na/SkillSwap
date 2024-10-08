namespace SkillSwap.Dtos.User;
public class UserPutAdminDTO
{

    public int Id { get; set; }
    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? UrlImage { get; set; }

    public string? JobTitle { get; set; }

    public string? Description { get; set; }

    public DateOnly Birthdate { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Category { get; set; }

    public string? Abilities { get; set; }

    public string? UrlLinkedin { get; set; }

    public string? UrlGithub { get; set; }

    public string? UrlBehance { get; set; }

    public int? IdStateUser { get; set; }

    public int? IdRoleUser { get; set; }

    public DateOnly? SuspensionDate {get; set;} = null;

    public DateOnly? ReactivationDate {get; set;} = null;


}