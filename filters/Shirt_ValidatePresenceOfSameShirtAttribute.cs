using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Models.Repositories;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.filters
{
    public class Shirt_ValidatePresenceOfSameShirtAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var shirt = context.ActionArguments["shirt"] as Shirt;
            if (shirt == null)
            {
                context.ModelState.AddModelError("Shirt", "Shirt object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingshirt = ShirtRepository.GetShirtByProperties(shirt.Brand, shirt.Gender, shirt.Color, shirt.Size);
                if (existingshirt != null) {
                    context.ModelState.AddModelError("Shirt", "Shirt already exists");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }

            /*
            */
        }
    }
}
