using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace _15_SignalRSample.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string username, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }
    }
}
