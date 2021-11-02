using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEscuela.Models;

namespace WebApiEscuela.Data
{
    public class ApplicationDbContext:DbContext
    {
        //tiene que estar el constructor con parámetro
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }

    }
}
