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

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerMatchingLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerMatchingLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();


            var ApiAssembly = Assembly.GetExecutingAssembly();
            var RepoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var ServicesAssembly = Assembly.GetAssembly(typeof(ProductMappingProfile));


            builder.RegisterAssemblyTypes(ApiAssembly, RepoAssembly, ServicesAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerMatchingLifetimeScope();
            builder.RegisterAssemblyTypes(ApiAssembly, RepoAssembly, ServicesAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerMatchingLifetimeScope();



        }
    }
}
