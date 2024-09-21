using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillSwap.Dtos.Report;
using SkillSwap.Models;

namespace SkillSwap.Controllers.V1.Reports
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportPutController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ReportPutController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // PUT action for updating the status of a report
        [HttpPut("PutActionOnReport")]
        public async Task<IActionResult> PutActionOnReport([FromBody] ReportDTO reportDTO)
        {
            if (reportDTO.Id == default(int) || reportDTO.ActionTaken == null || reportDTO.IdReportedUser == default(int))
            {
                return StatusCode(400, ManageResponse.ErrorBadRequest("Error, ninguno de los datos puede estar vacío."));
            }

            // Search for the report in the database, including related entities
            var report = await _dbContext.Reports
                .Include(r => r.User)
                .Include(r => r.UserReported)
                .Include(r => r.UserReported.IdStateNavigation)
                .Include(r => r.StateReport)
                // Incluir el usuario relacionado
                .FirstOrDefaultAsync(r => r.Id == reportDTO.Id && r.IdReportedUser == reportDTO.IdReportedUser);

            // If the report is not found, return a 404 Not Found response
            if (report == null)
            {
                return StatusCode(400, ManageResponse.ErrorNotFound());
            }

            // Ensure the user is not null before accessing their properties
            if (report.User == null)
            {
                return StatusCode(400, ManageResponse.ErrorNotFound());
            }

            // Ensure the UserReported is not null before accessing their properties
            if (report.UserReported == null)
            {
                return StatusCode(400, ManageResponse.ErrorNotFound());
            }


            // Update the report and user's state based on the action
            if (reportDTO.ActionTaken.Equals("suspender", StringComparison.OrdinalIgnoreCase))
            {
                report.IdState = 2;
                report.UserReported.IdState = 3;
                report.ActionTaken = "usuario suspendido";
            }
            else if (reportDTO.ActionTaken.Equals("habilitar", StringComparison.OrdinalIgnoreCase))
            {
                report.IdState = 3; // Cambié a 1 porque es para habilitar
                report.UserReported.IdState = 1;
                report.ActionTaken = "usuario habilitado";
            }
            else if (reportDTO.ActionTaken.Equals("deshabilitar", StringComparison.OrdinalIgnoreCase))
            {
                report.IdState = 3;
                report.UserReported.IdState = 2;
                report.ActionTaken = "usuario deshabilitado";
            }
            else
            {
                return StatusCode(400, ManageResponse.ErrorBadRequest("Acción no reconocida."));
            }


            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            var response = new
            {
                Id_del_reporte = report.Id,
                Estado = report.StateReport.Name,
                AccionTomada = report.ActionTaken,
                Id_del_usuario_reportado = report.IdReportedUser,
                nombre = report.User.Name,
                estado_de_Cuenta_del_usuario_reportado = report.UserReported.IdStateNavigation.Name
            };

            // Return a success response with the updated report information
            return StatusCode(200, ManageResponse.SuccessfullWithObject("Data actualizada", response));
        }
    }
}