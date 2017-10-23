using CustomIdentetyApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// change namespace from CustomIdentetyApp.App_Start to CustomIdentetyApp
// and added Atribute
[assembly: OwinStartup(typeof(CustomIdentetyApp.MyStartup))]
namespace CustomIdentetyApp
{
    public class MyStartup
    {
        public void Configuration(IAppBuilder iapp)
        {
            //set up Context and Manager
            iapp.CreatePerOwinContext<ApplicationContext>(ApplicationContext.Create);
            iapp.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            iapp.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/login")
            });
        }
    }
}