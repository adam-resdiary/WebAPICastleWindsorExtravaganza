using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Lifestyle;
using HandheldServer.Models;

namespace HandheldServer.DIInstallers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(//Classes.FromThisAssembly() //AllTypes.FromAssemblyNamed("Acme.Crm.Data")
            //                   //AllTypes.FromThisAssembly() //'Castle.MicroKernel.Registration.AllTypes' is obsolete: ''AllTypes' has been deprecated and will be removed in future releases. Use 'Classes' static class (if you want to just register concrete classes) or 'Types' static class (if you want to register interfaces or abstract classes too) instead. It exposes exactly the same methods.'
            //                   //Types.FromAssemblyNamed(this)
            //                   Types.FromThisAssembly()
            //                           //.Where(type => type.Name.EndsWith("Repository"))
            //                           .Where(type => type.Name.EndsWith("Controller"))
            //                           .WithService.DefaultInterfaces()
            //                           //.Configure(c => c.LifeStyle.PerWebRequest));
            //                           //.Configure(c => c.LifeStyle.PerWebRequest));
            //                           .Configure(c => c.LifestylePerWebRequest()));

            //container.Register(AllTypes.FromAssemblyNamed(this)
            //                .Where(type => type.Name.EndsWith("Repository"))
            //                .WithService.DefaultInterface()
            //                .Configure(c => c.LifeStyle.PerWebRequest));

            // Trying how it is in http://stackoverflow.com/questions/19905186/dependency-injection-in-webapi-with-castle-windsor
            container.Register(
              Component.For<IDepartmentRepository>().ImplementedBy<DepartmentRepository>()
            );
        }
    }
}