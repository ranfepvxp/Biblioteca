using BibliotecaAPI.Models;
using BibliotecaAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        readonly IUsuariosRepository _usuariosRepository;

        public LoginController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        // POST api/<LoginController>   
        [HttpPost]
        public ActionResult Post([FromBody] Usuarios usuarios)
        {
            var response = _usuariosRepository.Login(usuarios);
            Debug.WriteLine(response);
            return Ok(response);
        }

    }
}
