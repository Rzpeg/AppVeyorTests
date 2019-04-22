using System;
using System.Threading.Tasks;
using AppVeyor.Tests.Common;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AppVeyor.Tests.Web.Startup))]

namespace AppVeyor.Tests.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            new Engine().Run();
        }
    }
}
