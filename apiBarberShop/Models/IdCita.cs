using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Models
{
    public class IdCita
    {
        [Key]
        public int ID_CITA { get; set; }
    }
}
