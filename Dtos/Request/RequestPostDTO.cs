namespace SkillSwap.Dtos.Request;

public class RequestPostDTO
{
    public string? DisponibilitySchedule { get; set; }
    public string? Description { get; set; }
    public int? IdReceivingUser { get; set; }
    public int? IdRequestingUser { get; set; }
}