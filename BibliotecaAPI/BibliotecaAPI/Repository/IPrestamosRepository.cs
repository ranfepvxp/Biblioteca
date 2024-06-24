using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repository
{
    public interface IPrestamosRepository
    {
        public Libros PrestarLibro(Libros libro);

        public List<Prestamos> GetPrestamosPendientes();


        public bool Existencias(int id);

        public Prestamos GetPrestamo(int id);


    }
}
