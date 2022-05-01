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
            conexionSQL conexion = new conexionSQL();
            try
            {
                conexion.setearConsulta("SELECT A.id id, A.codigo codigo, A.nombre nombre, A.descripcion descripcion, A.precio precio, M.Descripcion marca, A.idMarca, C.Descripcion categoria, A.idCategoria, A.ImagenUrl imagen FROM Articulos A INNER JOIN Marcas M on M.id = A.idMarca INNER JOIN Categorias C on C.id = A.IdCategoria  WHERE A.Estado = 1");
                conexion.ejecutarQuery();

                while (conexion.Lector.Read())
                {
                    Producto p = new Producto();

                    p.id = (int)conexion.Lector["id"];
                    p.codigo = (string)conexion.Lector["codigo"];
                    p.nombre = (string)conexion.Lector["nombre"];
                    p.descripcion = (string)conexion.Lector["descripcion"];
                    p.precio = (decimal)conexion.Lector["precio"];

                    if (!(conexion.Lector["imagen"] is DBNull))
                        p.imagen = (string)conexion.Lector["imagen"];

                    p.marca = new Elemento();
                    p.marca.descripcion = (string)conexion.Lector["marca"];
                    p.marca.id = (int)conexion.Lector["idMarca"];

                    p.categoria = new Elemento();
                    p.categoria.descripcion = (string)conexion.Lector["categoria"];
                    p.categoria.id = (int)conexion.Lector["idCategoria"];

                    lista.Add(p);
                }

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return lista;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }
        public List<Elemento> listarMarcas()
        {
            List<Elemento> lista = new List<Elemento>();
            conexionSQL conexion = new conexionSQL();
            try
            {
                conexion.setearConsulta("SELECT id, descripcion FROM Marcas WHERE Estado = 1");
                conexion.ejecutarQuery();

                while (conexion.Lector.Read())
                {
                    Elemento e = new Elemento();

                    e.id = (int)conexion.Lector["id"];
                    e.descripcion = (string)conexion.Lector["descripcion"];

                    lista.Add(e);
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return lista;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }
        public List<Elemento> listarCategorias()
        {
            List<Elemento> lista = new List<Elemento>();
            conexionSQL conexion = new conexionSQL();
            try
            {
                conexion.setearConsulta("SELECT id, descripcion FROM Categorias WHERE Estado = 1");
                conexion.ejecutarQuery();

                while (conexion.Lector.Read())
                {
                    Elemento e = new Elemento();
                    e.id = (int)conexion.Lector["id"];
                    e.descripcion = (string)conexion.Lector["descripcion"];
                    lista.Add(e);
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return lista;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }
    }
}
