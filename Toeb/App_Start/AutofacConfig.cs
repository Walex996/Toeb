using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Toeb.BusinessLogic.Services;
using Toeb.DataAccess.EF;
using Toeb.DataAccess.GenericRepository;
using Toeb.DataAccess.Repositories;

namespace Toeb
{
    public class AutofacConfig
    {
        public static void RegisterDI()
        {
            var builder = new ContainerBuilder();
            var builder2 = new ContainerBuilder();

            builder2.RegisterApiControllers(Assembly.GetExecutingAssembly()); //from vid

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            builder.RegisterHttpRequestMessage(GlobalConfiguration.Configuration);
            builder.RegisterFilterProvider();

            builder2.RegisterType<StateService>().AsSelf().InstancePerRequest();
           
            builder.RegisterType<ToebEntities>().As<DbContext>().InstancePerRequest();  
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(EstateRepository).Assembly)
                .Where(t => t.Namespace != null && t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(typeof(EstateService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            //builder.RegisterModule(new EFModule());
            //builder.RegisterModule(new RepositoryModule());
           // builder.RegisterModule(new ServiceModule());

            var container = builder2.Build();
            var resolver =  new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }

    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var repositoryAssemblies = typeof(EstateRepository).Assembly;
            builder.RegisterAssemblyTypes(repositoryAssemblies)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }

    public class ServiceModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(typeof(EstateService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

        }

    }

    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterType(typeof(ToebEntities)).As(typeof(DbContext)).InstancePerRequest();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();
        }

    }
}