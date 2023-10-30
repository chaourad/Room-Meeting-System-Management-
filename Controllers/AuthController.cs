
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using GestiondesSalles.Data;
using GestiondesSalles.Dto.UserDto;
using GestiondesSalles.ExceptionHandlerMidls.UserException;
using GestiondesSalles.modals;
using GestiondesSalles.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
namespace GestiondesSalles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public readonly AppDbContext _context;
        public readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            this._context = context;
            _configuration = configuration;

        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(RegisterDto request)
        {
            if (request is null)
                throw new UserNotFoundException(ErrorMessages.UserNotFoundException, (int)HttpStatusCode.NotFound);

            //if username already exist  
            User? u = _context.Users.Where(u => u.Username == request.Username).FirstOrDefault();
            if (u != null)
                throw new UserAlreadyExistException(ErrorMessages.UserAlreadyExistException, (int)HttpStatusCode.BadRequest);
            CreatePAsswordHAsh(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User userr = new()
            {
                Nom = request.Nom,
                Prenom = request.Prenom,
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "USER"
            };
            _context.Users.Add(userr);
            await _context.SaveChangesAsync();
            SendWelcomeEmail(request.Username, request.Password);


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
            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("nom", user.Nom),
                new Claim("username", user.Username),
                new Claim("role", user.Role)

            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
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
          private void SendWelcomeEmail(string userEmail, string password)
    {
       var smtpClient = new SmtpClient
{
    Host = _configuration.GetSection("Smtp:Host").Value, // Utilisez .Value pour obtenir la valeur en chaîne
    Port = int.Parse(_configuration.GetSection("Smtp:Port").Value),
    Credentials = new NetworkCredential(_configuration.GetSection("Smtp:Username").Value, _configuration.GetSection("Smtp:Password").Value), // Accédez aux valeurs de la même manière
    EnableSsl = bool.Parse(_configuration.GetSection("Smtp:EnableSsl").Value)
};

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_configuration.GetSection("Smtp:Username").Value),
            Subject = "Bienvenue sur notre site",
            Body = $"Bienvenue sur notre site. Votre e-mail : {userEmail}, Votre mot de passe : {password}"
        };

        mailMessage.To.Add(userEmail);

        smtpClient.Send(mailMessage);
    }
    }
}