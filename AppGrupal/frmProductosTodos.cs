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
            negocioProducto p = new negocioProducto();

            dgvProductos.DataSource = p.listar();

            this.dgvProductos.Columns["id"].Visible = false;
            this.dgvProductos.Columns["imagen"].Visible = false;

        }
    }
}
