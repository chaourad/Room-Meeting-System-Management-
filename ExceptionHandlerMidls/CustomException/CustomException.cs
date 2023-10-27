namespace GestiondesSalles.ExceptionHandlerMidls.CustomException
{
    public class CustomException : Exception
    {

        private int _status;
        public CustomException(string message, int status) : base(message){
            _status = status;
        }


        public int Status => _status;
    }
}