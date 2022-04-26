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
                comando.CommandText = "UPDATE Articulos SET Codigo = '" + p.codigo + "', Nombre = '" + p.nombre + "', Descripcion = '" + p.descripcion + "', idMarca = " + idMarca + ", idCategoria = " + idCategoria + ", Precio = " + p.precio + "WHERE id = " + p.id;
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
        public DataTable obtenerMarcas(ComboBox cbMarca)
        {
            conexionSQL conex = new conexionSQL();
            SqlCommand comando = new SqlCommand();
            DataTable dt = new DataTable(); 
            {
                conex.abrirConexion();

                string consulta = "SELECT id, descripcion FROM Marcas WHERE Estado = 1";
                SqlCommand cmd = new SqlCommand(consulta, conex.conexionDB);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            cbMarca.ValueMember = "id";
            cbMarca.DisplayMember = "descripcion";
            cbMarca.DataSource = dt;
            cbMarca.SelectedIndex = -1;

            return dt;
        }
        public DataTable obtenerCategorias(ComboBox cbCategoria)
        {
            conexionSQL conex = new conexionSQL();
            SqlCommand comando = new SqlCommand();
            DataTable dt = new DataTable();
            {
                conex.abrirConexion();

                string consulta = "SELECT id, descripcion FROM Categorias WHERE Estado = 1";
                SqlCommand cmd = new SqlCommand(consulta, conex.conexionDB);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            cbCategoria.ValueMember = "id";
            cbCategoria.DisplayMember = "descripcion";
            cbCategoria.DataSource = dt;
            cbCategoria.SelectedIndex = -1;

            return dt;
        }

    }
}
