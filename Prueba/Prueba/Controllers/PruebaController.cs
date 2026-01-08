using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using DTO_s; // o el namespace real de UsuarioDto

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {

        private readonly IUsuarioService _service;

        public PruebaController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear()
        {
            await _service.Crear(new UsuarioDto
            {
                Id = 1,
                Nombre = "Juan"
            });

            return Ok();
        }


        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var result = await _service.Listar();
            return Ok(result);
        }
    }
}
