
using System;
using System.Web;

using Microsoft.Web.Infrastructure.DynamicModuleHelper;

using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using HomeStoreAbstract.Infrastructure;

//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
//[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]
////What's happening is that you're bitten by this problem.Basically, what happened is that you didn't register your controllers explicitly in your container.
////Unity tries to resolve unregistered concrete types for you, but because it can't resolve it (caused by an error in your configuration),
////it return null. It is forced to return null, because Web API forces it to do so due to the IDependencyResolver contract. 
////Since Unity returns null, Web API will try to create the controller itself, 
////but since it doesn't have a default constructor it will throw the "Make sure that the controller has a parameterless public constructor" exception.
////This exception message is misleading and doesn't explain the real cause.
////You would have seen a much clearer exception message if you registered your controllers explicitly, and that's why you should always register all root types explicitly.
////But of course, the configuration error comes from you adding the second constructor to your DbContext. 
////Unity always tries to pick the constructor with the most arguments, but it has no idea how to resolve this particular constructor.
////So the real cause is that you are trying to use Unity's auto-wiring capabilities to create the DbContext. DbContext is a special type that shouldn't be auto-wired.
////It is a framework type and you should therefore fallback to registering it using a factory delegate:
////container.Register<DashboardDbContext>(new InjectionFactory(c => new DashboardDbContext())); 
public static class NinjectWebCommon 
{
    private static readonly Bootstrapper bootstrapper = new Bootstrapper();

    /// <summary>
    /// Starts the application
    /// </summary>
    public static void Start() 
    {
        DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
        DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        bootstrapper.Initialize(CreateKernel);
    }
        
    /// <summary>
    /// Stops the application.
    /// </summary>
    public static void Stop()
    {
        bootstrapper.ShutDown();
    }
        
    /// <summary>
    /// Creates the kernel that will manage your application.
    /// </summary>
    /// <returns>The created kernel.</returns>
    private static IKernel CreateKernel()
    {
        var kernel = new StandardKernel();
        try
        {
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }
        catch
        {
            kernel.Dispose();
            throw;
        }
    }
    
    /// <summary>
    /// Load your modules or register your services here!
    /// </summary>
    /// <param name="kernel">The kernel.</param>
    private static void RegisterServices(IKernel kernel)
    {
        System.Web.Mvc.DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
    }        
}

