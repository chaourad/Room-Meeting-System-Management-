
namespace GestiondesSalles.ExceptionHandlerMidls.EquipementException
{
    public class EquipementDeleteException  : CustomException.CustomException
    {
        public EquipementDeleteException(string message, int status) : base(message, status)
        {
        }
    }
}