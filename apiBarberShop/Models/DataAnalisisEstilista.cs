﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Models
{
    public class DataAnalisisEstilista
    {
        [Key]
        public int ID { get; set; }
        public int CATE { get; set; }
        public string DESCRIPCION { get; set; }
        public string DNI { get; set; }
        public string NOMBRE { get; set; }
        public int SEXO { get; set; }
        public int PROMEDIO { get; set; }
    }
}