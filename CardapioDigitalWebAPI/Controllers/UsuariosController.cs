using Microsoft.AspNetCore.Mvc;
using CardapioDigitalWebAPI.Interface;
using CardapioDigitalWebAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace CardapioDigitalWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosData _data;

        public UsuariosController(IUsuariosData data)
        {
            _data = data;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            try
            {
                var resultado = await _data.GetAllUsuarioAsync();
                return Ok(resultado);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            try
            {
                var resultado = await _data.GetUsuarioAsyncById(id);
                if (resultado == null) return NotFound(new { message = "Usuario não encontrado"});

                return Ok(resultado);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(string usr_login, string usr_password){
            try
            {
                byte[] senha = ASCIIEncoding.ASCII.GetBytes(usr_password);
                
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}