﻿using BibliotecaAPI.Models;
using BibliotecaAPI.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        readonly ILibrosRepository _librosRepository;

        public LibrosController(ILibrosRepository librosRepository)
        {
            _librosRepository = librosRepository;
        }

        // GET: api/<LibrosController>
        [HttpGet]
        public ActionResult<List<Libros>> Get()
        {
            return Ok(_librosRepository.GetLibros());
        }

        // GET api/<LibrosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LibrosController>
        [HttpPost]
        public ActionResult Post([FromBody] Libros libro)
        {
            try
            {
                return Ok(_librosRepository.AddLibro(libro));
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<LibrosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LibrosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                return Ok(_librosRepository.DeleteLibro(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
