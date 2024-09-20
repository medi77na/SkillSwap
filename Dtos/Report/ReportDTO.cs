using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillSwap.Dtos.Report
{
    public class ReportDTO
    {
        public int? Id { get; set; }
        public string? TitleReport { get; set; }
        public string? Description { get; set; }
        public DateOnly? DateReport { get; set; }
        public string? ActionTaken { get; set; }
        public int? IdState { get; set; }
        public int? IdUser { get; set; }
        public int? IdReportedUser { get; set; }

    }
}