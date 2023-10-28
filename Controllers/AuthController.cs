
using System.Net;
using System.Security.Cryptography;
using GestiondesSalles.Data;
using GestiondesSalles.Dto.UserDto;
using GestiondesSalles.ExceptionHandlerMidls.UserException;
using GestiondesSalles.modals;
using GestiondesSalles.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GestiondesSalles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public readonly AppDbContext _context;
        public AuthController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            if (request is null)
                throw new UserNotFoundException(ErrorMessages.UserNotFoundException, (int)HttpStatusCode.NotFound);
            CreatePAsswordHAsh(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User userr = new()
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "USER"

            };
            _context.Users.Add(userr);
            await _context.SaveChangesAsync();

            return Ok(userr);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserDto userDto)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == userDto.Username);

            if (user == null)
                throw new UserNotFoundException(ErrorMessages.UserNotFoundException, (int)HttpStatusCode.NotFound);

            if (!VerifyPasswordHAsh(userDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new PasswordNotFoundExcpetion(ErrorMessages.PasswordNotFoundExcpetion, (int)HttpStatusCode.NotFound);
            }
            return Ok("Login successful");
        }


        private bool VerifyPasswordHAsh(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private void CreatePAsswordHAsh(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }
    }
}