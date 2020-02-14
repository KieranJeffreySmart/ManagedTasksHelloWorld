using System;

namespace ManagedTasks.WebApp
{
    using System.IO;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Steeltoe.Common.Hosting;
    using Steeltoe.Extensions.Configuration.CloudFoundry;
    using Steeltoe.Extensions.Logging.SerilogDynamicLogger;
    using Steeltoe.Management.CloudFoundry;
    using Steeltoe.Management.TaskCore;

    class Program
    {
        static void Main(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder()
                .UseConfiguration(new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .AddEnvironmentVariables().SetBasePath(Directory.GetCurrentDirectory()).Build())
                .AddCloudFoundry()              // config
                .UseCloudHosting()       // listen on port defined in env var 'PORT'
                .ConfigureLogging((context, builder) => builder.AddSerilogDynamicConsole())
                .AddCloudFoundryActuators()  // add actuators - should come AFTER Serilog config or else DynamicConsoleLogger will be injected
                .UseStartup<Startup>()
                .Build();

               host.RunWithTasks();
        }
    }
}
