using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Data.Repositories;

namespace CRUDMongo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof (MvcApplication).Assembly);
            //builder.RegisterModule<AutofacWebTypesModule>();
            //builder.RegisterSource(new ViewRegistrationSource());
            //builder.RegisterFilterProvider();

            builder.RegisterType<LibraryRepository>()
                   .As<ILibraryRepository>()
                   .WithParameters(new List<Parameter>
                       {
                           new NamedParameter("connectionString",
                                              ConfigurationManager.ConnectionStrings["MongoServer"].ConnectionString),
                           new NamedParameter("dbName",
                                              ConfigurationManager.AppSettings["libraryDbName"])
                       });

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }
}