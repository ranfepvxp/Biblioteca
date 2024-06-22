using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; }


        [ForeignKey("UsuariosId")]
        public ICollection<Prestamos>? Prestamos { get; set; }
    }
}
