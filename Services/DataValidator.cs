using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using SkillSwap.Models;

namespace SkillSwap.Services;
public class DataValidator
{

    public static async Task<bool> LookForRepeatEmail(AppDbContext context, string email)
    {
        return await context.Users.AnyAsync(e => e.Email == email);
    }

    public static bool ValidateEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return false;
        }

        // Uses a regular expression to validate the e-mail format
        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        return emailRegex.IsMatch(email);
    }

    public static bool ValidateLettersOnly(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        // Verify that it contains only letters
        var lettersOnlyRegex = new Regex(@"^[a-zA-Z\s]+$");
        return lettersOnlyRegex.IsMatch(input);
    }

    public static bool ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            return false;
        }

        var passwordRegex = new Regex(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
        return passwordRegex.IsMatch(password);
    }

    public static bool ValidateContainNotNull(object input)
    {

        string? response = Convert.ToString(input);

        if (string.IsNullOrEmpty(response))
        {
            return false;
        }
        return true;
    }
}