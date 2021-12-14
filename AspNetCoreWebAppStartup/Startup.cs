using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace AspNetCoreWebAppStartup
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Console.WriteLine("Startup.ctor: Configuration = configuration;");
            Configuration = configuration;

            Console.WriteLine("Startup.ctor: __exit__");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("Startup.ConfigureServices: services.AddSingleton<SingletonClass>();");
            services.AddSingleton<SingletonClass>();

            Console.WriteLine("Startup.ConfigureServices: services.AddHostedService<HostedService>();");
            services.AddHostedService<HostedService>();

            Console.WriteLine("Startup.ConfigureServices: services.AddRazorPages();");
            services.AddRazorPages();

            Console.WriteLine("Startup.ConfigureServices: __exit__");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime appLifetime)
        {
            Console.WriteLine("Startup.Configure: if (env.IsDevelopment())");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopping.Register(OnStopping);
            appLifetime.ApplicationStopped.Register(OnStopped);

            Console.WriteLine("Startup.Configure: app.UseStaticFiles();");
            app.UseStaticFiles();

            Console.WriteLine("Startup.Configure: app.UseRouting();");
            app.UseRouting();

            Console.WriteLine("Startup.Configure: app.UseAuthorization();");
            app.UseAuthorization();

            Console.WriteLine("Startup.Configure: app.UseEndpoints(endpoints =>");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            //Console.WriteLine("Startup.Configure: app.ApplicationServices.GetService<SingletonClass>();");
            //app.ApplicationServices.GetService<SingletonClass>();

            Console.WriteLine("Startup.Configure: StaticClass.MethodTwo();");
            StaticClass.MethodTwo();

            Console.WriteLine("Startup.Configure: var initAfterConfigure = InitAfterConfigure();");
            var initAfterConfigure = InitAfterConfigure();

            Console.WriteLine("Startup.Configure: var taskAwaiter = initAfterConfigure.GetAwaiter();");
            var taskAwaiter = initAfterConfigure.GetAwaiter();

            Console.WriteLine("taskAwaiter.GetResult();");
            taskAwaiter.GetResult();

            Console.WriteLine("Startup.Configure: __exit__");
        }

        private void OnStarted()
        {
            Console.WriteLine("Startup.appLifetime.OnStarted");
        }

        private void OnStopping()
        {
            Console.WriteLine("Startup.appLifetime.OnStopping");
        }

        private void OnStopped()
        {
            Console.WriteLine("Startup.appLifetime.OnStopped");
        }

        private async Task InitAfterConfigure()
        {
            Console.WriteLine("Startup.InitAfterConfigure.Init: await Task.Delay(TimeSpan.FromSeconds(1));");
            await Task.Delay(TimeSpan.FromSeconds(1));

            Console.WriteLine("Startup.InitAfterConfigure: __exit__");
        }
    }
}
