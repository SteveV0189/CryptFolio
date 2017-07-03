using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using FluentScheduler;
using CryptFolio.Models;

namespace CryptFolio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            var reg = new Registry();
            reg.Schedule<RetrieveCoinPricesJob>().ToRunNow().AndEvery(20).Seconds();
            JobManager.Initialize(reg);
            host.Run();
        }
    }
}
