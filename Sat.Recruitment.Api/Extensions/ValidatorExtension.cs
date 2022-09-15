using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Api.Models.Request;
using Sat.Recruitment.Api.Validators;

namespace Sat.Recruitment.Api.Extensions
{
    public static class ValidatorExtension
    {
        public static void AddValidatorInjection(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UserRequest>, UserValidator>();
        }
    }
}
