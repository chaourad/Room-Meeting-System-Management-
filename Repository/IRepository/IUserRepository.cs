
using GestiondesSalles.Dto.UserDto;
using GestiondesSalles.modals;

namespace GestiondesSalles.Repository.IRepository
{
    public interface IUserRepository
    {
        ResponseUserDto GetByUser(Guid id);
        IEnumerable<ResponseUserDto> GetAll();
        IEnumerable<User> GetAllEmployee();
        void Delete(Guid id);

    }
}