using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AppGrupal
{
    class conexionSQL
    {
        SqlConnection conexionDB = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        string cadenaConexion = "server=localhost; database=Productos; integrated security=true;";

        public SqlConnection abrirConexion()
        {
            try
            {
                conexionDB.ConnectionString = cadenaConexion;
                conexionDB.Open();
                //MessageBox.Show("Se establecio conexion con la DB");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo establecer conexion con la DB" + ex.Message);
            }
            return conexionDB;
        }

        public SqlConnection cerrarConexion()
        {
            try
            {
                conexionDB.ConnectionString = cadenaConexion;
                conexionDB.Close();
                //MessageBox.Show("Se cerro la conexion con la DB");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cerrar la conexion con la DB" + ex.Message);
            }
            return conexionDB;
        }
    }
}
