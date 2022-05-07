using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace dominios
{
    public class Producto
    {
        public int id { get; set; }
        [DisplayName("Código")]
        public string codigo { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Descripción")]
        public string descripcion { get; set; }
        [DisplayName("Precio")]
        public decimal precio { get; set; }
        [DisplayName("Marca")]
        public Elemento marca { get; set; }
        [DisplayName("Categoria")]
        public Elemento categoria { get; set; }
        [DisplayName("Imagen URL")]
        public string imagen { get; set; }
    }
}