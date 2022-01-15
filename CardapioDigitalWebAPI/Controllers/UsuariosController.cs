using Microsoft.AspNetCore.Mvc;

namespace CardapioDigitalWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(){
            return Ok("Usuario");
        }
    }
}