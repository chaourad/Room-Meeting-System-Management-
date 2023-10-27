namespace GestiondesSalles.ExceptionHandlerMidls.RoomException
{
    public class RoomNotFoundException : CustomException.CustomException
    {
        public RoomNotFoundException(string message, int status) : base(message, status)
        {
        }
    }
}