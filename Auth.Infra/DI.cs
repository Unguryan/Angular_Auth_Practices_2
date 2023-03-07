using Auth.App;
using Auth.App.Services;
using Auth.Infra.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infra
{
    public static class DI
    {
        public static void AddInfra(this IServiceCollection services)
        {
            services.AddAssembly();

            services.AddScoped<IEncodePasswordService, EncodePasswordService>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
