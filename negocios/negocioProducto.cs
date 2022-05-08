using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//using System.Windows.Forms;
using System.Data;
using dominios;

namespace negocios
{
    public class negocioProducto
    {
        public bool agregarProducto(Producto p,int idMarca, int idCategoria)
        {
            conexionSQL conexion = new conexionSQL();
            SqlCommand comando = new SqlCommand();
            try
            {     
                conexion.setearConsulta("INSERT INTO Articulos VALUES (@Codigo, @Nombre, @Descripcion, @idMarca, @idCategoria, @ImagenUrl, @Precio, 1)");
                conexion.setearParametro("@Codigo", p.codigo);
                conexion.setearParametro("@Nombre", p.nombre);
                conexion.setearParametro("@Descripcion", p.descripcion);
                conexion.setearParametro("@IdMarca", idMarca);
                conexion.setearParametro("@idCategoria", idCategoria);
                conexion.setearParametro("@Precio", p.precio);
                conexion.setearParametro("@ImagenUrl", p.imagen);
                conexion.ejecutarQuery();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }
        public bool modificarProducto(Producto p, int idMarca, int idCategoria)
        {
            conexionSQL conexion = new conexionSQL();
            try
            {
                conexion.setearConsulta("UPDATE Articulos SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, idMarca = @IdMarca, idCategoria = @IdCategoria, Precio = @Precio, ImagenUrl = @ImagenUrl WHERE id = @Id");
                conexion.setearParametro("@Codigo", p.codigo);
                conexion.setearParametro("@Nombre",p.nombre);
                conexion.setearParametro("@Descripcion",p.descripcion);
                conexion.setearParametro("@IdMarca",idMarca);
                conexion.setearParametro("@idCategoria",idCategoria);
                conexion.setearParametro("@Precio",p.precio);
                conexion.setearParametro("@ImagenUrl",p.imagen);
                conexion.setearParametro("@Id",p.id);
                conexion.ejecutarQuery();
                return true;
            }
            catch (Exception ex)
            {          
             //   messagebox.Show(ex.Message);
                return false;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }
        public bool eliminarProducto(int idProducto)
        {
            conexionSQL conexion = new conexionSQL();
            try
            {
                conexion.setearConsulta("UPDATE Articulos SET Estado = 0 WHERE id = " + idProducto);
                conexion.ejecutarQuery();

                return true;
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public List<Producto> filtrar(string campo, string criterio, string filtro)
        {
            List<Producto> lista = new List<Producto>();
           conexionSQL datos = new conexionSQL();
            try
            {
                string consulta = "SELECT A.id id, A.codigo codigo, A.nombre nombre, A.descripcion descripcion, A.precio precio, M.Descripcion marca, A.idMarca, C.Descripcion categoria, A.idCategoria, A.ImagenUrl imagen FROM Articulos A INNER JOIN Marcas M on M.id = A.idMarca INNER JOIN Categorias C on C.id = A.IdCategoria  WHERE A.Estado = 1 and ";
                switch (campo)
                {
                    case "Código":
                        switch (criterio)
                        {
                            case "Igual a":
                                consulta += "codigo =" + " '" + filtro + "'";
                                break;
                            case "Comienza con":
                                consulta += "codigo like '"+filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "codigo like '%" + filtro + "'";
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Nombre":
                        break;
                    case "Descripción":
                        break;
                    case "Precio":
                        break;
                    case "Marca":
                        break;
                    case "Categoria":
                    default:
                        break;
                }
                datos.setearConsulta(consulta);
                datos.ejecutarQuery();
                while (datos.Lector.Read())
                {
                    Producto p = new Producto();
                    p.id = (int)datos.Lector["id"];
                    p.codigo = (string)datos.Lector["codigo"];
                    p.nombre = (string)datos.Lector["nombre"];
                    p.descripcion = (string)datos.Lector["descripcion"];
                    p.precio = (decimal)datos.Lector["precio"];

                    if (!(datos.Lector["imagen"] is DBNull))
                        p.imagen = (string)datos.Lector["imagen"];

                    p.marca = new Elemento();
                    p.marca.descripcion = (string)datos.Lector["marca"];
                    p.marca.id = (int)datos.Lector["idMarca"];

                    p.categoria = new Elemento();
                    p.categoria.descripcion = (string)datos.Lector["categoria"];
                    p.categoria.id = (int)datos.Lector["idCategoria"];

                    lista.Add(p);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
