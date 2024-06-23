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

        public Prestamos PrestarLibro(Prestamos prestamo)
        {
            using (var context = new BibliotecaDbContext())
            {
                prestamo.UsuariosId = new Random().Next(1, 3);
                prestamo.Estatus = "Prestado";
                prestamo.Cantidad = 1;
                prestamo.FechaHora = DateTime.Now;
                context.Prestamos.Add(prestamo);
                context.SaveChanges();

                var libro = prestamo.Libros;
                libro.CantidadDisponible--;
                context.SaveChanges();

                return prestamo;
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
