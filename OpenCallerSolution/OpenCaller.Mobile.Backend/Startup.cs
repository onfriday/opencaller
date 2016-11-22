using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using OpenCaller.Web.SQLServer;
using SimpleInjector.Extensions.ExecutionContextScoping;

[assembly: OwinStartup(typeof(OpenCaller.Mobile.Backend.Startup))]

namespace OpenCaller.Mobile.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder pApp)
        {
            OpenCallerDbContextInitializer.ConfigureInitializer();

            var _container = SimpleInjectorInitializer.Initialize(pApp);

            pApp.Use(async (context, next) =>
            {
                using (_container.BeginExecutionContextScope())
                {
                    await next();
                }
            });

            ConfigureAuth(pApp, _container);
        }
    }
}
