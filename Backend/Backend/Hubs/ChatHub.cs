using Backend.Models.ModelsID;
using Backend.Services;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Hubs
{
    public sealed class ChatHub : Hub
    {
       
        /* debug data for postman (won't be used in gossip)
         * 
         *          wss://localhost:7062/chat
         *          {"protocol":"json","version":1}
         */
        public override async Task OnConnectedAsync()
        {
            MessageModelID message = new MessageModelID(0, 0, 0, "Anonimous user connected", DateTime.Now, false, false);

            await Clients.All.SendAsync("UserConnected", "Anonimous user connected");
        }





        //to send real-timemessage user must be online
        public async Task OnConnnectedAsync(UserModelID user)
        {
            await Clients.All.SendAsync("UserConnected", $"{user.Username} is now online");
        }

        public async Task SendMessage(MessageModelID message)
        {
            MessagesService.Add(message, Backend.Program.Globals.db.Connection);

            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}