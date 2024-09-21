namespace SkillSwap.Dtos.Request;

public class RequestGetMessagesDTO
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public int? IdRequestingUser { get; set; }
    public int? IdReceivingUser { get; set; }
    public string? UserNameReceiving { get; set; }
    public string? UserNameRequesting { get; set; }
}