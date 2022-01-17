using Microsoft.AspNetCore.Mvc;
using CardapioDigitalWebAPI.Interface;
using CardapioDigitalWebAPI.Models;
using System.Text;
using System.Security.Cryptography;

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

        public static string GerarHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        [HttpPost]
        public async Task<IActionResult> post(Usuarios usuarios){
            try
            {
                // Verificando se existe o usuario
                var resultado = await _data.GetUsuarioAsyncByLogin(usuarios.USR_LOGIN1);
                if (resultado != null) return Ok(new {message = "Usuário existente!"});

                // Conputando a senha para MD5
                usuarios.USR_PASSWORD1 = GerarHashMd5(usuarios.USR_PASSWORD1);
               // Adicionando o usuario
                _data.Add(usuarios);
                 
                if (await _data.SaveChangesAsync()) return Ok(usuarios);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(Usuarios usuarios){
            try
            {
                var resultado = await _data.Login(usuarios.USR_LOGIN1, GerarHashMd5(usuarios.USR_PASSWORD1));

                if (resultado == null) return Ok(new {message = "Usuario ou senha incorreto!"});

                return Ok(new {message = $"Seja bem-vindo {resultado.USR_LOGIN1}"});
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> put(int id, Usuarios usuarios) {
            try
            {
                var resultado = await _data.GetUsuarioAsyncById(id);
                if (resultado == null) return NotFound(new { message = "Usuario não existente"});

                _data.Update(usuarios);
                if (await _data.SaveChangesAsync()) return Ok(usuarios);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id) {
            try
            {
                var usuarios = await _data.GetUsuarioAsyncById(id);
                if (usuarios == null) return NotFound(new { message = "Usuario não existente"});

                _data.Delete(usuarios);
                if (await _data.SaveChangesAsync()) return Ok(new { message = "Usuario Excluido com sucesso!"});
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}