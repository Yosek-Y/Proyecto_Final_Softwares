using Mecario_BackEnd.Modelos.DTOs;
using Mecario_BackEnd.Servicios;
using Microsoft.AspNetCore.Mvc;


namespace Mecario_BackEnd.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class OrdenesServicioController : ControllerBase
    {
        private readonly OrdenesServicioServicio _service;

        public OrdenesServicioController(OrdenesServicioServicio service)
        {
            _service = service;
        }

        // Protocolo HTTP Post para crear una nueva orden de servicio
        // POST: Api/OrdenesServicio/NuevaOrden
        [HttpPost("NuevaOrden")]
        public async Task<IActionResult> CrearOrden([FromBody] CrearOrdenServicioDTO dto)
        {
            try
            {
                var orden = await _service.CrearOrdenServicio(dto);

                return Ok(new
                {
                    mensaje = "Orden de servicio creada correctamente",
                    data = new
                    {
                        orden.idOrden,
                        orden.tipoServicio,
                        orden.diagnosticoInicial,
                        orden.costoInicial,
                        orden.idVehiculo
                    }
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