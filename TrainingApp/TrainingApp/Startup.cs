using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(TrainingApp.Startup))]

namespace TrainingApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.MapSignalR();
        }

        
    }
    [HubName("myChatHub")]
    public class LetsChat : Hub
    {
        public void send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name,message);

        }
    }
}
