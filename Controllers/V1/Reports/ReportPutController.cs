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
        public async Task<IActionResult> PutActionOnReport(string action, int id){

            
            return Ok();
        }

        
    }
}