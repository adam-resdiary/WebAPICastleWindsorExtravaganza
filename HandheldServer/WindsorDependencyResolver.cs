// Added this 12/24/2013; from http://blog.kerbyyoung.com/2013/01/setting-up-castle-windsor-for-aspnet.html#comment-form
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using System.Web.Http;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.SubSystems.Configuration;
using HandheldServer.Models;

namespace HandheldServer
{
    public class WindsorDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver // (NOT System.Web.Mvc.IDependencyResolver) - see http://blog.kerbyyoung.com/2013/01/setting-up-castle-windsor-for-aspnet.html 
    {
        private readonly IWindsorContainer _container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(_container);
        }

        public object GetService(Type serviceType)
        {
            //if (!_container.Kernel.HasComponent(serviceType))
            //{
            //    return null;
            //}
            //return this._container.Resolve(serviceType);
            return _container.Kernel.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            // This "not has component" part is from "Pro ASP.NET Web API" p. 426
            if (!_container.Kernel.HasComponent(serviceType))
            {
                return new object[0];
            }

            return _container.ResolveAll(serviceType).Cast<object>();
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }

    public class WindsorDependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer _container;
        private readonly IDisposable _scope;

        public WindsorDependencyScope(IWindsorContainer container)
        {
            this._container = container;
            this._scope = container.BeginScope(); 
        }

        public object GetService(Type serviceType)
        {
            if (_container.Kernel.HasComponent(serviceType))
            {
                return _container.Resolve(serviceType);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this._container.ResolveAll(serviceType).Cast<object>();
        }

        public void Dispose()
        {
            this._scope.Dispose();
        }
    }

    public class ApiControllersInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly() // should it be Types instead of Classes?
             .BasedOn<ApiController>()
             .LifestylePerWebRequest());
        }
    }

    // This idea from https://github.com/argeset/set-locale/blob/master/src/client/SetLocale.Client.Web/Configurations/IocConfig.cs
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
        }
    }
}