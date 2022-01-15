using Microsoft.AspNetCore.Mvc;

namespace CardapioDigitalWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(){
            return Ok("Pizzas");
        }
    }
}