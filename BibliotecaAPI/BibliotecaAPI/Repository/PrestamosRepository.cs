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

        public List<Prestamos> GetPrestamosPendientes()
        {
            using (var context = new BibliotecaDbContext())
            {
                var list = context.Prestamos.Where(x => x.Estatus == "Prestado").ToList();
                return list;
            }
        }

    }
}
