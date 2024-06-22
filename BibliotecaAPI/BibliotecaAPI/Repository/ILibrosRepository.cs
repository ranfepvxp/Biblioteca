using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repository
{
    public interface ILibrosRepository
    {
        public List<Libros> GetLibros();
    }
}
