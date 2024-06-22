using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repository
{
    public interface IUsuariosRepository
    {
        public List<Usuarios> GetUsuarios();
    }
}
