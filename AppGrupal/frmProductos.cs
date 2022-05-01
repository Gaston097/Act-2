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

        }
    }
}
