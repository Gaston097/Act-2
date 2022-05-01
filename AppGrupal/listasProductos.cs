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
    class listasProductos
    {
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            conexionSQL conex = new conexionSQL();
            SqlCommand comando = new SqlCommand();

            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT A.id id, A.codigo codigo, A.nombre nombre, A.descripcion descripcion, A.precio precio, M.Descripcion marca, A.idMarca, C.Descripcion categoria, A.idCategoria, A.ImagenUrl imagen FROM Articulos A INNER JOIN Marcas M on M.id = A.idMarca INNER JOIN Categorias C on C.id = A.IdCategoria  WHERE A.Estado = 1";
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
                    p.precio = (decimal)lector["precio"];

                    if (!(lector["imagen"] is DBNull))
                        p.imagen = (string)lector["imagen"];

                    p.marca = new Elemento();
                    p.marca.descripcion = (string)lector["marca"];
                    p.marca.id = (int)lector["idMarca"];

                    p.categoria = new Elemento();
                    p.categoria.descripcion = (string)lector["categoria"];
                    p.categoria.id = (int)lector["idCategoria"];

                    lista.Add(p);
                }
                conex.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return lista;
            }
        }
        public List<Elemento> listarMarcas()
        {
            List<Elemento> lista = new List<Elemento>();
            conexionSQL conex = new conexionSQL();
            SqlCommand comando = new SqlCommand();

            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT id, descripcion FROM Marcas WHERE Estado = 1";
                comando.Connection = conex.conexionDB;

                conex.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Elemento e = new Elemento();

                    e.id = (int)lector["id"];
                    e.descripcion = (string)lector["descripcion"];

                    lista.Add(e);
                }
                conex.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return lista;
            }
        }
        public List<Elemento> listarCategorias()
        {
            List<Elemento> lista = new List<Elemento>();
            conexionSQL conex = new conexionSQL();
            SqlCommand comando = new SqlCommand();

            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT id, descripcion FROM Categorias WHERE Estado = 1";
                comando.Connection = conex.conexionDB;

                conex.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Elemento e = new Elemento();

                    e.id = (int)lector["id"];
                    e.descripcion = (string)lector["descripcion"];

                    lista.Add(e);
                }
                conex.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return lista;
            }
        }
    }
}
