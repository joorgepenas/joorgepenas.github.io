using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Models
{
    public class ReservaCita
    {
        [Key]
        public int ID_CITA { get; set; }
        public DateTime FECHA_RESERVACION { get; set; }
        public string HORA_RESERVACION { get; set; }
    }
}
