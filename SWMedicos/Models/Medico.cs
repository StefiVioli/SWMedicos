using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SWMedicos.Models
{
    [Table("Medico")]
        public class Medico
        {
            [Key]
            public int MedicoId { get; set; }

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
        public string Especialidad { get; set; }

        public int NroMatricula { get; set; }
       
        [Column(TypeName = "date")]
      //  [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]

        public DateTime FechaNacimiento { get; set; }

        [Column(TypeName = "varchar")]//tipo de dato de SQL Server
        [MaxLength(50)]//hasta 50 
        public string Ciudad { get; set; }

    }
}
