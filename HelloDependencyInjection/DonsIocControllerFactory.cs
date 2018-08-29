using System;
using System.Web.Mvc;
using System.Web.Routing;
using DonsIOCContainer;

namespace HelloDependencyInjection
{
    public class DonsIocControllerFactory : DefaultControllerFactory
    {
        private readonly IocContainer _container;
        
        public DonsIocControllerFactory(IocContainer container)
        {
            _container = container;
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controllerType = Type.GetType($"HelloDependencyInjection.Controllers.{controllerName}Controller");

            IController controller = _container.Resolve(controllerType) as IController;
            return controller;
        }

        public override void ReleaseController(IController controller)
        {
            if (controller is IDisposable dispose)
            {
                dispose.Dispose();
            }
        }
    }
}