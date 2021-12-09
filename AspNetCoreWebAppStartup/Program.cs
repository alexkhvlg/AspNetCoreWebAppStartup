using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAppStartup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Program.Main: CreateHostBuilder(args);");
            var hostBuilder = CreateHostBuilder(args);

            Console.WriteLine("Program.Main: hostBuilder.Build();");
            var build = hostBuilder.Build();

            Console.WriteLine("Program.Main: build.Run();");
            build.Run();

            Console.WriteLine("Program.Main: __exit__");
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            Console.WriteLine("Program.CreateHostBuilder: Host.CreateDefaultBuilder(args);");
            var defaultBuilder = Host.CreateDefaultBuilder(args);

            Console.WriteLine("Program.CreateHostBuilder: defaultBuilder.ConfigureWebHostDefaults(webBuilder =>");
            return defaultBuilder.ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
        }
    }
}
