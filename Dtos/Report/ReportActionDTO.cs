using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillSwap.Dtos.Report
{
    public class ReportActionDTO
    {
        public int Id { get; set; }
        public string ActionTaken { get; set; }
        public int IdUser { get; set; }
        public int IdReportedUser { get; set; }
        
    }
}