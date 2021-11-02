using Microsoft.EntityFrameworkCore;
using SWMedicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWMedicos.Data
{
    public class MedicosDbContext : DbContext

    {
        //tiene que estar el constructor con parámetro
        public MedicosDbContext(DbContextOptions<MedicosDbContext> options) : base(options) { }

        public DbSet<Medico> Medicos { get; set; }

    }
}
