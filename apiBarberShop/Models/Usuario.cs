using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Models
{
    [Table("usuario", Schema = "app")]
    public class Usuario
    {
        [Key]
        public string DNI { get; set; }
        public string APE_PAT { get; set; }
        public string APE_MAT { get; set; }
        public string NOMBRE { get; set; }
        public DateTime FECHA_INSCRIPCION { get; set; }
        public DateTime FECHA_NACIMIENTO { get; set; }
        public string CORREO { get; set; }
        public Byte[] CONTRASENA { get; set; }
        public int ESTADO { get; set; }
        public int ID_SEXO { get; set; }
        public int ID_ROL { get; set; }
        
    }
}
