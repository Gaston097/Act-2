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
    public partial class frmAgregarProductos : Form
    {
        public frmAgregarProductos()
        {
            negocioProducto p = new negocioProducto();
            InitializeComponent();
            p.cbMarcas(cboxMarca);
            p.cbCategorias(cboxCategoria);
        }
        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            negocioProducto np = new negocioProducto();
            Producto p = new Producto();

            bool validar = false;

            if (String.IsNullOrEmpty(txtCodigo.Text))
            {
                txtCodigo.BackColor = Color.Red;
                validar = true;
            }
            else
                txtCodigo.BackColor = Color.White;

            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                txtNombre.BackColor = Color.Red;
                validar = true;
            }
            else
                txtNombre.BackColor = Color.White;

            if (String.IsNullOrEmpty(txtPrecioVenta.Text))
            {
                txtPrecioVenta.BackColor = Color.Red;
                validar = true;
            }
            else
                txtPrecioVenta.BackColor = Color.White;

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                txtDescripcion.BackColor = Color.Red;
                validar = true;
            }
            else
                txtDescripcion.BackColor = Color.White;

            if (validar==false)
            {
                txtCodigo.BackColor = Color.White;
                txtNombre.BackColor = Color.White;
                txtPrecioVenta.BackColor = Color.White;
                txtDescripcion.BackColor = Color.White;

                p.codigo = txtCodigo.Text;
                p.nombre = txtNombre.Text;
                p.descripcion = txtDescripcion.Text;
                p.precioVenta = Convert.ToDecimal(txtPrecioVenta.Text);

                int idMarca = Convert.ToInt32(cboxMarca.SelectedValue);
                int idCategoria = Convert.ToInt32(cboxCategoria.SelectedValue);
 
                if (np.agregarProducto(p, idMarca, idCategoria))
                {
                    MessageBox.Show("Producto agregado con exito");  
                    this.Close();
                } 
                else MessageBox.Show("El producto no se agrego");
            }
        }
    }
}
