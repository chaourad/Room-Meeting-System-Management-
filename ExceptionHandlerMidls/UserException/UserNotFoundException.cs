
namespace GestiondesSalles.ExceptionHandlerMidls.UserException
{
    public class UserNotFoundException : CustomException.CustomException
    {
        public UserNotFoundException(string message, int status) : base(message, status)
        {
        }
    }
}