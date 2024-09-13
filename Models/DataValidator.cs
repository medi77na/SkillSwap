using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SkillSwap.Models
{
    public class DataValidator
    {
        private readonly AppDbContext _context;

        public DataValidator(AppDbContext context)
        {
            _context = context;
        }
        
        public bool LookForRepeatEmail(string email)
        {
            bool Answer;
            Answer = _context.Users.Any(e => e.Email == email);
            return Answer;
        }
    }
}