
using System.Threading.Tasks;
using GestiondesSalles.ExceptionHandlerMidls.CustomException;
using GestiondesSalles.ExceptionHandlerMidls.EquipementException;
using GestiondesSalles.ExceptionHandlerMidls.FloorException;
using GestiondesSalles.ExceptionHandlerMidls.RoomException;

namespace GestiondesSalles.ExceptionHandlerMidls
{
    public class ExceptionMidl : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (FloorNotFoundException e)
            {
                await WriteErrorMessage(e.Message,e.Status,context);
            }
            catch(RoomNotFoundException e){
                await WriteErrorMessage(e.Message,e.Status,context);
            }
            catch(RoomDeleteException e){
                await WriteErrorMessage(e.Message,e.Status,context);
            }
            catch(EquipementNotFoundException e){
                await WriteErrorMessage(e.Message, e.Status , context);
            }catch(EquipementDeleteException e){
                await WriteErrorMessage(e.Message,e.Status,context);
            }
            catch (Exception e)
            {
               await WriteErrorMessage(e.Message,500,context);
            }
        }

        private async Task WriteErrorMessage(string message, int status, HttpContext context)
        {
            context.Response.StatusCode = status;
            await context.Response.WriteAsJsonAsync(message);
        }
    }
}





   