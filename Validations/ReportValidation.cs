using Microsoft.AspNetCore.Mvc;
using SkillSwap.Dtos.Report;
using SkillSwap.Models;
using SkillSwap.Services;

namespace SkillSwap.Validations;
public static class ReportValidation
{

    public static async Task<string> GeneralValidationAsync([FromBody] ReportPostDTO reportDTO)
    {
        if (DataValidator.ValidateLettersOnly(reportDTO.TitleReport))
        {
            return "Report Tittle is required";
        }

        if (DataValidator.ValidateLettersOnly(reportDTO.Description))
        {
            return "Report Description is required";
        }

        if (DataValidator.ValidateContainNotNull(reportDTO.IdUser))
        {
            return "Id by user is required";
        }

        if (DataValidator.ValidateContainNotNull(reportDTO.IdReportedUser))
        {
            return "The Id by reported user is required";
        }

        return "correct report";
    }
}