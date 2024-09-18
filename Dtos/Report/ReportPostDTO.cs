namespace SkillSwap.Dtos.Report;
public class ReportPostDTO
{
    public string? TitleReport { get; set; }
    public string? Description { get; set; }
    public string? ActionTaken { get; set; }
    public int IdUser { get; set; }
    public int IdReportedUser { get; set; }
}