using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace WebCore_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var host = WebHost.Start("http://localhost:8080",
                context => context.Response.WriteAsync("HeloWebHost")))
            {
                Console.WriteLine("App has been Started...");
                host.WaitForShutdown();
            }
                //BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
