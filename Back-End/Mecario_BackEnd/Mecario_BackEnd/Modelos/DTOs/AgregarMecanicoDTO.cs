namespace Mecario_BackEnd.Modelos.DTOs
{
    public class AgregarMecanicoDTO
    {
        public string nombreUsuario { get; set; }
        public string telefonoUsuario { get; set; }
        public string correoUsuario { get; set; }
        public string direccionUsuario { get; set; }

        //Datos para login del mecánico
        public string userName { get; set; }
        public string userPassword { get; set; }
    }
}