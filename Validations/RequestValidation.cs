using SkillSwap.Dtos.Request;
using SkillSwap.Services;

namespace SkillSwap.Validations;

public static class RequestValidation
{

    public static async Task<string> GeneralValidation(RequestPostDTO requestDTO)
    {
        if (!DataValidator.ValidateContainNotNull(requestDTO.DisponibilitySchedule))
        {
            return "La disponibilidad es requerida";
        }

        if (!DataValidator.ValidateContainNotNull(requestDTO.IdReceivingUser))
        {
            return "Id de usuario que recibe es requerido";
        }

        if (!DataValidator.ValidateContainNotNull(requestDTO.IdRequestingUser))
        {
            return "Id de usuario que solicita es requerido";
        }

        return "correct";
    }

}