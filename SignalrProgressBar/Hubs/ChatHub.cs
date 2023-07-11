using Microsoft.AspNetCore.SignalR;

namespace SignalrProgressBar.Hubs
{
    public class ChatHub : Hub
    {
        public async Task UpdateProgress(int progress)
        {
            await Clients.All.SendAsync("ReceiveProgress", progress);
        }
    }
}
