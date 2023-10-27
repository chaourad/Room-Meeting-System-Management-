

namespace GestiondesSalles.ExceptionHandlerMidls.FloorException
{
    public class FloorNotFoundException : CustomException.CustomException
    {
        public FloorNotFoundException(string message, int status) : base(message, status)
        {
        }
    }
}