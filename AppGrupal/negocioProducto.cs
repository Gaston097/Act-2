using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AppGrupal
{
    class negocioProducto
    {
        public bool agregarProducto(Producto p)
        {
            conexionSQL conex = new conexionSQL();
            SqlCommand comando = new SqlCommand();

            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO Productos VALUES ('" + p.codigo + "', '" + p.descripcion + "', " + p.precioVenta + "," + p.stock + ", 1, 1, '" + p.observaciones + "',GETDATE() ,NULL,1)";
                comando.Connection = conex.conexionDB;

                conex.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                conex.cerrarConexion();

                return true;
            }
            catch (Exception ex)
            {
                conex.cerrarConexion();
                return false;
            }
        }
    }
}
