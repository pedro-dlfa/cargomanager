using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace CargoManager.Api.Platform.Http.ExceptionHandlers
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new InternalServerErrorResult(context.Request);
        }
    }
}