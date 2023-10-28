namespace GestiondesSalles.ExceptionHandlerMidls.EquipementException
{
    public class EquipementNotFoundException  : CustomException.CustomException
    {
        public EquipementNotFoundException(string message, int status) : base(message, status)
        {
        }
    }
}