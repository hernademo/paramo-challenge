using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Api.Interfaces;
using Sat.Recruitment.Api.Services;

namespace Sat.Recruitment.Api.Extensions
{
    public static class InjectionExtension
    {
        public static void AddInjection(this IServiceCollection services)
        {
            Domain.Startup.Load(services);
            Infraestructure.Startup.Load(services);

            services.AddValidatorInjection();

            services.AddTransient<IUserApiService, UserApiService>();
        }
    }
}
