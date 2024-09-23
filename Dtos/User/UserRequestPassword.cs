namespace SkillSwap.Dtos.User;
public class UserRequestPassword
{
    public string Token { get; set; }

    public string? NewPassword { get; set; }
}
