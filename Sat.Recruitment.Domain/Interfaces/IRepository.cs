using Sat.Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task Add(T entity);
        Task<bool> Exist(T entity);

        Task<IList<T>> GetAll();
    }
}
