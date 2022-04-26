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
                comando.CommandText = "SELECT A.id id, A.codigo codigo, A.nombre nombre, A.descripcion descripcion, A.precio precio, M.Descripcion marca, C.Descripcion categoria, A.ImagenUrl imagen FROM Articulos A INNER JOIN Marcas M on M.id = A.idMarca INNER JOIN Categorias C on C.id = A.IdCategoria  WHERE A.Estado = 1";
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
                comando.CommandText = "SELECT A.id id, A.codigo codigo, A.nombre nombre, A.descripcion descripcion, A.precio precio, M.Descripcion marca, C.Descripcion categoria, A.ImagenUrl imagen FROM Articulos A INNER JOIN Marcas M on M.id = A.idMarca INNER JOIN Categorias C on C.id = A.IdCategoria WHERE A.Estado = 1";
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
    }
}
