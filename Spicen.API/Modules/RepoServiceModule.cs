using Autofac;
using Spicen.Core.Repositories;
using Spicen.Core.Services;
using Spicen.Core.UnitOfWorks;
using Spicen.Repository;
using Spicen.Repository.Repositories;
using Spicen.Repository.UnitOfWorks;
using Spicen.Service.Mapping;
using Spicen.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace Spicen.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // DI for generics => first class then interface
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            // DI for UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            // it will take the assembly from any class at data (repository) layer
            // same for service assembly
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MappingProfile));

            // DI finishing with repository keywords
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // InstancePerLifetimeScope => scope
            // InstancePerDependency => transient (create new instance where ever implement from this interface )

            // DI finishing with service keywords
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
