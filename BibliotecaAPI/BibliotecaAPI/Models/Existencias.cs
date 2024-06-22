using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    public class Existencias
    {
        [Key]
        public int Id { get; set; }
        public int LibrosId { get; set; }
        public int CantidadDisponible { get; set; }
        public Libros? Libros { get; set; }

        [ForeignKey("ExistenciasId")]
        public ICollection<Prestamos>? Prestamos { get; set; }
    }
}
