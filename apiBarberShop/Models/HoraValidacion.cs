using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Models
{
    public class HoraValidacion
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public string AVAILABLE { get; set; }
    }
}
