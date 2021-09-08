using System.Threading.Tasks;
using JAP_TASK_1_WEB_API.Data;
using JAP_TASK_1_WEB_API.DTOs.User;
using JAP_TASK_1_WEB_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace JAP_TASK_1_WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRepo.Register(
                new User { Name = request.Name, Email = request.Email },
                request.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
        {
            var response = await _authRepo.Login(
                request.Email, request.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}