namespace SkillSwap.Models;
public class DataValidator
{
    private readonly AppDbContext _context;

    public DataValidator(AppDbContext context)
    {
        _context = context;
    }

    public bool LookForRepeatEmail(string email)
    {
        return _context.Users.Any(e => e.Email == email);
    }
}