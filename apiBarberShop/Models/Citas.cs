using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Models
{
    public class Citas
    {
        public string DNI { get; set; }
        public string DNI2 { get; set; }
        public DateTime FECHA_ATENCION { get; set; }
        public string HORA_RESERVACION { get; set; }
        public int ID_PAGO { get; set; }
        public int ID_SERVICO { get; set; }


    }
}
