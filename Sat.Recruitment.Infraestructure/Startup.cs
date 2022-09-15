using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Interfaces;
using Sat.Recruitment.Infraestructure.FileHandler;
using Sat.Recruitment.Infraestructure.Interfaces;
using Sat.Recruitment.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Infraestructure
{
    public class Startup
    {
        public static void Load(IServiceCollection services)
        {
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IUserData, UserData>();
        }
    }
}
