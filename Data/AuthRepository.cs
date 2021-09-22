using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieBuff.Models;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieBuff.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(DataContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;

        }

        /// <summary>
        /// This method logs in the user upon succesfully verifying that the given email and password value,
        /// that is hashed, match the stored values in the db. It returns a JWT upon success.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower().Equals(email.ToLower()));
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password.";
            }
            else
            {
                response.Data = CreateToken(user);
            }
            return response;
        }

        /// <summary>
        /// This method registers a new user account in the db. If the user info mathes an existing 
        /// user, the account is not created again. This method returns the new user id upon success.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            var response = new ServiceResponse<int>();
            if (await UserExists(user.Email))
            {
                response.Success = false;
                response.Message = "User already exists.";
                return response;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            response.Data = user.Id;
            return response;
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.Users.AnyAsync(u => u.Email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method creates a password hash and salt for the given password value using the
        /// HMAC SHA512 algorithm.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// This method verifies the password value sent by parameter and checks equality of hash with
        /// existing hashes in the db.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        /// <returns></returns>
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// This method creates a Jason Web Token with claims Naim Identifier, which represents the user id,
        /// and Name, which represents the user's email.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}