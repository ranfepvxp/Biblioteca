using BibliotecaAPI.Context;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        public UsuariosRepository()
        {
            using (var context = new BibliotecaDbContext())
            {
                var usuarios = new List<Usuarios>
                {
                new Usuarios
                {
                    Nombre = "Logen Nuevededos",
                    Email = "logen@hotmail.com",
                    Contraseña="123",                  
                    Tipo = 1
                   
                },
                new Usuarios
                {
                    Nombre = "Jon Nieve",
                    Email = "jon@gmail.com",
                    Contraseña="123",
                    Tipo = 0
                },
                new Usuarios
                {
                   Nombre = "Jezal Dan Luthar",
                    Email = "jezal@icloud.com",
                    Contraseña="123",
                    Tipo = 0
                },

                };
                context.Usuarios.AddRange(usuarios);
                context.SaveChanges();
            }
        }



        public List<Usuarios> GetUsuarios()
        {
            using (var context = new BibliotecaDbContext())
            {
                var list = context.Usuarios.ToList();
                return list;
            }
        }

    }
}
