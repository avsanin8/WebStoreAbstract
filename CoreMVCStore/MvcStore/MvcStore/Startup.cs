using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MvcStore.Models;

//for v 2.1
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using MvcStore.Areas.Identity.Data;

namespace MvcStore
{
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
            //services.AddMvc();

            services.AddDbContext<ProductContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ProductContext")));
            // I trying to Add Configure services for use IIS and Kestrel servers.
            //To configure IISIntegration service options, include a service configuration for IISOptions in ConfigureServices
            //Help : https://docs.microsoft.com/en-us/aspnet/core/publishing/iis?tabs=aspnetcore2x
            services.Configure<IISOptions>(options => 
                options.AutomaticAuthentication = true
                );
            // Add framework services.
            //services.AddIdentity<IdentityUser, IdentityRole>() 
            ////services.AddDefaultIdentity<IdentityUser>()
            //.AddEntityFrameworkStores<UserContext>()
            //.AddDefaultTokenProviders();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddRazorPagesOptions(options =>
                {
                    options.AllowAreas = true;
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            //For https redirection
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 5001;
            });

            //services.AddHttpClient();
            services.AddHttpClient("github", c =>
            {
                c.BaseAddress = new Uri("https://api.github.com/");
                // Github API versioning
                c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                // Github requires a user-agent
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });

            // IHostingEnvironment (stored in _env) is injected into the Startup class.            
            //if (!_env.IsDevelopment())
            //{
            //    services.AddHttpsRedirection(options =>
            //    {
            //        options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
            //        options.HttpsPort = 443;
            //    });
            //}
            // using Microsoft.AspNetCore.Identity.UI.Services;
            services.AddSingleton<IEmailSender, EmailSender>();

            //Configure IdentityOptions
            services.Configure<IdentityOptions>(options => 
            {
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 10;
                options.Password.RequireDigit = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();
            // If the app uses Session or TempData based on Session:
            // app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
