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

        public static async Task<string> StateValidation(RequestPatchDTO requestDTO)
    {
        if (!DataValidator.ValidateContainNotNull(requestDTO.IdStateRequest))
        {
            return "El estado es requerido";
        }

        if (requestDTO.IdStateRequest < 1 || requestDTO.IdStateRequest > 3)
        {
            return "Estado fuera de rango";
        }
        return "correct";
    }

}