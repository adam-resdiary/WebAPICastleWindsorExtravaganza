using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Facilities.TypedFactory;

namespace HandheldServer.DIInstallers
{
    public class SomethingProviderInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {//commented out 1/7/2014
            //container.Register(Classes.FromThisAssembly()
            //                       .BasedOn(typeof(ISomethingProvider))
            //                       .WithServiceAllInterfaces());
            //// From http://app-code.net/wordpress/?p=676; see also http://devlicio.us/blogs/krzysztof_kozmic/archive/2009/12/24/castle-typed-factory-facility-reborn.aspx
            //container.AddFacility<TypedFactoryFacility>();
            //container.Register(Component.For<IMyFirstFactory>().AsFactory()); 
        }

        //// From http://app-code.net/wordpress/?p=676
        //public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        //{
        //    container.AddFacility<TypedFactoryFacility>();
        //    container.Register(Component.For<IMyFirstFactory>().AsFactory()); 
        //    //container
        //    //    .Register(Component.For<IStartPageModel>().ImplementedBy<StartPageModel>().LifestyleTransient())
 
        //    //    .Register(Component.For<IStartPageViewModel>().ImplementedBy<StartPageViewModel>().LifestyleTransient())
 
        //    //    .Register(Component.For<IHeading>().ImplementedBy<Heading>().LifestyleTransient())
 
        //    //    .Register(Component.For<IShell>().ImplementedBy<Shell>().LifestyleTransient())
 
        //    //    .Register(Component.For<MainWindow>().LifestyleTransient()); 
        //}

    }
}