using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillSwap.Dtos.Report;

namespace SkillSwap.Models
{
    public class ReportManager
    {
        public static async Task<List<ReportGetDTO>> ReportProjection(AppDbContext _dbContext, List<Report> reports)
        {
            // Additional query to obtain the required users
            var userIds = reports.Select(r => r.IdUser)
            .Union(reports.Select(r => r.IdReportedUser))
            .Distinct()
            .ToList();

            var users = await _dbContext.Users
                .Where(u => userIds.Contains(u.Id))
                .Select(user => new
                {
                    user.Id,
                    user.Name,
                    user.LastName
                })
                .ToDictionaryAsync(u => u.Id);

            // Final projection to DTO with combined User and ReportedUser
            var reportDtos = reports.Select(report => new ReportGetDTO
            {
                Id = report.Id,
                Title = report.TitleReport,
                Description = report.Description,
                User = users.ContainsKey(report.IdUser) ? $"{users[report.IdUser].Name} {users[report.IdUser].LastName}" : null,
                ReportedUser = users.ContainsKey(report.IdReportedUser) ? $"{users[report.IdReportedUser].Name} {users[report.IdReportedUser].LastName}" : null
            }).ToList();

            return reportDtos;
        }
    }
}