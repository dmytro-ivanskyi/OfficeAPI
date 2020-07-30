using Data.Abstraction.RepoInterfaces;
using Data.Abstraction.Services;
using Data.Dapper;
using Data.Dapper.Repositories;
using Data.EF;
using Data.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Abstraction.ServiceInterfaces;
using Service.Services;
using System;

namespace WebAPI.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            
            var dataProvider = configuration.GetValue<string>("DataProvider");
            if (dataProvider == "EF")
            {
                services.AddDbContext<DataContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                });

                services.AddScoped<IOfficeRepo, OfficeRepo>();
                services.AddScoped<IUserRepo, UserRepo>();
                services.AddScoped<IPermissionRepo, PermissionRepo>();
                services.AddScoped<IUserPermissionRepo, UserPermissionRepo>();
                services.AddScoped<ITaskRepo, TaskRepo>();
            }
            else
            {
                services.AddScoped<SqlServerConnectionProvider>();

                services.AddScoped<IOfficeRepo, OfficeDapperRepo>();
                services.AddScoped<IUserRepo, UserDapperRepo>();
            }



            services.AddScoped<IOfficeService, OfficeService>();
            
            services.AddScoped<IUserService, UserService>();
            
            //services.AddScoped<IPermissionService, PermissionService>();
           
            //services.AddScoped<IUserPermissionService, UserPermissionService>();
    
            //services.AddScoped<ITaskService, TaskService>();
     
        }
    }
}
