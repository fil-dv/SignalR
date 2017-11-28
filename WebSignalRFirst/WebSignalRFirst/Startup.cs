using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebSignalRFirst.Startup))]

namespace WebSignalRFirst
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();//добавляем строку        }
        }
    }
}
