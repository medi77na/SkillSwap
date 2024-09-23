using Microsoft.AspNetCore.SignalR;

namespace SkillSwap.Models;
public class ChatHub : Hub
{
    public async Task SendMessage(string userId, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", userId, message);
    }
}