using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    public class Libros
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Autor { get; set; }
        public string? Editorial { get; set; }
        public string? Año { get; set; }
        public string? Imagen { get; set; }
        public int CantidadDisponible { get; set; }

        [ForeignKey("LibrosId")]
        public ICollection<Prestamos>? Prestamos { get; set; }
    }
}
