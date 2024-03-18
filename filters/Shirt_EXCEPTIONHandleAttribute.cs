using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Models.Repositories;

namespace WebApplication1.filters
{
    public class Shirt_EXCEPTIONHandleAttribute:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            var strshirtid = context.RouteData.Values["id"] as string;
            if(int.TryParse(strshirtid, out int shirtId))
            {
                if (!ShirtRepository.shirtExists(shirtId))
                {
                    context.ModelState.AddModelError("shirtId", "it does not exist anymore");
                    var problemDetail = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetail);
                }
            }
        }
    }
}
