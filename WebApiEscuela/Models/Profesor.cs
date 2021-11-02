using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiEscuela.Models
{
    [Table("Profesor")]
    public class Profesor
    {
        [Key]
        public int Id { get; set; }

        [Required]//Not null
        [Column(TypeName = "varchar")]//tipo de dato de SQL Server
        [MaxLength(50)]//hasta 50 
        public string Nombre { get; set; }

        [Required]//Not null
        [Column(TypeName = "varchar")]//tipo de dato de SQL Server
        [MaxLength(50)]//hasta 50 
        public string Apellido { get; set; }


        [Required]//Not null
        [Column(TypeName = "varchar")]//tipo de dato de SQL Server
        [MaxLength(50)]//hasta 50 
        public string Titulo { get; set; }

    }
}
