using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGrupal
{
    public partial class frmDetalleProducto : Form
    {
        public frmDetalleProducto()
        {
            InitializeComponent();
        }
        public void cargarValores(Producto p)
        {
            listasProductos lp = new listasProductos();
            try
            {
                txtCodigo.Text = p.codigo.ToString();
                txtNombre.Text = p.nombre.ToString();
                txtDescripcion.Text = p.descripcion.ToString();
                txtPrecioVenta.Text = p.precio.ToString();
                txtMarca.Text = p.marca.ToString();
                txtCategoria.Text = p.categoria.ToString();
                cargarImagen(p.imagen);

                this.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxImagen.Load(imagen);
            }
            catch (Exception)
            {
                pbxImagen.Load("https://socialistmodernism.com/wp-content/uploads/2017/07/placeholder-image.png?w=640");
            }
        }
    }
}
