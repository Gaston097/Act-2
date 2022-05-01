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
                conexion.cerrarConexion();

                return true;
            }
            catch (Exception ex)
            {
                conexion.cerrarConexion();
                MessageBox.Show(ex.Message);
                return false;
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
                conexion.cerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                conexion.cerrarConexion();
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool eliminarProducto(int idProducto)
        {
            conexionSQL conexion = new conexionSQL();
            try
            {
                conexion.setearConsulta("UPDATE Articulos SET Estado = 0 WHERE id = " + idProducto);
                conexion.ejecutarQuery();
                conexion.cerrarConexion();

                return true;
            }
            catch (Exception ex)
            {
                conexion.cerrarConexion();
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
