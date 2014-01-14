using System;
using Castle.Windsor;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace HandheldServer.DIPlumbing
{
    // Note this from the DI Whisperer:
    // So where do you use the DI Container? It should only be used in a Composition Root, which in your case would correspond to Global.asax. 
    // You can read a bit more about this in this SO answer (http://stackoverflow.com/questions/1410719/design-where-should-objects-be-registered-when-using-windsor/1410738#1410738)
    public class WindsorCompositionRoot : IHttpControllerActivator
    {
        private readonly IWindsorContainer container;

        public WindsorCompositionRoot(IWindsorContainer container)
        {
            this.container = container;
        }

        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller =
                (IHttpController)this.container.Resolve(controllerType);

            request.RegisterForDispose(
                new Release(
                    () => this.container.Release(controller)));

            return controller;
        }

        private class Release : IDisposable
        {
            private readonly Action release;

            public Release(Action release)
            {
                this.release = release;
            }

            public void Dispose()
            {
                this.release();
            }
        }
    }
}