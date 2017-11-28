using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using WebSignalRFirst.Models;

namespace WebSignalRFirst.Hubs
{
    public class ChatHub : Hub
    {
        static List<ChatUser> Users = new List<ChatUser>();

        // Отправка сообщений
        public void Send(string name, string message)
        {
            string currentTime = DateTime.Now.ToString("hh:mm:ss");
            Clients.All.addMessage(currentTime, name, message); //addMessage - метод объявляется на стороне клиента в коде javascript. 
        }
        // Подключение нового пользователя
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;
            if (!Users.Any(x => x.ConnectionId == id))
            {
                Users.Add(new ChatUser { ConnectionId = id, Name = userName });
                // Посылаем сообщение текущему пользователю
                Clients.Caller.onConnected(id, userName, Users);
                // Посылаем сообщение всем пользователям, кроме текущего
                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }
        // Отключение пользователя
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                Users.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.Name);
            }

            return base.OnDisconnected(stopCalled);
        }

        
        //public void Hello()
        //{
        //    Clients.All.hello();
        //}
    }
}