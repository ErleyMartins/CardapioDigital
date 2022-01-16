using Microsoft.AspNetCore.Mvc;
using CardapioDigitalWebAPI.Interface;
using CardapioDigitalWebAPI.Models;

namespace CardapioDigitalWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzasController : ControllerBase
    {
        private readonly IPizzasData _pizza;

        public PizzasController(IPizzasData pizza)
        {
            _pizza = pizza;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            try
            {
                var resultado = await _pizza.GetAllPizzasAsync();
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
                var resultado = await _pizza.GetPizzaAsyncById(id);
                if (resultado == null) return NotFound("Pizza não encontrado!");

                return Ok(resultado);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("Descricao/{desc}")]
        public async Task<IActionResult> GetById(string desc){
            try
            {
                var resultado = await _pizza.GetAllPizzasAsyncByDesc(desc);
                return Ok(resultado);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pizzas pizzas){
            try
            {
                _pizza.Add(pizzas);
                if (await _pizza.SaveChangesAsync())
                    return Ok(pizzas);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pizzas pizzas){
            try
            {
                var resultado = await _pizza.GetPizzaAsyncById(id);
                if (resultado == null) return NotFound("Pizza não encontado!");

                 _pizza.Update(pizzas);
                 if (await _pizza.SaveChangesAsync())
                    return Ok(pizzas);
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
                var pizzas = await _pizza.GetPizzaAsyncById(id);
                if (pizzas == null) return NotFound(new { message = "Pizza não encontado!"});
                
                _pizza.Delete(pizzas);
                if (await _pizza.SaveChangesAsync())
                    return Ok(new { message = "Pizza deletado com sucesso!"});
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}