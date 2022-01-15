using Microsoft.AspNetCore.Mvc;

namespace CardapioDigitalWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BebidasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(){
            return Ok("Bebidas");
        }
    }
}