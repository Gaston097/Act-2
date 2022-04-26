using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

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
                comando.CommandText = "INSERT INTO Articulos VALUES ('" + p.codigo + "', '" + p.nombre + "', '" + p.descripcion + "', " + idMarca + ", " + idCategoria + ", '" + p.imagen + "', " + p.precioVenta + ")";
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

        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            conexionSQL conex = new conexionSQL();
            SqlCommand comando = new SqlCommand();

            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT A.id id, A.codigo codigo, A.nombre nombre, A.descripcion descripcion, A.precio precio, M.Descripcion marca, C.Descripcion categoria, A.ImagenUrl imagen FROM Articulos A INNER JOIN Marcas M on M.id = A.idMarca INNER JOIN Categorias C on C.id = A.IdCategoria";
                comando.Connection = conex.conexionDB;

                conex.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Producto p = new Producto();

                    p.id = (int)lector["id"];
                    p.codigo = (string)lector["codigo"];
                    p.nombre = (string)lector["nombre"];
                    p.descripcion = (string)lector["descripcion"];
                    p.precioVenta = (decimal)lector["precio"];
                    p.marca = (string)lector["marca"];
                    p.categoria = (string)lector["categoria"];
                    p.imagen = (string)lector["imagen"];

                    lista.Add(p);
                }
                conex.cerrarConexion();
                return lista;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
                return lista;
            }
        }

        public List<Producto> listarModificar()
        {
            List<Producto> lista = new List<Producto>();
            conexionSQL conex = new conexionSQL();
            SqlCommand comando = new SqlCommand();

            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT A.id id, A.codigo codigo, A.nombre nombre, A.descripcion descripcion, A.precio precio, M.Descripcion marca, C.Descripcion categoria, A.ImagenUrl imagen FROM Articulos A INNER JOIN Marcas M on M.id = A.idMarca INNER JOIN Categorias C on C.id = A.IdCategoria";
                comando.Connection = conex.conexionDB;

                conex.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Producto p = new Producto();

                    p.id = (int)lector["id"];
                    p.codigo = (string)lector["codigo"];
                    p.nombre = (string)lector["nombre"];
                    p.descripcion = (string)lector["descripcion"];
                    p.precioVenta = (decimal)lector["precioVenta"];
                    p.marca = (string)lector["marca"];
                    p.categoria = (string)lector["categoria"];
                    p.imagen = (string)lector["imagen"];

                    lista.Add(p);
                }
                conex.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cbMarcas (ComboBox cbM)
        {
            conexionSQL conex = new conexionSQL();
            SqlCommand comando = new SqlCommand();

            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT id, descripcion FROM Marcas";
                comando.Connection = conex.conexionDB;

                conex.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    cbM.Items.Add((string)lector["descripcion"]);
                    cbM.ValueMember = ((int)lector["id"]).ToString();
                }

                }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }

        public void cbCategorias(ComboBox cbC)
        {
            conexionSQL conex = new conexionSQL();
            SqlCommand comando = new SqlCommand();

            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT id, descripcion FROM Categorias";
                comando.Connection = conex.conexionDB;

                conex.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    cbC.Items.Add((string)lector["descripcion"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
