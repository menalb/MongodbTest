using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Data.Repositories;

namespace CRUDMongoWeb
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            
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
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}