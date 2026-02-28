using Microsoft.EntityFrameworkCore;
using Subscription.Infra.Data.Contexts;

namespace Subscription.Api.Extensions
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Método para adicionar as dependências da infraestrutura, como repositórios, contextos, etc.
        /// </summary>        
        public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Configurar o DbContext do Entity Framework
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                    //Obter a string de conexão do arquivo de configuração (appsettings.json)
                    configuration.GetConnectionString("DefaultConnection")
                ));

            return services;
        }
    }
}
