
using System.Net;
using AutoMapper;
using GestiondesSalles.Data;
using GestiondesSalles.Dto.UserDto;
using GestiondesSalles.ExceptionHandlerMidls.UserException;
using GestiondesSalles.modals;
using GestiondesSalles.Repository.IRepository;
using GestiondesSalles.Utils;

namespace GestiondesSalles.Repository
{
    public class UserRepository : IUserRepository
    {
          private readonly AppDbContext _context;
          private readonly IMapper _mapper;
          public UserRepository(AppDbContext context , IMapper mapper){
            _context = context;
            _mapper = mapper;
          }

        public void Delete(Guid id)
        {
            User? user = _context.Users.Where(u => u.Id==id).FirstOrDefault();
            if(user is null){
                throw new UserNotFoundException(ErrorMessages.UserNotFoundException, (int) HttpStatusCode.NotFound);
            }
            _context.Users.Remove(user);
            int res = _context.SaveChanges();

             if (res == 0)
                throw new UserDeleteException(ErrorMessages.UserDeleteException, (int)HttpStatusCode.BadRequest);
        }

        
        public IEnumerable<ResponseUserDto> GetAll()=>
            _context.Users
            .Select(user => _mapper.Map<User,ResponseUserDto >(user));    
        

        public IEnumerable<User> GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public ResponseUserDto GetByUser(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}