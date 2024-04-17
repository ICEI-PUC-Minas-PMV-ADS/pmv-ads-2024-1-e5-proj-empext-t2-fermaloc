using Fermaloc.Domain;
using Fermaloc.Application;
using Fermaloc.Infra.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

                services.AddCors(options =>
                {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                        builder.WithOrigins("http://localhost:3000").WithMethods("GET", "POST", "PUT", "DELETE").AllowAnyHeader();
                });
                });

                var key = Encoding.ASCII.GetBytes(configuration["jwt:secretKey"]);
                
                services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = new SymmetricSecurityKey(key),
                                ValidateIssuer = false,
                                ValidateAudience = false,
                                ClockSkew = TimeSpan.Zero
                        };
                });

                services.AddAuthorization();

                services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                services.AddScoped<IAdministratorRepository, AdministratorRepository>();
                services.AddScoped<IBannerRepository, BannerRepository>();
                services.AddScoped<ICategoryRepository, CategoryRepository>();
                services.AddScoped<IEquipamentRepository, EquipamentRepository>();
                services.AddScoped<IAuthenticateService, AuthenticateService>();
                services.AddScoped<IAdministratorService, AdministratorService>();
                services.AddScoped<IBannerService, BannerService>();
                services.AddScoped<ICategoryService, CategoryService>();
                services.AddScoped<IEquipamentService, EquipamentService>();
                
                services.AddTransient<IEmailService, EmailService>();
                return services;
        }
}
