using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEscuela.Data;
using WebApiEscuela.Models;

namespace WebApiEscuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProfesorController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        //Traer todos los profesores
        public IEnumerable<Profesor> Get()
        {
            return context.Profesores.ToList();
        }
        //Traer por Id

        [HttpGet("{id}")]
        public ActionResult<Profesor> Get(int id)
        {
            return context.Profesores.Find(id);

        }


        [HttpPost]
        //Guardar un Profesor

        public ActionResult Post(Profesor profesor)
        {
            context.Profesores.Add(profesor);
            context.SaveChanges();
            return Ok();
        }
        //Modificar Profesor
        [HttpPut("{id}")]
        public ActionResult Put(int id, Profesor profesor)
        {

            if (id != profesor.Id)
            {
                return BadRequest();
            }
            context.Entry(profesor).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();

        }
        //Eliminar Médico

        [HttpDelete("{id}")]
        public ActionResult<Profesor> Delete(int id)
        {
            Profesor profesor = context.Profesores.Find(id);
            if (profesor == null)
            {
                return NotFound();
            }

            context.Profesores.Remove(profesor);
            context.SaveChanges();

            return profesor;
        }

        //GET: Traer profesor por título
        [HttpGet("TraerPorTitulo/{titulo}")]
        public IEnumerable<Profesor> TraerPorTitulo(string titulo)
        {
            var profesor = (from p in context.Profesores
                           where p.Titulo == titulo
                           select p).ToList();
            return profesor;
        }


    }
}

