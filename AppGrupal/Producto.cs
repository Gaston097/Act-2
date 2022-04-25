using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGrupal
{
    class Producto
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public decimal precioVenta { get; set; }
        public string marca { get; set; }
        public int stock { get; set; }
        public string proveedor { get; set; }
        public string observaciones { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaBaja { get; set; }
    }
}
