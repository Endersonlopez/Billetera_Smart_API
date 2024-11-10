namespace Billetera_Smart.Models
{
    public class AM_Estados
    {
        public int? Id_Estado { get; set; }
        public required string Estado { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
        public DateTime? Fecha_Modificacion { get; set; }
        public int? Activo { get; set; }
    }
}
