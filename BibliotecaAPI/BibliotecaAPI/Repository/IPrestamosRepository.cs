using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repository
{
    public interface IPrestamosRepository
    {
        public Libros PrestarLibro(Libros libro);

        public dynamic GetPrestamosPendientes();


        public bool Existencias(int id);

        public Prestamos GetPrestamo(int id);

        public bool DevolverLibro(int id);

        public bool DevolverTodosLosLibros();

    }
}
