using Checklist.Infra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CheckList.Api.Extension
{
    /// <summary>
    /// Extension Class for every Service neeeded.
    /// </summary>
    public static class ServiceExtension
    {
        /// <summary>
        /// Registrando serviço do Contexto de Banco de Dados.
        /// </summary>
        /// <param name="services"></param>
        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("CheckListSqlConnectionString")));
        }
    }
}
