using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Models
{
    public class Login
    {
        [Key]
        public string CORREO { get; set; }
        [NotMapped]
        public string CONTRASENA { get; set; }
    }
}
