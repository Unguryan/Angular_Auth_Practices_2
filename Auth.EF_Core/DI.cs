using Auth.App.Repositories;
using Auth.EF_Core.Context;
using Auth.EF_Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Auth.Infra
{
    public static class DI
    {
        public static void AddEFCore(this IServiceCollection services)
        {
            var assebmly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assebmly);

            services.AddDbContext<AuthContext>();

            services.AddScoped<IAuthRepository, AuthRepository>();
        }
    }
}
