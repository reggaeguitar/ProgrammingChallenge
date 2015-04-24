using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProgrammingChallenge
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using DataAccessLayer;

    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;

        private static void SetupWindsorContainer()
        {
            _container = new WindsorContainer();

            _container.Register(Classes.FromThisAssembly()
                .BasedOn<IController>()
                .LifestyleTransient());

            _container.Register(Classes.FromThisAssembly()
               .InNamespace("ProgrammingChallenge", includeSubnamespaces: true)
               .WithService.DefaultInterfaces()
               .LifestyleTransient());

            // Register classes in DataAccessLayer
            _container.Register(Classes.FromAssemblyContaining<ProgrammingChallengeContext>()
                .IncludeNonPublicTypes()
                .InNamespace("DataAccessLayer", includeSubnamespaces: true)
                .WithService.DefaultInterfaces()
                .LifestyleTransient());

            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SetupWindsorContainer();
        }

        protected void Application_End()
        {
            _container.Dispose();
        }
    }
}
