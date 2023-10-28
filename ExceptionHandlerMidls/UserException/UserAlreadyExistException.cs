
namespace GestiondesSalles.ExceptionHandlerMidls.UserException
{
    public class UserAlreadyExistException : CustomException.CustomException
    {
        public UserAlreadyExistException(string message, int status) : base(message, status)
        {
        }
    }
}