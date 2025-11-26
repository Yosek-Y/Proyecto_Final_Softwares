namespace Mecario_BackEnd.Modelos.DTOs
{
    public class CasosDeMecanicoDTO
    {
        public DateTime fechaInicio { get; set; }
        public DateTime? fechaFin { get; set; }
        public double horasTrabajadas { get; set; }
        public string estadoCaso { get; set; }   // se envía como string
        public double totalCaso { get; set; }
    }
}