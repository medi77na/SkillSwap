using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using SkillSwap.Interfaces;

namespace SkillSwap.Services;

public class EmailService : IEmailService
{

    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task SendPasswordResetEmail(string toEmail, string resetLink)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("SkillSwap", "no-reply@miapp.com"));
        emailMessage.To.Add(new MailboxAddress("", toEmail));
        emailMessage.Subject = "Restauración de Contraseña SkillSwap";
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = $@"
        <div style=""font-family: Arial, sans-serif; text-align: center; padding: 20px; background-color: #f9f9f9; color: #333;"">
            <h2 style=""color: #da731e;"">Dear User,</h2>
            <p style=""font-size: 16px; line-height: 1.6;"">
                We have received a request to change the password associated with your SkillSwap account. If you did not initiate this request, please ignore this email. Otherwise, follow the instructions below to update your password.
            </p>
            <p style=""font-size: 16px; line-height: 1.6;"">
                To change your password, please click the button below:
            </p>
            <a href=""http://localhost:3000/recoverPassword"" style=""text-decoration: none;"">
                <button style=""padding: 12px 24px; font-size: 18px; color: #fff; background: linear-gradient(90deg, #F0AC27 0%, #da731e 60%, #ea2424 100%); border: none; border-radius: 5px; cursor: pointer;"">
                    Reset Password Link
                </button>
            </a>
            <p style=""font-size: 14px; color: #555;"">
                For security reasons, this link will expire in 24 hours. If you need a new link, please request a password reset again through the SkillSwap website.
            </p>
            <p style=""font-size: 14px; color: #555;"">
                If you have any questions or need further assistance, please contact our support team at 
                <a href=""mailto:[skillswap4@gmail.com]"" style=""color: #ea2424;"">[skillswap4@gmail.com]</a>.
            </p>
            <p style=""font-size: 14px; margin-top: 20px; color: #333;"">
                Thank you for using SkillSwap!
                <br>
                <strong>Best regards,</strong>
                <br>
                The SkillSwap Team
            </p>
        </div>"
        };

        using var client = new SmtpClient();
        await client.ConnectAsync(_configuration["SMTP_HOST"], int.Parse(_configuration["SMTP_PORT"]), SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_configuration["SMTP_USER"], _configuration["SMTP_PASS"]);
        await client.SendAsync(emailMessage);
        await client.DisconnectAsync(true);
    }
}