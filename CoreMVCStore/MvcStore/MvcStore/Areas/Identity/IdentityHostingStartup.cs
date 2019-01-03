using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcStore.Areas.Identity.Data;
using MvcStore.Models;

[assembly: HostingStartup(typeof(MvcStore.Areas.Identity.IdentityHostingStartup))]
namespace MvcStore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {            
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UserContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UserContextConnection"))); 
                services.AddDefaultIdentity<MvcStoreUser>()
                    .AddEntityFrameworkStores<UserContext>();
            });
        }
    }
}