using AppVeyor.Tests.Common;
using Microsoft.Azure.WebJobs;
using Topshelf;

namespace AppVeyor.Tests.Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            new Engine().Run();

            HostFactory.Run(hostConfigurator =>
            {
                hostConfigurator.SetDescription("AppVeyor.Tests Worker");
                hostConfigurator.SetDisplayName("AppVeyor.Tests.Worker");
                hostConfigurator.SetServiceName("AppVeyor.Tests.Worker");

                hostConfigurator.RunAsLocalSystem();
                hostConfigurator.StartAutomaticallyDelayed();

                hostConfigurator.EnableServiceRecovery(rc =>
                {
                    rc.RestartService(1);
                });

                hostConfigurator.Service<Service>(x =>
                {
                    x.ConstructUsing(() => new Service());

                    x.WhenStarted((service, hostControl) =>
                    {
                        service.Start();
                        new WebJobsShutdownWatcher().Token.Register(hostControl.Stop);
                        return true;
                    });

                    x.WhenStopped(service =>
                    {
                        service.Stop();
                    });
                });
            });
        }
    }
}
