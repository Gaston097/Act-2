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

        private void ocultarColumnas()
        {
            this.dgvProductos.Columns["id"].Visible = false;
            this.dgvProductos.Columns["imagen"].Visible = false;
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
            if(dgvProductos.CurrentRow != null)
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
                if(dgvProductos.CurrentRow != null) { 
                Producto p;
                p = (Producto)dgvProductos.CurrentRow.DataBoundItem;

                frmDetalleProducto dp = new frmDetalleProducto();
                dp.cargarValores(p);

                this.mostrarProductosTodos_Load();
            }
                else
                {
                    MessageBox.Show("Seleccione la fila");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btmAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarProductos alta = new frmAgregarProductos();
            alta.ShowDialog();
            cargar();
        }

        private void btmFiltrar_Click(object sender, EventArgs e)
        {
            
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Producto> listafiltrada;
            string filtro = txtFiltro.Text;

            if (filtro.Length > 2)
            {
                listafiltrada = listproducto.FindAll(x => x.codigo == filtro.ToUpper() || x.nombre.ToUpper().Contains(filtro.ToUpper()) || x.marca.descripcion.ToUpper().Contains(filtro.ToUpper()) || x.categoria.descripcion.ToUpper().Contains(filtro.ToUpper()));

            }
            else
            {
                listafiltrada = listproducto;
            }

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = listafiltrada;
            ocultarColumnas();
        }

       
    }
}
