using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestiondesSalles.ExceptionHandlerMidls.FloorException
{
    public class FloorDeleteException : CustomException.CustomException
    {
        public FloorDeleteException(string message, int status) : base(message, status)
        {
        }
    }
}