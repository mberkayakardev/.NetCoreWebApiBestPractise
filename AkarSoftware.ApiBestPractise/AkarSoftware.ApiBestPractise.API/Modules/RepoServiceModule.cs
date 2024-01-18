using AkarSoftware.ApiBestPractise.Core.Repositories;
using AkarSoftware.ApiBestPractise.Core.Services;
using AkarSoftware.ApiBestPractise.Core.UnitOfWorks;
using AkarSoftware.ApiBestPractise.Repository;
using AkarSoftware.ApiBestPractise.Repository.Repositories;
using AkarSoftware.ApiBestPractise.Repository.UnitOfWork;
using AkarSoftware.ApiBestPractise.Services.MappingProfiles;
using AkarSoftware.ApiBestPractise.Services.Services;
using Autofac;
using System.Reflection;

namespace AkarSoftware.ApiBestPractise.API.Modules
{
    public class RepoServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();


            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(ProductMappingProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();










        }
    }
}
