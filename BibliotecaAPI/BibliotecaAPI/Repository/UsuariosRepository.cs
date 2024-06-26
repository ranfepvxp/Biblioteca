using BibliotecaAPI.Context;
using BibliotecaAPI.Managers;
using BibliotecaAPI.Models;
using System.Diagnostics;

namespace BibliotecaAPI.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {

        BibliotecaDbContext context = new BibliotecaDbContext();

        public UsuariosRepository()
        {

            var usuarios = new List<Usuarios>
                {
                new Usuarios
                {
                    Nombre = "Logen Nuevededos",
                    Email = "logen@hotmail.com",
                    Contraseña="123",

                },
                new Usuarios
                {
                    Nombre = "Jon Nieve",
                    Email = "jon@gmail.com",
                    Contraseña="123",
                },
                new Usuarios
                {
                   Nombre = "Jezal Dan Luthar",
                   Email = "jezal@icloud.com",
                   Contraseña="123",
                },

                };
            context.Usuarios.AddRange(usuarios);
            context.SaveChanges();
        }

        public List<Usuarios> GetUsuarios()
        {
            var list = context.Usuarios.ToList();
            return list;
        }


        public Usuarios Login(Usuarios _usuario)
        {
            var usuario = context.Usuarios.FirstOrDefault(u=>u.Email == _usuario.Email);

            if (usuario != null)
            {
                if (usuario.Contraseña ==_usuario.Contraseña)
                {
                    Debug.WriteLine("true");
                    return usuario;
                    
                }
                else
                {
                    Debug.WriteLine("false");
                    return null;
                }
            }
            else
            {
                return  null;
            }

        }


    }
}
