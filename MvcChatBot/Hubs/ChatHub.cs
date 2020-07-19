using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace MvcChatBot.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("LaylaMessage", user, message);
        }
        
        public async Task UpdateBrowser()
        {
            
                await Clients.All.SendAsync("TriggerRain");
            
            
        }
        
        public Task SendMessageToGroup(string message)
        {
            return Clients.Group("SignalR Users").SendAsync("ReceiveMessage", message);
        }
    }
}