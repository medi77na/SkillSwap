using Microsoft.AspNetCore.Mvc;
using SkillSwap.Dtos.User;
using SkillSwap.Models;
using SkillSwap.Services;

namespace SkillSwap.Validations;
public static class UserValidation
{
    public static async Task<string> GeneralValidationAsync(AppDbContext _dbContext, [FromBody] UserPostDTO userDTO)
    {

        // Check if email is valid
        if (!DataValidator.ValidateEmail(userDTO.Email))
        {
            return "incorrect email";
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

        //Check if birthday is not null
        if (!DataValidator.ValidateContainNotNull(userDTO.Birthdate))
        {
            return "birthday is required";
        }

        //Check if category is not null
        if (!DataValidator.ValidateContainNotNull(userDTO.Category))
        {
            return "category is required";
        }

        //Check if skills is not null
        if (!DataValidator.ValidateContainNotNull(userDTO.Abilities))
        {
            return "abilities is required";
        }

        return "correct user";
    }
}