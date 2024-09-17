using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillSwap.Dtos.Report
{
    public class ReportGetDTO
    {
        public int Id { get; set;}
        public string Title { get; set;}
        public string Description { get; set;}
        public string User { get; set;}
        public string ReportedUser { get; set;}
    }
}