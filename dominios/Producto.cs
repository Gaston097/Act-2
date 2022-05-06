﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace dominios
{
    public class Producto
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public Elemento marca { get; set; }
        public Elemento categoria { get; set; }
        public string imagen { get; set; }
    }
}