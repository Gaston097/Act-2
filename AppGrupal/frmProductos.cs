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

namespace AppGrupal
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarProductos ventana = new frmAgregarProductos();

            ventana.ShowDialog();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModificarProductos ventana = new frmModificarProductos();

            ventana.ShowDialog();
        }

        private void todosLosProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductosTodos ventana = new frmProductosTodos();

            //foreach (var item in Application.OpenForms)
            //{
            //    if (item.GetType() == typeof(frmProductosTodos))
            //        return;
            //}

            //ventana.MdiParent = this;
            ventana.ShowDialog();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            pboMenu.Load("https://iconape.com/wp-content/png_logo_vector/utn.png");
        }

        private void productosXFiltroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            frmProductosTodos ventana = new frmProductosTodos();
            ventana.ShowDialog();
        }

        private void lblListarProductos_MouseMove(object sender, MouseEventArgs e)
        {
            lblListarProductos.BackColor = Color.Black;
        }

        private void lblListarProductos_MouseLeave(object sender, EventArgs e)
        {
            lblListarProductos.BackColor= Color.MediumPurple;
        }

        private void label1_Click_2(object sender, EventArgs e)
        {
            frmAgregarProductos ventana = new frmAgregarProductos();
            ventana.ShowDialog();
        }

        private void lblNuevo_MouseMove(object sender, MouseEventArgs e)
        {
            lblNuevo.BackColor = Color.Black;
        }

        private void lblNuevo_MouseLeave(object sender, EventArgs e)
        {
            lblNuevo.BackColor= Color.MediumPurple;
        }

        private void lblSalir_MouseLeave(object sender, EventArgs e)
        {
            lblSalir.BackColor= Color.MediumPurple;
        }

        private void lblSalir_MouseMove(object sender, MouseEventArgs e)
        {
            lblSalir.BackColor = Color.Black;
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
