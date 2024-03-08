using Fermaloc.Domain;
using Fermaloc.Application;
using Fermaloc.Infra.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Fermaloc.Infra.IoC;

public class DependencyContainer
{
        public static IServiceCollection RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<ApplicationDbContext>
                (opts =>
                {
                        opts.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                });

                services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                services.AddScoped<IAdministratorRepository, AdministratorRepository>();
                services.AddScoped<IBannerRepository, BannerRepository>();
                services.AddScoped<ICategoryRepository, CategoryRepository>();
                services.AddScoped<IEquipamentRepository, EquipamentRepository>();

                services.AddScoped<IAdministratorService, AdministratorService>();
                services.AddScoped<IBannerService, BannerService>();
                services.AddScoped<ICategoryService, CategoryService>();
                services.AddScoped<IEquipamentService, EquipamentService>();

                return services;
        }
}
