using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Models
{
    public class ServiciosUsuario
    {
        [Key]
        public int ID_SERVICIO { get; set; }
        public string DESCRIPCION_SER { get; set; }
        public int ID_CATE { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal PRECIO { get; set; }
    }
}
