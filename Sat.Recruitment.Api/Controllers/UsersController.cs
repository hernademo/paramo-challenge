using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Api.Interfaces;
using Sat.Recruitment.Api.Models.Request;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {

        private readonly IUserApiService _service;

        public UsersController(IUserApiService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<IActionResult> CreateUser(UserRequest user)
        {
            try
            {
                if (user == null)
                {
                    return NotFound();
                }

                await this._service.Add(user);

                return Ok("User Created");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
