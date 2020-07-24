using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Data;
using WebAPI.Data.Repositories;
using WebAPI.Services;
using WebAPI.Services.Interfaces.RepoInterfaces;
using WebAPI.Services.Interfaces.ServiceInterfaces;

namespace WebAPI.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IOfficeSQLRepo, OfficeSQLRepo>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserSQLRepo, UserSQLRepo>();

            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IPermissionSQLRepo, PermissionSQLRepo>();
        }
    }
}
