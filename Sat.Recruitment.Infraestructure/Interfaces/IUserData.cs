using Sat.Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infraestructure.Interfaces
{
    public interface IUserData
    {
        Task Add(User user);
        Task<IList<User>> GetAll();
    }
}
