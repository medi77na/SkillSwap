namespace SkillSwap.Dtos.User;
public class UserGetDTO
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Description { get; set; }
    public string? JobTitle { get; set; }
    public string? UrlLinkedin { get; set; }
    public string? UrlGithub { get; set; }
    public string? UrlBehance { get; set; }
    public string? UrlImage { get; set; }
    public string? PhoneNumber { get; set; }
    public int? IdState { get; set; }
    public string? StateName { get; set; }
}