using GestiondesSalles.Dto.UserDto;
using GestiondesSalles.modals;

namespace GestiondesSalles.Repository.IRepository
{
    public interface IUserRepository
    {
        User Register(UserDto user);
    }
}