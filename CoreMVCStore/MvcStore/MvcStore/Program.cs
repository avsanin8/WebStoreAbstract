﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using MvcStore.Models;

namespace MvcStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //BuildWebHost(args).Run(); // v 2.0
            //var host = BuildWebHost(args); 

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        //Rquires using MvcStore.Models;
            //        SeedData.Initialize(services);
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred seeding the DB.");
            //    }
            //}
            //host.Run();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSetting("https_port", "8080")
                .UseStartup<Startup>();

        //public static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build(); // v2.0
    }
}
