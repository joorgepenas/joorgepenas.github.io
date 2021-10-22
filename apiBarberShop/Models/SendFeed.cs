using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Models
{
    public class SendFeed
    {
        [Key]
        public int ID_CITA { get; set; }
        public int PUNTUACION { get; set; }
        public string COMENTARIO { get; set; }
    }
}
