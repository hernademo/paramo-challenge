using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Interfaces;
using Sat.Recruitment.Domain.Services;
using Sat.Recruitment.Domain.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain
{
    public  class Startup
    {
        public static void Load(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMoneyStrategy, NormalMoneyStrategy>();
            services.AddTransient<IMoneyStrategy, PremiumMoneyStrategy>();
            services.AddTransient<IMoneyStrategy, SuperUserMoneyStrategy>();
        }
    }
}
