using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repository
{
    public interface IDevolucionesRepository
    {

        public List<Prestamos> GetPrestamosDevueltos();

        public bool DevolverLibro(int id);

        public bool DevolverTodosLosLibros();
    }
}
