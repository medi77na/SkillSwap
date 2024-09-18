using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



using SkillSwap.Models;
using Microsoft.EntityFrameworkCore;

namespace SkillSwap.Controllers.V1.Reports
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportDeleteController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ReportDeleteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActionOnReport([FromRoute] int id)
        {
            var find = await checkExistence(id);
            if (find == false)
            {
                return NotFound($"Reporte con {id} no encontrado.");
            }
            _context.Reports.Remove(await _context.Reports.FindAsync(id));
            await _context.SaveChangesAsync();
            return Ok("Reporte eliminado con éxito");
        }

        private async Task<bool> checkExistence(int id)
        {
            return await _context.Reports.AnyAsync(p => p.Id == id);
        }
    }
}