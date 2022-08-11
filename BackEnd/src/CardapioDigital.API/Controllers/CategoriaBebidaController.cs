using CardapioDigital.Service.DTOs;
using CardapioDigital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CardapioDigital.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaBebidaController : ControllerBase
{
    private readonly ICategoriaBebidaService _service;

    public CategoriaBebidaController(ICategoriaBebidaService service)
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
    public async Task<IActionResult> Post(CategoriaBebidaDto categoriaBebida)
    {
        try
        {
            var retorno = await _service.Add(categoriaBebida);

            if (retorno == null) return BadRequest("Você esta tentando adicionar uma categoria de bebida já existente já existente");

            return Ok(retorno);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(CategoriaBebidaDto categoriaBebida)
    {
        try
        {
            var retorno = await _service.Update(categoriaBebida);

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
