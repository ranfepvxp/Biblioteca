using BibliotecaAPI.Context;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repository
{
    public class PrestamosRepository : IPrestamosRepository
    {
        public bool Existencias(int id)
        {
            using (var context = new BibliotecaDbContext())
            {
                var libros = context.Libros.ToList();
                var libro = context.Libros.FirstOrDefault(x=>x.Id == id);
                if (libro != null)
                {
                    return (libro.CantidadDisponible > 0);
                }
                else {
                    return false;
                }
            }
        }

        public Libros PrestarLibro(Libros libro)
        {
            using (var context = new BibliotecaDbContext())
            {
                int librosId = libro.Id;
                var prestamo = new Prestamos();
                prestamo.LibrosId = librosId;
                prestamo.UsuariosId = new Random().Next(1, 3);
                prestamo.Estatus = "Prestado";
                prestamo.Cantidad = 1;
                prestamo.FechaHora = DateTime.Now;
                prestamo.FechaHoraDevolucion = prestamo.FechaHora;
                context.Prestamos.Add(prestamo);
                context.SaveChanges();
            

                var editLibro = context.Libros.FirstOrDefault(x => x.Id == librosId);
                editLibro.CantidadDisponible = editLibro.CantidadDisponible - 1;
                context.SaveChanges();

                editLibro.Prestamos = null;


                return editLibro;
            }
        }

        public Prestamos GetPrestamo(int id)
        {
            using (var context = new BibliotecaDbContext())
            {
                var prestamo = context.Prestamos.FirstOrDefault(x => x.Id == id);
                return prestamo;
            }
        }

        public dynamic GetPrestamosPendientes()
        {
            using (var context = new BibliotecaDbContext())
            {
                var list = context.Prestamos.Where(x => x.Estatus == "Prestado").Select(x => new { 
                    IdPrestamo = x.Id,
                    Libro = x.Libros.Nombre,
                    Imagen = x.Libros.Imagen,
                    FechaHora = x.FechaHora                
                }).ToList();
                return list;
            }
        }

        public bool DevolverTodosLosLibros()
        {
            using (var context = new BibliotecaDbContext())
            {

                var prestamos = context.Prestamos.Where(x => x.Estatus == "Prestado").ToList();

                foreach (var prestamo in prestamos)
                {
                    if (prestamo != null)
                    {
                        prestamo.Estatus = "Devuelto";
                        context.SaveChanges();

                        int librosId = prestamo.LibrosId;
                        var editLibro = context.Libros.FirstOrDefault(x => x.Id == librosId);
                        if (editLibro != null)
                        {
                            editLibro.CantidadDisponible = editLibro.CantidadDisponible + 1;
                            context.SaveChanges();
                        }
                    }
                }

                return true;
            }

        }

        public bool DevolverLibro(int id)
        {
            using (var context = new BibliotecaDbContext())
            {
                var prestamo = context.Prestamos.Where(x => x.Id == id).FirstOrDefault();
                if (prestamo != null)
                {
                    prestamo.Estatus = "Devuelto";
                    context.SaveChanges();

                    int librosId = prestamo.LibrosId;
                    var editLibro = context.Libros.FirstOrDefault(x => x.Id == librosId);
                    editLibro.CantidadDisponible = editLibro.CantidadDisponible + 1;
                    context.SaveChanges();


                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
