
namespace GestiondesSalles.Dto.UserDto
{
    public class ResponseUserDto
    {        
        public string? Prenom { get; set; } = string.Empty;

        public string? Nom { get; set; } = string.Empty;
        public string?  Username { get; set; }= string.Empty;
        public string?  Role { get; set; }= string.Empty;   
    }
}