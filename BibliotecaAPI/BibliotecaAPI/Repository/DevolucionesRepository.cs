using BibliotecaAPI.Context;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repository
{
    public class DevolucionesRepository : IDevolucionesRepository
    {
        public List<Prestamos> GetPrestamosDevueltos()
        {
            using (var context = new BibliotecaDbContext())
            {
                var list = context.Prestamos.Where(x => x.Estatus == "Devuelto").ToList();
                return list;
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

                    var libro = prestamo.Libros;
                    libro.CantidadDisponible++;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
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

                        var libro = prestamo.Libros;
                        libro.CantidadDisponible++;
                        context.SaveChanges();
                    }
                }

                return true;
            }
        }


    }
}
