using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace AppGrupal
{
    class negocioProducto
    {
        public bool agregarProducto(Producto p, int idMarca, int idCategoria)
        {
            conexionSQL conex = new conexionSQL();
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO Articulos VALUES ('" + p.codigo + "', '" + p.nombre + "', '" + p.descripcion + "', " + idMarca + ", " + idCategoria + ", '" + p.imagen + "', " + p.precio + ", 1)";
                comando.Connection = conex.conexionDB;

                conex.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                conex.cerrarConexion();

                return true;
            }
            catch (Exception ex)
            {
                conex.cerrarConexion();
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool modificarProducto(Producto p, int idMarca, int idCategoria)
        {
            conexionSQL conex = new conexionSQL();
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE Articulos SET Codigo = '" + p.codigo + "', Nombre = '" + p.nombre + "', Descripcion = '" + p.descripcion + "', idMarca = " + idMarca + ", idCategoria = " + idCategoria + ", Precio = " + p.precio + ", ImagenUrl = '" + p.imagen + "' WHERE id = " + p.id;
                comando.Connection = conex.conexionDB;

                conex.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                conex.cerrarConexion();

                return true;
            }
            catch (Exception ex)
            {
                conex.cerrarConexion();
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool eliminarProducto(int idProducto)
        {
            conexionSQL conex = new conexionSQL();
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE Articulos SET Estado = 0 WHERE id = " + idProducto;
                comando.Connection = conex.conexionDB;

                conex.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                conex.cerrarConexion();

                return true;
            }
            catch (Exception ex)
            {
                conex.cerrarConexion();
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
