using IpekStore.Web.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IpekStore.Web.DependencyExtensions
{
    public static class DbExtensions
    {

        static IConfiguration Configuration
        {
            get
            {
                var builder = new ConfigurationBuilder()
            .AddJsonFile("appSettings.json");
                return builder.Build();
            }
        }

        public static IServiceCollection AddSqlServerLocalDbContext(this IServiceCollection services)
        {           

            //Sql Server için Context servisleri DI ekleniyor
            services.AddDbContext<IpekContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("IpekConnectionLocal"));
            });

            return services;
        }
    }
}
