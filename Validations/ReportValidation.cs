using Microsoft.AspNetCore.Mvc;
using SkillSwap.Dtos.Report;
using SkillSwap.Services;

namespace SkillSwap.Validations;
public static class ReportValidation
{
    public static async Task<string> GeneralValidationAsync([FromBody] ReportPostDTO reportDTO)
    {
        if (!DataValidator.ValidateLettersOnly(reportDTO.TitleReport))
        {
            return "Report Tittle is incorrect";
        }

        if (!DataValidator.ValidateContainNotNull(reportDTO.Description))
        {
            return "Report Description is required";
        }

        if (!DataValidator.ValidateContainNotNull(reportDTO.ActionTaken))
        {
            return "Report action taken is required";
        }

        if (!DataValidator.ValidateContainNotNull(reportDTO.IdUser))
        {
            return "Id by user is required";
        }

        if (!DataValidator.ValidateContainNotNull(reportDTO.IdReportedUser))
        {
            return "The Id by reported user is required";
        }
        return "success";
    }
}