
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Models.Repositories;

namespace WebApplication1.filters
{
    public class Shirt_ValidateShirtIdFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var shirteId = context.ActionArguments["id"] as int?;
            if (shirteId.HasValue)
            {
                if (shirteId.Value <= 0)
                {
                    context.ModelState.AddModelError("shirteId", "shirteId is invalid");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!ShirtRepository.shirtExists(shirteId.Value))
                {
                    context.ModelState.AddModelError("shirteId", "shirteId doesnt exist");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }

    }
}
