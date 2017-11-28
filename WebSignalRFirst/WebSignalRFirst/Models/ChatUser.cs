using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSignalRFirst.Models
{
    public class ChatUser
    {
        public string ConnectionId { get; set; }//!!задается средой и является строковым!!!
        public string Name { get; set; }
    }
}