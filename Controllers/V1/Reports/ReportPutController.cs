using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> PutActionOnReport(string action, int idReport, int idUserReport)
        {
            if (idReport == default(int) || action == null || idUserReport == default(int))
            {
                return BadRequest("Error, ninguno de los datos puede estar vacío.");
            }

            // Search for the report in the database, including related entities
            var report = await _dbContext.Reports
                .Include(r => r.User)
                .Include(r => r.UserReported)
                .Include(r => r.UserReported.IdStateNavigation)
                .Include(r => r.StateReport)
                // Incluir el usuario relacionado
                .FirstOrDefaultAsync(r => r.Id == idReport && r.IdReportedUser == idUserReport);

            // If the report is not found, return a 404 Not Found response
            if (report == null)
            {
                return NotFound("No se encontró el usuario para resolver el reporte.");
            }

            // Ensure the user is not null before accessing their properties
            if (report.User == null)
            {
                return NotFound("El usuario reportador no existe.");
            }

            // Ensure the UserReported is not null before accessing their properties
            if (report.UserReported == null)
            {
                return NotFound("El usuario reportado no existe.");
            }


            // Update the report and user's state based on the action
            if (action.Contains("suspender", StringComparison.OrdinalIgnoreCase))
            {
                report.IdState = 2;
                report.UserReported.IdState = 3;
                report.ActionTaken = "usuario suspendido";
            }
            else if (action.Contains("habilitar", StringComparison.OrdinalIgnoreCase))
            {
                report.IdState = 3; // Cambié a 1 porque es para habilitar, antes estaba 3
                report.UserReported.IdState = 1;
                report.ActionTaken = "usuario habilitado";
            }
            else if (action.Contains("inactivar", StringComparison.OrdinalIgnoreCase))
            {
                report.IdState = 3;
                report.UserReported.IdState = 2;
                report.ActionTaken = "usuario inactivado";
            }
            else
            {
                return BadRequest("Acción no reconocida.");
            }

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            // Return a success response with the updated report information
            return Ok(new
            {
                message = "Success",
                data = new
                {
                    Id_del_reporte = report.Id,
                    Estado = report.StateReport.Name,
                    AccionTomada = report.ActionTaken,
                    Id_del_usuario_reportado = report.IdReportedUser,
                    nombre = report.User.Name,
                    estado_de_Cuenta_del_usuario_reportado = report.UserReported.IdStateNavigation.Name
                }
            });
        }
    }
}