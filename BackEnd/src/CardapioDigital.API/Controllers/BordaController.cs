using CardapioDigital.Service.DTOs;
using CardapioDigital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CardapioDigital.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BordaController : ControllerBase
{
    private readonly IBordaService _service;

    public BordaController(IBordaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _service.GetAllAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(BordaDto borda)
    {
        try
        {
            var retorno = await _service.Add(borda);

            if (retorno == null) return BadRequest("Você esta tentando adicionar uma borda já existente");

            return Ok(retorno);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(BordaDto borda)
    {
        try
        {
            var retorno = await _service.Update(borda);

            return Ok(retorno);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            return Ok(await _service.Delete(id));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
