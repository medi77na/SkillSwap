using System.Text.RegularExpressions;

namespace SkillSwap.Validations;
public static class EntriesValidation
{
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

}