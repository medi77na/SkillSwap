using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkillSwap.Models;
using SkillSwap.Dtos.Report;
using Microsoft.EntityFrameworkCore;

namespace SkillSwap.Controllers.V1.Admin
{
    [Route("[controller]")]
    public class ReportGetController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ReportGetController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Reports")]
        public async Task<IActionResult> GetReports()
        {
            // Main query to obtain reports
            var reports = await _dbContext.Reports
                .Select(report => new Report
                {
                    Id = report.Id,
                    TitleReport = report.TitleReport,
                    Description = report.Description,
                    DateReport = report.DateReport,
                    ActionTaken = report.ActionTaken,
                    IdState = report.IdState,
                    IdUser = report.IdUser,
                    IdReportedUser = report.IdReportedUser
                })
                .ToListAsync();
            
            var reportDtos = await ReportManager.ReportProjection(_dbContext, reports);
            return StatusCode(200,ManageResponse.SuccessfullWithObject("Data encontrada",reportDtos) );
        }

        [HttpGet("Reports/{id}")]
        public async Task<IActionResult> GetReportById(int id)
        {
            // Obtain the users from the database and project only the desired fields.
            var reports = await _dbContext.Reports.Where(r => r.Id == id)
            .Select(report => new Report
            {
                Id = report.Id,
                TitleReport = report.TitleReport,
                Description = report.Description,
                DateReport = report.DateReport,
                ActionTaken = report.ActionTaken,
                IdState = report.IdState,
                IdUser = report.IdUser,
                IdReportedUser = report.IdReportedUser
            })
            .ToListAsync();

            var reportDtos = await ReportManager.ReportProjection(_dbContext, reports);
            return StatusCode(200,ManageResponse.SuccessfullWithObject("Data encontrada",reportDtos) );
        }
    }
}