using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Models
{
    public class ForgetUser
    {
        [Key]
        public string DNI { get; set; }
    }
}
