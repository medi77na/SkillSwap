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

        [HttpGet("GetReportsAll")]
        public async Task<IActionResult> GetReportsAll()
        {
            // Main query to obtain reports from the database.
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

            // Process the reports through the ReportManager for any additional logic or projection.
            var reportDtos = await ReportManager.ReportProjection(_dbContext, reports);

            // Return a successful response with the list of reports.
            return StatusCode(200, ManageResponse.SuccessfullWithObject("Data encontrada", reportDtos));
        }

        [HttpGet("GetReportById/{id}")]
        public async Task<IActionResult> GetReportById(int id)
        {
            // Query to obtain the report from the database based on the provided ID.
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

            // Process the retrieved report through the ReportManager for any additional logic.
            var reportDtos = await ReportManager.ReportProjection(_dbContext, reports);

            // Return a successful response with the report data.
            return StatusCode(200, ManageResponse.SuccessfullWithObject("Data encontrada", reportDtos));
        }
    }
}