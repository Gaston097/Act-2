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
    public partial class frmModificarProductos : Form
    {
        public frmModificarProductos()
        {
            InitializeComponent();
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

        private void btnModificar_Click(object sender, EventArgs e)
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

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                txtDescripcion.BackColor = Color.Red;
                validar = true;
            }
            else
                txtDescripcion.BackColor = Color.White;

            if (String.IsNullOrEmpty(txtPrecioVenta.Text))
            {
                txtPrecioVenta.BackColor = Color.Red;
                validar = true;
            }
            else
                txtPrecioVenta.BackColor = Color.White;

            if (String.IsNullOrEmpty(txtObservaciones.Text))
            {
                txtObservaciones.BackColor = Color.Red;
                validar = true;
            }
            else
                txtObservaciones.BackColor = Color.White;

            if (validar==false)
            {
                txtCodigo.BackColor = Color.White;
                txtDescripcion.BackColor = Color.White;
                txtPrecioVenta.BackColor = Color.White;
                txtObservaciones.BackColor = Color.White;

                p.codigo = txtCodigo.Text;
                p.descripcion = txtDescripcion.Text;
                p.precioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                p.observaciones = txtObservaciones.Text;

                if (np.agregarProducto(p))
                {
                    MessageBox.Show("Producto modificado con exito");
                    this.Close();
                }
                else MessageBox.Show("El producto no se modifico");
            }

        }
    }
}
