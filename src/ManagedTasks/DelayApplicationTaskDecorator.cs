namespace ManagedTasks
{
    using System.Collections.Generic;
    using System.Threading;
    using Steeltoe.Common.Tasks;

    public class DelayApplicationTaskDecorator<TApplicationTask> : IApplicationTask 
        where TApplicationTask : class, IApplicationTask, new()
    {
        private TApplicationTask innerTask = new TApplicationTask();

        public string Name => innerTask.Name;

        public void Run()
        {
            Thread.Sleep(10000);
            innerTask.Run();
        }
    }

    public abstract class AggregateApplicationTask : IApplicationTask
    {
        public abstract string Name { get; }

        protected abstract IEnumerable<IApplicationTask> Tasks { get; }

        public void Run()
        {
            foreach (var task in Tasks)
            {
                task.Run();
            }
        }
    }
}