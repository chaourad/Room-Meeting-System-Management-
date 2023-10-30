
using GestiondesSalles.Dto.UserDto;
using GestiondesSalles.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GestiondesSalles.Controllers
{
    public class UserController : ControllerBase
    {
     private readonly IUserRepository _userRepository;   

     public UserController(IUserRepository userRepository){
        _userRepository = userRepository;
     }

     [HttpGet("Users")]
     public  ActionResult<IEnumerable<ResponseUserDto>> GetAll() => Ok(_userRepository.GetAll());

     [HttpGet("User/{id:Guid}")]
     public ResponseUserDto GetById(Guid id) => _userRepository.GetByUser(id);
    }
}