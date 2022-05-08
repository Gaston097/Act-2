using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominios;

namespace negocios

{
    public class conexionSQL
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public conexionSQL()
        {
            try
            {
                comando = new SqlCommand();
                conexion = new SqlConnection("server=localhost; database=CATALOGO_DB; integrated security=true;"); //Lucas
                //conexion = new SqlConnection("Data Source=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true;"); //Gaston
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
        public void ejecutarQuery()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
        public SqlDataReader Lector { get { return lector; } }
    }
}
