using CardapioDigital.Service.DTOs;
using CardapioDigital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CardapioDigital.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BebidaController : ControllerBase
{
    private readonly IBebidaService _service;

    public BebidaController(IBebidaService service)
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
    public async Task<IActionResult> Post(BebidaDto bebida)
    {
        try
        {
            var retorno = await _service.Add(bebida);

            return Ok(retorno);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(BebidaDto bebida)
    {
        try
        {
            var retorno = await _service.Update(bebida);

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
