using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Api.Models.Request;
using Sat.Recruitment.Api.Profiles;
using Sat.Recruitment.Api.Services;
using Sat.Recruitment.Api.Validators;
using Sat.Recruitment.Domain.Services;
using Sat.Recruitment.Infraestructure.FileHandler;
using Sat.Recruitment.Infraestructure.Repositories;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Sat.Recruitment.Infraestructure.Interfaces;
using System.Collections.Generic;
using Sat.Recruitment.Domain.Entities;
using System;
using FluentValidation;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        private readonly IMapper _mapper;
        private readonly UserApiService _userApiService;
        public UnitTest1()
        {

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            this._mapper = config.CreateMapper();

            var userData = new Mock<IUserData>();

            userData.Setup(x => x.GetAll())
                    .ReturnsAsync(GetMockUsers());

            userData.Setup(x => x.Add(It.IsAny<User>()));

            var repository = new UserRepository(userData.Object);
            var userService = new UserService(repository);
            this._userApiService = new UserApiService(new UserValidator(), userService, _mapper);
        }

        private IList<User> GetMockUsers()
        {
            return new List<User>
            {
                new User
                {
                    Name = "Juan",
                    Email = "Juan@marmol.com",
                    Phone = "+5491154762312",
                    Address = "Peru 2464",
                    Type = UserType.Normal,
                    Money = 1234
                },
                new User
                {
                    Name = "Franco",
                    Email = "Franco.Perez@gmail.com",
                    Phone = "+534645213542",
                    Address = "Alvear y Colombres",
                    Type = UserType.Premium,
                    Money = 112234
                },
                new User
                {
                    Name = "Agustina",
                    Email = "Agustina@gmail.com",
                    Phone = "+534645213542",
                    Address = "Garay y Otra Calle",
                    Type = UserType.SuperUser,
                    Money = 1234
                },
            };
        }
       
        [Fact]
        public async Task ShouldAddNewUserAndReturnId()
        {      
            var request = new UserRequest
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "124"
            };

            var id = await this._userApiService.Add(request);

            Assert.NotEmpty(id);
        }

        [Fact]
        public async Task ShouldReturnUserDuplicatedException()
        {
           
            var request = new UserRequest
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "124"
            };

            var exception = await Assert.ThrowsAsync<Exception>(() => this._userApiService.Add(request));
            Assert.Equal("User duplicated", exception.Message);
        }

        [Fact]
        public async Task ShouldReturnMissingDataException()
        {

            var request = new UserRequest
            {
                Name = string.Empty,
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "124"
            };

            await Assert.ThrowsAnyAsync<ValidationException>(() => this._userApiService.Add(request));
        }


    }
}
