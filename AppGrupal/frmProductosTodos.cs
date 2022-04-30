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
    public partial class frmProductosTodos : Form
    {
        public frmProductosTodos()
        {
            InitializeComponent();
            mostrarProductosTodos_Load();
        }
        public void mostrarProductosTodos_Load()
        {
            listasProductos p = new listasProductos();

            dgvProductos.AllowUserToAddRows = false;

            dgvProductos.Columns.Clear();

            dgvProductos.DataSource = p.listar();

            this.dgvProductos.Columns["id"].Visible = false;
            this.dgvProductos.Columns["imagen"].Visible = false; 
        }
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModificarProductos mp = new frmModificarProductos();
            mp.cargarValores(dgvProductos);
            this.mostrarProductosTodos_Load();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            Producto s = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            cargarImagen(s.imagen);
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
