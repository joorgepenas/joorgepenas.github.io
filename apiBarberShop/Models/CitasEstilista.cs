using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Models
{
    public class CitasEstilista
    {
        [Key]
        public int ID_CITA { get; set; }
        public string HORA_RESERVACION { get; set; }
        public DateTime FECHA_ATENCION { get; set; }
        public string NOMBRE_CLIENTE { get; set; }
        public int ESTADO { get; set; }
    }
}
