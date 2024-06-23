using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repository
{
    public interface ILibrosRepository
    {
        public List<Libros> GetLibros();

        public Libros? AddLibro(Libros usuario);

        public bool DeleteLibro(int id);
    }
}
