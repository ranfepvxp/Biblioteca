using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    public class Devoluciones
    {
        [Key]
        public int Id { get; set; }
        public int PrestamosId { get; set; }
        public int Cantidad { get; }
        public DateTime FechaHora { get; set; }

        public Prestamos? Prestamos { get; set; }
    }
}
