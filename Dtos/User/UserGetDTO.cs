namespace SkillSwap.Dtos.User;
public class UserGetDTO
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string LastName { get; set; }

    public required string JobTitle { get; set; }

    public required string Description { get; set; }

    public DateOnly Birthdate { get; set; }

    public required string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? AbilityCategory { get; set; }

    public string? UrlLinkedin { get; set; }

    public string? UrlGithub { get; set; }

    public string? UrlBehance { get; set; }

    public string? RoleName { get; set; }
}