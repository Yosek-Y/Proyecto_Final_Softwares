using Mecario_BackEnd.DBContexs;
using Mecario_BackEnd.Modelos;
using Mecario_BackEnd.Modelos.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace Mecario_BackEnd.Servicios
{
    public class OrdenesServicioServicio
    {
        private readonly ContextoBD _context;

        public OrdenesServicioServicio(ContextoBD context)
        {
            _context = context;
        }
        // Crear una nueva orden de servicio
        public async Task<OrdenesServicio> CrearOrdenServicio(CrearOrdenServicioDTO dto)
        {
            // VALIDACIONES
            if (!Enum.IsDefined(typeof(OrdenesServicio.TipoServicio), dto.TipoServicio))
                throw new ArgumentException("El tipo de servicio no es válido.");

            if (string.IsNullOrWhiteSpace(dto.diagnosticoInicial))
                throw new ArgumentException("El diagnóstico es obligatorio.");

            if (dto.costoInicial < 0)
                throw new ArgumentException("El costo inicial no puede ser negativo.");

            var vehiculo = await _context.Vehiculos.FindAsync(dto.idVehiculo);
            if (vehiculo == null)
                throw new ArgumentException("El vehículo especificado no existe.");

            // CREAR OBJETO
            var nuevaOrden = new OrdenesServicio
            {
                tipoServicio = (OrdenesServicio.TipoServicio)dto.TipoServicio,
                diagnosticoInicial = dto.diagnosticoInicial,
                costoInicial = dto.costoInicial,
                idVehiculo = dto.idVehiculo
            };

            _context.OrdenesServicios.Add(nuevaOrden);
            await _context.SaveChangesAsync();

            return nuevaOrden;
        }
    }
}