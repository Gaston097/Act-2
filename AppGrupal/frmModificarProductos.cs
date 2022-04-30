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
        private int id;

        public frmModificarProductos()
        {
            InitializeComponent();
        }
        public void cargarValores(DataGridView dgvProductos)
        {
            negocioProducto np = new negocioProducto();

            id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
            txtCodigo.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
            txtDescripcion.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
            txtPrecioVenta.Text = dgvProductos.CurrentRow.Cells[4].Value.ToString();
            txtImagen.Text = dgvProductos.CurrentRow.Cells[7].Value.ToString();
            np.obtenerMarcas(cbMarca);
            np.obtenerCategorias(cbCategoria);
            this.ShowDialog();
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

                if (String.IsNullOrEmpty(txtImagen.Text))
                {
                    txtImagen.BackColor = Color.Red;
                    validar = true;
                }
                else
                    txtImagen.BackColor = Color.White;

                if (String.IsNullOrEmpty(cbMarca.SelectedValue.ToString()))
                {
                    validar = true;
                }

                if (String.IsNullOrEmpty(cbCategoria.SelectedValue.ToString()))
                {
                    validar = true;
                }

                if (validar==false)
                {
                    txtCodigo.BackColor = Color.White;
                    txtNombre.BackColor = Color.White;
                    txtPrecioVenta.BackColor = Color.White;
                    txtDescripcion.BackColor = Color.White;
                    txtImagen.BackColor= Color.White;

                    p.codigo = txtCodigo.Text;
                    p.nombre = txtNombre.Text;
                    p.descripcion = txtDescripcion.Text;
                    p.precio = Convert.ToDecimal(txtPrecioVenta.Text);
                    p.imagen = txtImagen.Text;
                    p.id = id;

                    if (MessageBox.Show("Quieres modificar este articulo?", "Message", MessageBoxButtons.YesNo)==DialogResult.Yes)
                    {
                        if (np.modificarProducto(p, Convert.ToInt32(cbMarca.SelectedValue), Convert.ToInt32(cbCategoria.SelectedValue)))
                        {
                            this.Close();
                            MessageBox.Show("Articulo modificado con exito");
                        }
                        else
                            MessageBox.Show("El articulo no se pudo modificar");
                    }
                }
            }
        }
    }
}
