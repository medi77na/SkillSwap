using Microsoft.AspNetCore.Mvc;
using SkillSwap.Dtos.User;
using SkillSwap.Models;
using SkillSwap.Services;

namespace SkillSwap.Validations;
public static class UserValidation
{

    public static string IncorrectEmail { get; set; } = "incorrect email";
    public static string IncorrectPassword { get; set; } = "incorrect password";
    public static string IncorrectName { get; set; } = "incorrect name";
    public static string IncorrectLastName { get; set; } = "incorrect last name";
    public static string EmailAlreadyRegistered { get; set; } = "email already registered";
    public static string BirthdateNotNull { get; set; } = "birthday is required";
    public static string CategoryNotNull { get; set; } = "category is required";
    public static string AbilitiesNotNull { get; set; } = "abilities is required";

    public static async Task<string> GeneralValidationAsync(AppDbContext _dbContext,[FromBody] UserPostDTO userDTO)
    {

        // Check if email is valid
        if (!DataValidator.ValidateEmail(userDTO.Email))
        {
            return IncorrectEmail;
        }

        //Check if password is valid
        if (!DataValidator.ValidatePassword(userDTO.Password))
        {
            return "incorrect password";
        }

        //Check if name is valid
        if (!DataValidator.ValidateLettersOnly(userDTO.Name))
        {
            return "incorrect username";
        }

        //Check if lastName is valid
        if (!DataValidator.ValidateLettersOnly(userDTO.LastName))
        {
            return "incorrect lastname";
        }

        //Check if email is already registered
        if (await DataValidator.LookForRepeatEmail(_dbContext, userDTO.Email))
        {
            return "email already registered";
        }

        //Check if category is not null
        if (!DataValidator.ValidateContainNotNull(userDTO.Category))
        {
            return CategoryNotNull;
        }

        //Check if skills is not null
        if (!DataValidator.ValidateContainNotNull(userDTO.Abilities))
        {
            return AbilitiesNotNull;
        }

        return "correct user";
    }
}