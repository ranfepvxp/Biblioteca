using BibliotecaAPI.Context;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repository
{
    public class LibrosRepository : ILibrosRepository
    {
        public LibrosRepository()
        {
            using (var context = new BibliotecaDbContext())
            {
                var libros = new List<Libros>
                {
                new Libros
                {
                    Nombre = "El Señor de los Anillos",
                    Autor = "JRR Tolkien",
                    Año = "1977",
                    Editorial = "Minotauro",
                    Imagen = "portadaesdla.jpg",
                    CantidadDisponible = 3
                },
                new Libros
                {
                    Nombre = "Juego de Tronos",
                    Autor = "George RR Martin",
                    Año = "199",
                    Editorial = "Gigamesh",
                    Imagen = "portadajdt.jpg",
                    CantidadDisponible = 4
                },
                new Libros
                {
                    Nombre = "La Voz de las Espadas",
                    Autor = "Joe Abercrombie",
                    Año = "2016",
                    Editorial = "Minotauro",
                    Imagen = "portadalve.jpg",
                    CantidadDisponible = 5
                },

                };
                context.Libros.AddRange(libros);
                context.SaveChanges();
            }
        }


        public List<Libros> GetLibros()
        {
            using (var context = new BibliotecaDbContext())
            {
                var list = context.Libros.ToList();
                return list;
            }
        }
    }
}
