using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Models
{
    public class Categorias
    {
        [Key]
        public int ID_CATE { get; set; }
        public string DESCRIPCION { get; set; }
    }
}
