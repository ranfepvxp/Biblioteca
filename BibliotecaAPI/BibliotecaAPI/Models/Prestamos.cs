﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    public class Prestamos
    {
        [Key]
        public int Id { get; set; }
        public int UsuariosId { get; set; }
        public int LibrosId { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaHora { get; set; }
        public DateTime? FechaHoraDevolucion { get; set; }

        public string Estatus { get; set; }
        public Usuarios Usuarios { get; set; }
        public Libros Libros { get; set; }

    }
}
