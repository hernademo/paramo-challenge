using AutoMapper;
using FluentValidation;
using Sat.Recruitment.Api.Interfaces;
using Sat.Recruitment.Api.Models.Request;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Services
{

    public class UserApiService : IUserApiService
    {
        private readonly IValidator<UserRequest> _validator;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserApiService(IValidator<UserRequest> validator, IUserService userService, IMapper mapper)
        {
            _validator = validator;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<string> Add(UserRequest userRequest)
        {
            this._validator.ValidateAndThrow(userRequest);

            var user = this._mapper.Map<User>(userRequest);

            if (user == null)
            {
                throw new Exception("Invalid user");
            }

            var userCreated = await this._userService.CreateUser(user);

            return userCreated.Id.ToString();
        }
    }
}
