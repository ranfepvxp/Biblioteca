using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repository
{
    public interface IPrestamosRepository
    {
        public Prestamos PrestarLibro(Prestamos prestamo);

        public List<Prestamos> GetPrestamosPendientes();


        public bool Existencias(int id);

        public Prestamos GetPrestamo(int id);


    }
}
