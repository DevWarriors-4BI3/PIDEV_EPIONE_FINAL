using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Hubs
{
    public class Chat : Hub
    {
        public void SendMessage(string message)
        {
            // string chatMessage = $"Message from {this.Context.ConnectionId}:and User {this.Context.User.Identity.Name}: {message}";
            string chatMessage = $" {this.Context.User.Identity.Name} {message}";
            this.Clients.All.reseiveMessage(chatMessage);



        }
    }

}