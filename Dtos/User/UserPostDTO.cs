namespace SkillSwap.Dtos.User;
public class UserPostDTO
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

    public int? IdState { get; set; } = 1;

    public int? IdRol { get; set; } = 2;
}