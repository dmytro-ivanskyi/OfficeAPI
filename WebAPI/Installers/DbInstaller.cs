using Data.Abstraction.RepoInterfaces;
using Data.Abstraction.Services;
using Data.EF;
using Data.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Abstraction.ServiceInterfaces;
using Service.Services;

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
            services.AddScoped<IOfficeRepo, OfficeRepo>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepo, UserRepo>();

            //services.AddScoped<IPermissionService, PermissionService>();
            //services.AddScoped<IPermissionRepo, PermissionRepo>();

            //services.AddScoped<IUserPermissionService, UserPermissionService>();
            //services.AddScoped<IUserPermissionRepo, UserPermissionRepo>();

            //services.AddScoped<ITaskService, TaskService>();
            //services.AddScoped<ITaskRepo, TaskRepo>();
        }
    }
}
