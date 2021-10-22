using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Models
{
    public class GraficoBarras
    {
        [Key]
        public System.Int64 ID { get; set; }
        public string DNI_ESTILISTA { get; set; }
        public decimal PRECIO { get; set; }
        public string NOMBRE_ESTILISTA { get; set; }
        public string MES { get; set; }
    }
}
