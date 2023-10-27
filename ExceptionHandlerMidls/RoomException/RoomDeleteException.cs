

namespace GestiondesSalles.ExceptionHandlerMidls.RoomException
{
    public class RoomDeleteException : CustomException.CustomException
    {
        public RoomDeleteException(string message, int status) : base(message, status)
        {
        }
    }
}