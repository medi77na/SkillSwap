namespace SkillSwap.Interfaces;
public interface IEmailService
{
    Task SendPasswordResetEmail(string toEmail, string resetLink);
}