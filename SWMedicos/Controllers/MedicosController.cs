using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWMedicos.Data;
using SWMedicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWMedicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {

        private readonly MedicosDbContext context;

        public MedicosController(MedicosDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        //traer todos
        public IEnumerable<Medico> Get()
        {
            return context.Medicos.ToList();
        }
        //Traer por Id

        [HttpGet("{id}")]
        public ActionResult<Medico> Get(int id)
        {
            return context.Medicos.Find(id);

        }


        [HttpPost]
        //Guardar un médico

        public ActionResult Post(Medico medico)
        {
            context.Medicos.Add(medico);
            context.SaveChanges();
            return Ok();
        }
        //Modificar Médico
        [HttpPut("{id}")]
        public ActionResult Put(int id, Medico medico)
        {

            if (id != medico.MedicoId)
            {
                return BadRequest();
            }
            context.Entry(medico).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();

        }
        //Eliminar Médico

        [HttpDelete("{id}")]
        public ActionResult<Medico> Delete(int id)
        {
            Medico medico = context.Medicos.Find(id);
            if (medico == null)
            {
                return NotFound();
            }

            context.Medicos.Remove(medico);
            context.SaveChanges();

            return medico;
        }

        //GET: Traer médicos por Especialidad
        [HttpGet("TraerPorEspecialidad/{especialidad}")]
        public IEnumerable<Medico> TraerPorEspecialidad(string especialidad)
        {
            var medicos = (from m in context.Medicos
                          where m.Especialidad == especialidad
                          select m).ToList();
            return medicos;
        }


    }
}
