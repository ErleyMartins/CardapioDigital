using Microsoft.AspNetCore.Mvc;
using CardapioDigitalWebAPI.Interface;
using CardapioDigitalWebAPI.Models;

namespace CardapioDigitalWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BebidasController : ControllerBase
    {
        private readonly IBebidasData _bebidaData;

        public BebidasController(IBebidasData bebidaData)
        {
            _bebidaData = bebidaData;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            try
            {
                var resultado = await _bebidaData.GetAllBebidasAsync();
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
                var resultado = await _bebidaData.GetBebidaAsyncById(id);
                if (resultado == null) return NotFound(new { message = "Bebida não encontrado!"});

                return Ok(resultado);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Bebidas bebidas){
            try
            {
                _bebidaData.Add(bebidas);
                if (await _bebidaData.SaveChangesAsync())
                    return Ok(bebidas);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Bebidas bebidas){
            try
            {
                var resultado = await _bebidaData.GetBebidaAsyncById(id);
                if (resultado == null) return NotFound(new { message = "Pizza não encontado!"});

                 _bebidaData.Update(bebidas);
                 if (await _bebidaData.SaveChangesAsync())
                    return Ok(bebidas);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id){
            try
            {
                var bebida = await _bebidaData.GetBebidaAsyncById(id);
                if (bebida == null) return NotFound(new { message = "Bebida não encontado!"});
                
                _bebidaData.Delete(bebida);
                if (await _bebidaData.SaveChangesAsync())
                    return Ok(new { message = "Bebida deletado com sucesso!"});
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}