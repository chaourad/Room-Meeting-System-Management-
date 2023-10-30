
namespace GestiondesSalles.Dto.UserDto
{
    public class RegisterDto
    {
        public string? Prenom { get; set; } = string.Empty;
        public string? Nom { get; set; } = string.Empty;
        public string  Username { get; set; }= string.Empty;
        public string Password { get; set; }= string.Empty;

    }
}