using BibliotecaAPI.Models;
using BibliotecaAPI.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        readonly IPrestamosRepository _prestamosRepository;

        public PrestamosController(IPrestamosRepository prestamosRepository)
        {
            _prestamosRepository = prestamosRepository;
        }

        // GET: api/<PrestamosController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_prestamosRepository.GetPrestamosPendientes());
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        // GET api/<PrestamosController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(_prestamosRepository.GetPrestamo(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<PrestamosController>
        [HttpPost]
        public ActionResult Post([FromBody] Libros libro)
        {
            try
            {

                if (_prestamosRepository.Existencias(libro.Id))
                {
                    return Ok(_prestamosRepository.PrestarLibro(libro));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
