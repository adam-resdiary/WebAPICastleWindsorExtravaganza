using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;
using Castle.Windsor.Installer;
// According to http://docs.castleproject.org/Windsor.Typed-Factory-Facility.ashx, might need this:
//using Castle.Facilities.TypedFactory; //<-- comment out, as commented out kernel.AddFacility<TypedFactoryFacility>() below...?

// See http://stackoverflow.com/questions/19338043/using-di-to-load-repository-instance-on-each-mvc-request
// for a different take on how to implement this
// See this: https://github.com/argeset/set-locale/blob/master/src/client/SetLocale.Client.Web/Configurations/IocConfig.cs
namespace HandheldServer.DIPlumbing
{
    public class WindsorControllerFactory : DefaultControllerFactory //- tried to comment out and replace below 1/7/2014, but then different methods need to be implemented
    //public class WindsorControllerFactory : InstallerFactory // <-- should it be this instead? (http://stackoverflow.com/questions/20914635/how-do-i-connect-the-various-pieces-of-my-web-api-castle-windsor-di-code?noredirect=1#comment31502440_20914635)
    {
        // According to http://docs.castleproject.org/Windsor.Typed-Factory-Facility.ashx, might need this:
        //using Castle.Facilities.TypedFactory;
        // Another way to implement DefaultControllerFactory is here:
        // https://github.com/mvccontrib/MvcContrib/blob/be0eb3addedf1775db719117e7fa73e516f74c8d/src/MvcContrib.Castle/WindsorControllerFactory.cs

        private readonly IKernel _kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            _kernel = kernel; 
            //According to http://docs.castleproject.org/Windsor.Typed-Factory-Facility.ashx, might need this:
            //_kernel.AddFacility<TypedFactoryFacility>(); // This breaks ("Typed factory facility already registered"), so commenting it out; see http://stackoverflow.com/questions/20914635/how-do-i-connect-the-various-pieces-of-my-web-api-castle-windsor-di-code
            //but that requires uncommenting the "TypedFactory" using above.
            // According to the answer by Cristiano Degiorgis here:
            // http://stackoverflow.com/questions/20914635/how-do-i-connect-the-various-pieces-of-my-web-api-castle-windsor-di-code?noredirect=1#comment31502440_20914635
            // that should not be here (I had already commented it out)
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }
            //return (IController)kernel.Resolve(controllerType);
            return (IController)_kernel.Resolve(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            //kernel.ReleaseComponent(controller);
            _kernel.ReleaseComponent(controller);
        }

    }
}