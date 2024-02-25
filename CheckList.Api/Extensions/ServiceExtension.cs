using Checklist.Infra;
using Microsoft.EntityFrameworkCore;

namespace CheckList.Api.Extension
{
    public static class ServiceExtension
    {
        /// <summary>
        /// Registro do DbContext da aplicação
        /// </summary>
        /// <param name="services">Parametro do tipo IServiceCollection</param>
        /// <param name="configuration">Parametro de Configuração tipo IConfiguration</param>
        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("CheckListSqlConnectionString")));
        }

        //public static void AddRepositories(this IServiceCollection services, Assembly assembly)
        //{
        //    var repositoryTypes = assembly.GetTypes()
        //        .Where(type => !type.IsAbstract && !type.IsInterface && type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IContextEntity<>)));

        //    // filter out RepositoryBase<>
        //    var nonBaseRepos = repositoryTypes.Where(t => t != typeof(RespositoryBase<>));

        //    foreach (var repositoryType in nonBaseRepos)
        //    {
        //        var interfaces = repositoryType.GetInterfaces()
        //            .Where(@interface => @interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(IRepositoryBase<>))
        //            .ToList();

        //        if (interfaces.Count != 1)
        //        {
        //            throw new InvalidOperationException($"Repository '{repositoryType.Name}' must implement only one interface that implements IRepositoryBase<T>.");
        //        }

        //        services.AddScoped(interfaces[0], repositoryType);
        //    }

        //    services.AddScoped<IUnitOfWork, UnitOfWork>();
        //}
    }
}
