using Sat.Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Infraestructure.Factories
{
    internal static class UserFactory
    {
        public static User CreateFromString(string userLine)
        {
            return new User
            {
                Id = Guid.NewGuid(), 
                Name = userLine.Split(',')[0].ToString(),
                Email = userLine.Split(',')[1].ToString(),
                Address = userLine.Split(',')[2].ToString(),
                Phone = userLine.Split(',')[3].ToString(),
                Type = Enum.Parse<UserType>(userLine.Split(',')[4].ToString()),
                Money = decimal.Parse(userLine.Split(',')[5].ToString())
            };
        }
    }
}
