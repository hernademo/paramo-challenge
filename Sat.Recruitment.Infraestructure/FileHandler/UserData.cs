using Microsoft.Extensions.Configuration;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Infraestructure.Factories;
using Sat.Recruitment.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infraestructure.FileHandler
{
    public class UserData : IUserData
    {
        private readonly string _path;

        public UserData(IConfiguration configuration)
        {
            this._path = Directory.GetCurrentDirectory() + configuration["UserFile"];
        }

        public UserData(string path)
        {
            _path = path;
        }

        public async Task Add(User user)
        {
            await Task.FromResult(true);
        }

        public async Task<IList<User>> GetAll()
        {
            var result = new List<User>();

            var rows = await File.ReadAllLinesAsync(this._path);

            foreach (var item in rows)
            {
                result.Add(UserFactory.CreateFromString(item));
            }

            return result;
        }


    }
}
