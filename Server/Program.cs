using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Min_Helpers.LogHelper;
using Min_Helpers.PrintHelper;

namespace Server
{
    public class Program
    {
        public static Print PrintService { get; set; } = null;

        public static Log LogService { get; set; } = null;

        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");

#if DEBUG
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
#else
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Production");
#endif

            LogService = new Log();
            LogService.LogPath = $"{AppDomain.CurrentDomain.BaseDirectory}logs";
            LogService.LogFileName = $"{DateTime.Now.ToString("yyyyMMddHHmmss")}-{{{{type}}}}-{{{{date}}}}-{{{{index}}}}.log";
            PrintService = new Print(LogService);

            PrintService.Log("App Start", Print.EMode.info);

            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel();
                    webBuilder.UseStartup<Startup>();
                })
                .Build()
                .Run();
        }
    }
}
