using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillSwap.Dtos.User
{
    public class UserGetForImagesDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public double? Qualification { get; set; }
        public int CountMatches { get; set; }
        public string Description { get; set; }
        public string Abilities { get; set; }
    }
}