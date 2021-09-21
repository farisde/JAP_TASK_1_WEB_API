using Microsoft.AspNetCore.Mvc;
using MovieBuff.Data;
using MovieBuff.DTOs.User;
using MovieBuff.Models;
using System.Threading.Tasks;

namespace MovieBuff.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRepo.Register(
                new User { Name = request.Name, Email = request.Email },
                request.Password
            );

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
        {
            var response = await _authRepo.Login(
                request.Email, request.Password
            );

            return Ok(response);
        }
    }
}