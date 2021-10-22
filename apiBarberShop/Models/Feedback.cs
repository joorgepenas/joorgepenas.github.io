using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Models
{
    public class Feedback
    {
        [Key]
        public int ID_FEEDBACK { get; set; }
        public int PUNTUACION { get; set; }
        public string COMENTARIO { get; set; }
    }
}
