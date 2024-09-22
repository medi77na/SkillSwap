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
        public async Task<IActionResult> PutActionOnReport([FromBody] ReportActionDTO reportDTO)
        {
            string message = "";
            if (reportDTO.Id == default(int) || reportDTO.ActionTaken == null || reportDTO.IdReportedUser == default(int) || reportDTO.IdUser == default(int))
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
                if (report.UserReported.IdState == 3)
                {
                    message = ", El usuario reportado ya se encuentra suspendido";
                }
                else
                {
                    report.IdState = 2;
                    report.UserReported.IdState = 3;
                    report.ActionTaken = "usuario suspendido";
                    report.UserReported.SuspensionDate = DateOnly.FromDateTime(DateTime.Now);
                    report.UserReported.ReactivationDate = (report.UserReported.SuspensionDate ?? DateOnly.FromDateTime(DateTime.Now)).AddDays(5);
                }

            }
            else if (reportDTO.ActionTaken.Equals("habilitar", StringComparison.OrdinalIgnoreCase))
            {
                if (report.UserReported.IdState == 1)
                {
                    message = ", El usuario reportado ya se encuentra habilitado";
                }
                else
                {
                    if (DateOnly.FromDateTime(DateTime.Now) > report.UserReported.ReactivationDate)
                    {
                        report.IdState = 3;
                        report.UserReported.IdState = 1;
                        report.ActionTaken = "usuario habilitado";
                        report.UserReported.SuspensionDate = null;
                        report.UserReported.ReactivationDate = null;
                    }
                    else
                    {
                        return StatusCode(200, ManageResponse.SuccessfullWithObject("Lo sentimos pero la cuenta sigue suspendida", new
                        {
                            Id_del_reporte = report.Id,
                            Estado = report.StateReport.Name,
                            AccionTomada = report.ActionTaken,
                            id_del_usuario_reportante = report.IdUser,
                            Id_del_usuario_reportado = report.IdReportedUser,
                            nombre = report.User.Name,
                            estado_de_Cuenta_del_usuario_reportado = report.UserReported.IdStateNavigation.Name,
                            fecha_de_suspension = report.UserReported.SuspensionDate,
                            fecha_de_reactivacion = report.UserReported.ReactivationDate
                        }));
                    }


                }

            }
            else if (reportDTO.ActionTaken.Equals("deshabilitar", StringComparison.OrdinalIgnoreCase))
            {
                if (report.UserReported.IdState == 2)
                {
                    message = ", El usuario reportado ya se encuentra deshabilitado";
                }
                else
                {
                    report.IdState = 3;
                    report.UserReported.IdState = 2;
                    report.ActionTaken = "usuario deshabilitado";
                    report.UserReported.SuspensionDate = null;
                    report.UserReported.ReactivationDate = null;
                }
            }
            else
            {
                return StatusCode(400, ManageResponse.ErrorBadRequest("Acción no reconocida."));
            }

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            report = await _dbContext.Reports
               .Include(r => r.User)
               .Include(r => r.UserReported)
               .Include(r => r.UserReported.IdStateNavigation)
               .Include(r => r.StateReport)
               // Incluir el usuario relacionado
               .FirstOrDefaultAsync(r => r.Id == reportDTO.Id && r.IdReportedUser == reportDTO.IdReportedUser);

            var response = new
            {
                Id_del_reporte = report.Id,
                Estado = report.StateReport.Name,
                AccionTomada = report.ActionTaken,
                id_del_usuario_reportante = report.IdUser,
                Id_del_usuario_reportado = report.IdReportedUser,
                nombre = report.User.Name,
                estado_de_Cuenta_del_usuario_reportado = report.UserReported.IdStateNavigation.Name,
                fecha_de_suspension = report.UserReported.SuspensionDate,
                fecha_de_reactivacion = report.UserReported.ReactivationDate
            };

            // Return a success response with the updated report information
            return StatusCode(200, ManageResponse.SuccessfullWithObject("Data actualizada " + message, response));
        }
    }
}