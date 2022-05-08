using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominios;
using negocios;

namespace AppGrupal
{
    public partial class frmProductosTodos : Form
    {
        private List<Producto> listproducto;

        public frmProductosTodos()
        {
            InitializeComponent();
            mostrarProductosTodos_Load();
        }
        public void mostrarProductosTodos_Load()
        {
            cargar();
        }
        private void cargar()
        {
            try
            {
                listasProductos p = new listasProductos();

                dgvProductos.AllowUserToAddRows = false;

                dgvProductos.Columns.Clear();

                listproducto = p.listar();
                dgvProductos.DataSource = listproducto;

                ocultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                negocioProducto np = new negocioProducto();
                frmProductosTodos p = new frmProductosTodos();

                int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("Quieres eliminar este articulo?", "Message", MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    if (np.eliminarProducto(id))
                    {
                        MessageBox.Show("Articulo eliminado con exito");
                        this.mostrarProductosTodos_Load();
                    }
                    else
                        MessageBox.Show("El articulo no se pudo eliminar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Producto p;
                p = (Producto)dgvProductos.CurrentRow.DataBoundItem;

                frmModificarProductos mp = new frmModificarProductos();
                mp.cargarValores(p);

                this.mostrarProductosTodos_Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                Producto s = (Producto)dgvProductos.CurrentRow.DataBoundItem;
                cargarImagen(s.imagen);
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

        private void verDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.CurrentRow != null)
                {
                    Producto p;
                    p = (Producto)dgvProductos.CurrentRow.DataBoundItem;

                    frmDetalleProducto dp = new frmDetalleProducto();
                    dp.cargarValores(p);

                    this.mostrarProductosTodos_Load();
                }
                else
                {
                    MessageBox.Show("Seleccione la fila!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarProductos alta = new frmAgregarProductos();
            alta.ShowDialog();
            cargar();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (cboCampo.SelectedIndex > -1 && cboCriterio.SelectedIndex > -1 && txtFiltroAvanzado.Text != "")
            {
                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;

                negocioProducto negocio = new negocioProducto();
                try
                {
                    dgvProductos.DataSource = negocio.filtrar(campo, criterio, filtro);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Seleccione un criterio de busqueda y complete con un filtro");
            }

        }
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Producto> listafiltrada;
            string filtro = txtFiltro.Text;

            if (filtro.Length > 2)
            {
                listafiltrada = listproducto.FindAll(x => x.codigo == filtro.ToUpper() || x.nombre.ToUpper().Contains(filtro.ToUpper()) || x.marca.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.categoria.Descripcion.ToUpper().Contains(filtro.ToUpper()));

            }
            else
            {
                listafiltrada = listproducto;
            }

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = listafiltrada;
            ocultarColumnas();
        }
        private void frmProductosTodos_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.Add("Código");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripción");
            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoria");
        }
        private void txtFiltroAvanzado_TextChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Precio")
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtFiltroAvanzado.Text, "[^0-9]"))
                {
                    MessageBox.Show("Por favor, solo ingresar numeros!");
                    txtFiltroAvanzado.Text = txtFiltroAvanzado.Text.Remove(txtFiltroAvanzado.Text.Length - 1);
                }
            }
        }
        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

            string opcion = cboCampo.SelectedItem.ToString();
            switch (opcion)
            {
                case "Código":
                    cboCriterio.Items.Clear();
                    cboCriterio.Items.Add("Igual a");
                    cboCriterio.Items.Add("Comienza con");
                    cboCriterio.Items.Add("Termina con");
                    break;
                case "Nombre":
                    cboCriterio.Items.Clear();
                    cboCriterio.Items.Add("Comienza con");
                    cboCriterio.Items.Add("Termina con");
                    cboCriterio.Items.Add("Contiene");
                    break;
                case "Descripción":
                    cboCriterio.Items.Clear();
                    cboCriterio.Items.Add("Comienza con");
                    cboCriterio.Items.Add("Termina con");
                    cboCriterio.Items.Add("Contiene");
                    break;
                case "Precio":
                    cboCriterio.Items.Clear();
                    cboCriterio.Items.Add("Mayor a");
                    cboCriterio.Items.Add("Menor a");
                    cboCriterio.Items.Add("Igual a");
                    break;
                case "Marca":
                    cboCriterio.Items.Clear();
                    cboCriterio.Items.Add("Comienza con");
                    cboCriterio.Items.Add("Termina con");
                    cboCriterio.Items.Add("Contiene");
                    break;
                case "Categoria":
                    cboCriterio.Items.Clear();
                    cboCriterio.Items.Add("Comienza con");
                    cboCriterio.Items.Add("Termina con");
                    cboCriterio.Items.Add("Contiene");
                    break;
                default:
                    break;
            }
        }
        private void btnFiltrar_MouseMove(object sender, MouseEventArgs e)
        {
            btnFiltrar.BackColor = Color.Violet;
        }

        private void btnAgregar_MouseMove(object sender, MouseEventArgs e)
        {
            btnAgregar.BackColor = Color.Violet;
        }

        private void btnAgregar_MouseLeave(object sender, EventArgs e)
        {
            btnAgregar.BackColor= Color.LightGray;
        }

        private void btnFiltrar_MouseLeave(object sender, EventArgs e)
        {
            btnFiltrar.BackColor= Color.LightGray;
        }
        private void ocultarColumnas()
        {
            this.dgvProductos.Columns["id"].Visible = false;
            this.dgvProductos.Columns["imagen"].Visible = false;
        }
    }
}
