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
    public class AlumnoController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AlumnoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        //Traer todos los Alumnos
        public IEnumerable<Alumno> Get()
        {
            return context.Alumnos.ToList();
        }
        //Traer por Id

        [HttpGet("{id}")]
        public ActionResult<Alumno> Get(int id)
        {
            return context.Alumnos.Find(id);

        }


        [HttpPost]
        //Guardar un Alumno

        public ActionResult Post(Alumno alumno)
        {
            context.Alumnos.Add(alumno);
            context.SaveChanges();
            return Ok();
        }
        //Modificar Alumno
        [HttpPut("{id}")]
        public ActionResult Put(int id, Alumno alumno)
        {

            if (id != alumno.Id)
            {
                return BadRequest();
            }
            context.Entry(alumno).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();

        }
        //Eliminar 

        [HttpDelete("{id}")]
        public ActionResult<Alumno> Delete(int id)
        {
            Alumno alumno = context.Alumnos.Find(id);
            if (alumno == null)
            {
                return NotFound();
            }

            context.Alumnos.Remove(alumno);
            context.SaveChanges();

            return alumno;
        }

        //GET: Traer Alumno por matricula
        [HttpGet("TraerPorMatricula/{matricula}")]
        public IEnumerable<Alumno> TraerPorMatricula(int matricula)
        {
            var Alumno = (from a in context.Alumnos
                            where a.Matricula == matricula
                          select a).ToList();
            return Alumno;
        }
 //GET: Traer Alumno por ciudad
    [HttpGet("TraerPorCiudad/{ciudad}")]
    public IEnumerable<Alumno> TraerPorCiudad(string ciudad)
    {
        var Alumno = (from a in context.Alumnos
                      where a.Ciudad == ciudad
                      select a).ToList();
        return Alumno;
    }

    }

   


}


