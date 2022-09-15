using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Interfaces;
using Sat.Recruitment.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace Sat.Recruitment.Infraestructure.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly IUserData _userData;

        public UserRepository(IUserData userData)
        {
            _userData = userData;
        }

        public async Task<IList<User>> GetAll()
        {
            var result = await this._userData.GetAll();

            return result;
        }

        public async Task Add(User user)
        {
            await this._userData.Add(user);
        }

        public async Task<bool> Exist(User user)
        {
            var users = await this._userData.GetAll();

            return   users.Any(x => x.Email.Equals(user.Email) || x.Name.Equals(user.Name));
        }
    }
}
