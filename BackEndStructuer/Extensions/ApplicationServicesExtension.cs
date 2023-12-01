using System.Globalization;
using e_parliament.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using BackEndStructuer.DATA;
using BackEndStructuer.Helpers;
using BackEndStructuer.Helpers.OneSignal;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using NewEppBackEnd.Services;

namespace BackEndStructuer.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(UserMappingProfile).Assembly);
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IArticleServices, ArticleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<AuthorizeActionFilter>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IGovernmentService, GovernmentService>();
            services.AddScoped<IStorageService, StorageService>();

            return services;
        }
    }
}