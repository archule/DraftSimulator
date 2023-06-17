using System;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using System.Threading.Tasks;

namespace madden.Hubs
{
    /* */
    public class ChatHub : Hub
    {
        /* Runs at connection time. */
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine("--> Connection Opened: " + Context.ConnectionId);
            await Clients.Client(Context.ConnectionId).SendAsync("ReceiveConnID", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine("--> Connection Closed: " + Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessageAsync(string message)
        {
            var routeOb = JsonSerializer.Deserialize<dynamic>(message);
            Console.WriteLine("To: " + routeOb.GetProperty("To").ToString());
            Console.WriteLine("Message Received on: " + Context.ConnectionId);

            if (routeOb.GetProperty("To").ToString() == string.Empty)
            {
                Console.WriteLine("Broadcast");
                await Clients.All.SendAsync("ReceiveMessage", message);
            }
            else
            {
                string toClient = routeOb.To;
                Console.WriteLine("Targeted on: " + toClient);
                await Clients.Client(toClient).SendAsync("ReceiveMessage", message);
            }
        }
    }
}
