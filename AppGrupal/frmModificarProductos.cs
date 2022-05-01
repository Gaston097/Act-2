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
        private int idModificar;
        public frmModificarProductos()
        {
            InitializeComponent();
        }
        public void cargarValores(Producto p)
        {
            listasProductos lp = new listasProductos();
            try
            {
                cbMarca.DataSource = lp.listarMarcas();
                cbMarca.ValueMember = "id";
                cbMarca.DisplayMember = "descripcion";
                cbCategoria.DataSource = lp.listarCategorias();
                cbCategoria.ValueMember = "id";
                cbCategoria.DisplayMember = "descripcion";

                idModificar = Convert.ToInt32(p.id);
                txtCodigo.Text = p.codigo.ToString();
                txtNombre.Text = p.nombre.ToString();
                txtDescripcion.Text = p.descripcion.ToString();
                txtPrecioVenta.Text = p.precio.ToString();
                txtImagen.Text = p.imagen.ToString();
                cbMarca.SelectedValue = p.marca.id;
                cbCategoria.SelectedValue = p.categoria.id;

                this.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    p.id = idModificar;

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
