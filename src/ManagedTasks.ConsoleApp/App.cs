using Microsoft.Extensions.DependencyInjection;

namespace ManagedTasks.ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Steeltoe.Common.Tasks;

    public class App
    {
        private List<IApplicationTask> tasks;

        public App(IEnumerable<IApplicationTask> tasks)
        {
            this.tasks = tasks.ToList();
        }

        public void Run()
        {
            while(true)
            {
                //Run indefinately
            }

            //WriteCommandList();

            //var key = Console.ReadKey();

            //while (key.KeyChar != 'q')
            //{
            //    if (int.TryParse(key.KeyChar.ToString(), out var index) && index >= 0 && index < tasks.Count)
            //    {
            //        Console.WriteLine();
            //        tasks[index].Run();
            //    }

            //    WriteCommandList();
            //    key = Console.ReadKey();
            //    Console.WriteLine();
            //}
        }

        private void WriteCommandList()
        {
            Console.WriteLine("Execute A Task:");
            for (var i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i}: {tasks[i].Name}");
            }

            Console.WriteLine($"q: quit");

            Console.Write($"Command [0-{tasks.Count}, q]: ");
        }
    }
}