using Microsoft.AspNetCore.Mvc;
using WebApplication1.filters;
using WebApplication1.Models;
using WebApplication1.Models.Repositories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ShirtsController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetShirt()
        {
            return Ok(ShirtRepository.GetAllShirt());
        }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult GetShirtById(int id)
        {
            return Ok(ShirtRepository.shirtById(id));
        }
        [HttpPost]
        [Shirt_ValidatePresenceOfSameShirt]
        public IActionResult CreatingShirt([FromBody]Shirt shirt)
        {
            
            ShirtRepository.Addshirt(shirt);
            return CreatedAtAction(nameof(GetShirtById), new {id = shirt.ShirtId}, shirt);
        }
        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateFilterAttribute]
        [Shirt_EXCEPTIONHandleAttribute]
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {
            
            try
            {
                ShirtRepository.UpdateShirte(shirt);
                
            }
            catch (Exception ex)
            {
                if (!ShirtRepository.shirtExists(id))
                {
                    return NotFound();
                }
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult DeleteShirt(int id)
        {
            var shird = ShirtRepository.shirtById(id);
            ShirtRepository.DelteShirt(id);
            return Ok(shird);
        }
    }
}
