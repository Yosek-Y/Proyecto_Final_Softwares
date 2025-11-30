using Mecario_BackEnd.Modelos.DTOs;
using Mecario_BackEnd.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Mecario_BackEnd.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class CasosController : ControllerBase
    {
        private readonly CasosServicio _service;

        public CasosController(CasosServicio service)
        {
            _service = service;
        }

        //Protocolo HTTP Get para obtener todos los casos donde participo dicho mecanico
        //POST: api/Mecanico/{idMecanico:int}
        [HttpGet("Mecanico/Casos_{idMecanico:int}")]
        public async Task<IActionResult> ListarCasosDeMecanico(int idMecanico)
        {
            try
            {
                var lista = await _service.ListarCasosPorMecanico(idMecanico);
                return Ok(lista);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error interno del servidor", detalle = ex.Message });
            }
        }

        //Protocolo HTTP Put para que un administardor asigne un caso a un mecánico
        //PUT: api/Casos/Admin/AsignarCaso
        [HttpPut("Admin/AsignarCaso")]
        public async Task<IActionResult> AdminAsignaCaso([FromBody] AsignarCasoAdminDTO dto)
        {
            try
            {
                var respuesta = await _service.AsignarCasoPorAdmin(dto);
                return Ok(new { mensaje = respuesta });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error interno del servidor", detalle = ex.Message });
            }
        }

        // Protocolo HTTP Post para asignar un mecánico a un caso
        // POST: api/Casos/AsignarMecanico
        [HttpPost("AsignarMecanico")]
        public async Task<IActionResult> AsignarMecanico([FromBody] MecanicoSeAsignaCasoDTO dto)
        {
            try
            {
                var casoActualizado = await _service.AsignarMecanico(dto);
                return Ok(new
                {
                    mensaje = "Mecánico asignado correctamente",
                    data = casoActualizado
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error interno del servidor", detalle = ex.Message });
            }
        }
    }
}
