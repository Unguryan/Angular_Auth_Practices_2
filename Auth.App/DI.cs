using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Auth.App
{
    public static class DI
    {
        public static void AddAssembly(this IServiceCollection services)
        {
            var assebmly = Assembly.GetExecutingAssembly();

            services.AddMediatR(assebmly);
            services.AddAutoMapper(assebmly);
        }
    }
}
