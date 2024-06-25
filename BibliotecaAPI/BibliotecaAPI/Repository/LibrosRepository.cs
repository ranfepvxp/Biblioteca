using BibliotecaAPI.Context;
using BibliotecaAPI.Managers;
using BibliotecaAPI.Models;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace BibliotecaAPI.Repository
{
    public class LibrosRepository : ILibrosRepository
    {
        public LibrosRepository()
        {
            using (var context = new BibliotecaDbContext())
            {
                var libros = new List<Libros>();

                libros = context.Libros.ToList();

                if (libros.Count == 0)
                {
                    libros = new List<Libros>
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
        }

        public Libros AddLibro(Libros libro)
        {
            using (var context = new BibliotecaDbContext())
            {
                Base64ToImage base64 = new Base64ToImage();
                string resultado = base64.ConvertBase64(libro.Imagen.ToString(),libro.Nombre.ToString());

                if (!resultado.Contains("Error"))
                {
                    libro.Imagen = resultado;
                }
                else
                {
                    libro.Imagen = "";
                }
                context.Libros.Add(libro);
                context.SaveChanges();
                return libro;
            }                        
        }

        public bool DeleteLibro(int id)
        {
            using (var context = new BibliotecaDbContext())
            {
                var libro = context.Libros.FirstOrDefault(x => x.Id == id);
                if (libro != null)
                {
                    context.Remove(libro);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
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
