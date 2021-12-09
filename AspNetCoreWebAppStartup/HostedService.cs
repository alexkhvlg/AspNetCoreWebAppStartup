using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreWebAppStartup
{
    public class HostedService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("HostedService.StartAsync: await Task.Delay(TimeSpan.FromSeconds(1));");
            await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            
            Console.WriteLine("HostedService.StartAsync: __exit__");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("HostedService.StopAsync: await Task.Delay(TimeSpan.FromSeconds(1));");
            await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);

            Console.WriteLine("HostedService.StopAsync: __exit__");
        }
    }
}
