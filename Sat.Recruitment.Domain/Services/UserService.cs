using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Factories;
using Sat.Recruitment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUser(User user)
        {
            if (user != null)
            {
                if (await this._userRepository.Exist(user))
                {
                    throw new Exception("User duplicated");
                }

                var moneyStrategy = MoneyFactory.Get(user.Type.ToString());
                user.Money = moneyStrategy.Calculate(user.Money);

                await this._userRepository.Add(user);

                user.Id = Guid.NewGuid();

                Debug.WriteLine("User Created");             
            }

            return user;
        }
    }
}
