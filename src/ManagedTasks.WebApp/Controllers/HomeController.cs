namespace ManagedTasks.WebApp.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Steeltoe.Common.Tasks;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private List<IApplicationTask> tasks;

        public HomeController(IEnumerable<IApplicationTask> tasks, ILogger<HomeController> logger)
        {
            this.logger = logger;
            logger.LogInformation("Constructiong controller");
            this.tasks = tasks.ToList();
        }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
        public IActionResult Index()
        {
            logger.LogInformation("Getting index data");
            return View(tasks.Select(t => t.Name));
        }
    }
}