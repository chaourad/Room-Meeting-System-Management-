
namespace GestiondesSalles.ExceptionHandlerMidls.UserException
{
    public class UserDeleteException : CustomException.CustomException
    {
        public UserDeleteException(string message, int status) : base(message, status)
        {
        }
    }
}