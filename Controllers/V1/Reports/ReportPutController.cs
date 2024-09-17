using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPut("PutActionOnReport")]
        public async Task<IActionResult> PutActionOnReport(string action, int idReport, int idUserReport)
        {
            if (idReport == null || action == null || idUserReport == null)
            {
                return BadRequest("Error, ninguno de los datos puede estar vacio.");
            }

            // Buscar el coder en la base de datos
            var report = await _dbContext.Report.Where(r => r.IdReport == idReport && r.IdUserReport == idUserReport).FirstOrDefaultAsync(); ;
            if (report == null)
            {
                return NotFound("No se encontró el usuario para resolver el reporte");
            }

            // Actualiza la información del coder
            if (action.Contains("suspender", StringComparison.OrdinalIgnoreCase))
            {
                report.IdState = 3
                report.User.IdState = 3
                report.ActionTaken = "usuario suspendido"
            }
            else if (action.Contains("habilitar", StringComparison.OrdinalIgnoreCase))
            {
                report.IdState = 3
                report.User.IdState = 1
                report.ActionTaken = "usuario habilitado"
            }

            // Save changes
            await conexionConLaBaseDeDatos.SaveChangesAsync();

            return Ok({
                message = "Success",
                data = new
                {
                    "Id del reporte": report.Id,
                    "Estado": report.IdState,
                    "AccionTomada": report.ActionTaken,
                    "Id del usuario reportado": report.IdReportedUser
                    "nombre": report.User.Name,
                    "estado de Cuenta del usuario reportado": report.User.IdStateNavigation.Name
                }
            });
        }


    }
}