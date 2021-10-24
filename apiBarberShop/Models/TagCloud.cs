using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Models
{
    public class TagCloud
    {
        [Key]
        public int ID { get; set; }
        public string COMENTA { get; set; }
        public int CONTADOR { get; set; }
        public string COLOR { get; set; }
    }
}
