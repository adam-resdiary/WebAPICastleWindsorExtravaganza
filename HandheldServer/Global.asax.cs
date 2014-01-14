using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Http.Dispatcher;
using HandheldServer.DIPlumbing;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;

namespace HandheldServer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static IWindsorContainer _container;

        // May need to Register Castle Windsor here somewhere; see http://blog.ploeh.dk/2012/10/03/DependencyInjectioninASP.NETWebAPIwithCastleWindsor/
        protected void Application_Start()
        {
            //var container = new WindsorContainer();
            //GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(container);
            //GlobalConfiguration.Configuration.DependencyResolver config = new WindsorDependencyResolver(container);

            //// From http://blog.kerbyyoung.com/2013/01/setting-up-castle-windsor-for-aspnet.html#comment-form, but doesn't compile (config not declared)
            //IWindsorContainer container = new WindsorContainer();
            //container.Install(FromAssembly.This());
            //config.DependencyResolver = new WindsorDependencyResolver(container);
         

            // 1/6/2014 - test commenting out this:
            //AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //// From Dom:
            //BootstrapContainer();
            //// </ From Dom:

            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            // ...uncomment the above if the below works no better
            ConfigureWindsor(GlobalConfiguration.Configuration);

            // ... replacing it with this from http://stackoverflow.com/questions/19905186/dependency-injection-in-webapi-with-castle-windsor:

            // For some reason I had to call GlobalConfiguration.Configure instead of WebApiConfig.Register to avoid a 404.
            //WebApiConfig.Register(GlobalConfiguration.Configuration, _container);
            GlobalConfiguration.Configure(c => WebApiConfig.Register(c, _container));

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // ...new section replacing what's commented out
        }

        public static void ConfigureWindsor(HttpConfiguration configuration)
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());
            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel, true));
            var dependencyResolver = new WindsorDependencyResolver(_container);
            configuration.DependencyResolver = dependencyResolver;
        }   

        // Code that runs when an unhandled error occurs
        void Application_Error(object sender, EventArgs e)
        {
            // Get the exception object.
            Exception exc = Server.GetLastError();
            log.Error(exc.Message);
            // Clear the error from the server
            Server.ClearError();
        }

        // This is from Dom, but see http://stackoverflow.com/questions/1993397/abstract-factory-pattern-on-top-of-ioc
        // No longer being called
        private static void BootstrapContainer()
        {
            //// This is the example code from Castle Windsor docs:
            //var container = new WindsorContainer();
            //container.Install(
            //    new ControllersInstaller(),
            //    new RepositoriesInstaller(),
            //    // and all your other installers
            //);

            _container = new WindsorContainer().Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(_container.Kernel);

            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            //var repositoryFactory = new WindsorRepositoryFactory(container.Kernel); <-- no such thing, I guess...

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator), new WindsorCompositionRoot(_container));
        }

        protected void Application_End()
        {
            _container.Dispose();
            base.Dispose(); // from http://www.codeproject.com/Articles/350488/A-simple-POC-using-ASP-NET-Web-API-Entity-Framewor
        }
    }
}
