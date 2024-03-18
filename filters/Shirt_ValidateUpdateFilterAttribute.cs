using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Models;

namespace WebApplication1.filters
{
    public class Shirt_ValidateUpdateFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var id = context.ActionArguments["id"] as int?;
            var shity = context.ActionArguments["shirt"] as Shirt;
            if (id.HasValue && shity !=null && id !=shity.ShirtId)
            {
                context.ModelState.AddModelError("shirt", "shirtid is not same as the id");
                var problemDetail = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetail);
            }

        }
    }
}
