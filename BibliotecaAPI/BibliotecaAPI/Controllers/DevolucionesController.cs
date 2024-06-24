using BibliotecaAPI.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevolucionesController : ControllerBase
    {
        readonly IDevolucionesRepository _devolucionesRepository;
        public DevolucionesController(IDevolucionesRepository devolucionesRepository)
        {
            _devolucionesRepository = devolucionesRepository;
        }


        // GET: api/<DevolucionesController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_devolucionesRepository.GetPrestamosDevueltos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<DevolucionesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(_devolucionesRepository.DevolverLibro(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("devoluciones/return-all")]
        public ActionResult ReturnAll()
        {
            try
            {
                return Ok(_devolucionesRepository.DevolverTodosLosLibros());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
