namespace ManagedTasks.WebApp
{
    using ManagedTasks.WebApp.Decorators;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Steeltoe.Management.Endpoint.Hypermedia;
    using Steeltoe.Management.TaskCore;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTask<LogApplicationTaskDecorator<DelayApplicationTaskDecorator<HelloWorldTask>>>();
            services.AddTask<LogApplicationTaskDecorator<DelayApplicationTaskDecorator<MerryXmasWorldTask>>>();
            services.AddTask<LogApplicationTaskDecorator<DelayApplicationTaskDecorator<HappyNewYearTask>>>();
            services.AddTask<LogApplicationTaskDecorator<DelayApplicationTaskDecorator<GoodByeWorldTask>>>();
            services.AddTask<LogApplicationTaskDecorator<DelayApplicationTaskDecorator<AllGreetingsAggregateApplicationTask>>>();            
            services.AddTask<LogApplicationTaskDecorator<DelayApplicationTaskDecorator<ForceExceptionTask>>>();

            services.AddControllersWithViews();
            services.AddHypermediaActuator(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}