using Microsoft.Extensions.Logging;
using Steeltoe.Common.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagedTasks.WebApp.Decorators
{
    public class LogApplicationTaskDecorator<TApplicationTask> : IApplicationTask
        where TApplicationTask : class, IApplicationTask, new()
    {
        private TApplicationTask innerTask = new TApplicationTask();
        private readonly ILogger<DelayApplicationTaskDecorator<TApplicationTask>> logger;

        public LogApplicationTaskDecorator(ILogger<DelayApplicationTaskDecorator<TApplicationTask>> logger)
        {
            this.logger = logger;
            logger.LogInformation($"{innerTask.Name} Task Created");
        }

        public string Name => innerTask.Name;

        public void Run()
        {
            logger.LogInformation($"Run {innerTask.Name} Task Started");
            innerTask.Run();
            logger.LogInformation($"Run {innerTask.Name} Task Finished");
        }
    }
}
