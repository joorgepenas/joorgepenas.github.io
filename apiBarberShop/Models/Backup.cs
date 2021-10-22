using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Models
{
    public class Backup
    {
        [Key]
        public int ID_BKP { get; set; }
        public string RUTA { get; set; }
        public string FECHA_BKP { get; set; }
    }
}
