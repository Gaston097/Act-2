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

        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            conexionSQL conex = new conexionSQL();
            SqlCommand comando = new SqlCommand();

            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT P.id id, P.codigo codigo, P.descripcion descripcion, P.precioVenta precioVenta, P.stock stock, M.nombre marca, PROV.razonSocial razonSocial, P.observaciones observaciones, P.fechaAlta fechaAlta FROM Productos P INNER JOIN Marcas M on M.id = P.idMarca INNER JOIN Proveedores PROV on PROV.id = P.idProveedor WHERE P.estado = 1";
                comando.Connection = conex.conexionDB;

                conex.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Producto p = new Producto();

                    p.id = (int)lector["id"];
                    p.codigo = (string)lector["codigo"];
                    p.descripcion = (string)lector["descripcion"];
                    p.precioVenta = (decimal)lector["precioVenta"];
                    p.stock = (int)lector["stock"];
                    p.marca = (string)lector["marca"];
                    p.proveedor = (string)lector["razonSocial"];
                    p.observaciones = (string)lector["observaciones"];
                    p.fechaAlta = (DateTime)lector["fechaAlta"];

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
                comando.CommandText = "SELECT P.id, P.codigo, P.descripcion, P.precioVenta, P.stock, M.nombre, PROV.razonSocial, P.observaciones, P.fechaAlta FROM Productos P INNER JOIN Marcas M on M.id = P.idMarca INNER JOIN Proveedores PROV on PROV.id = P.idProveedor WHERE P.estado = 1";
                comando.Connection = conex.conexionDB;

                conex.abrirConexion();

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Producto p = new Producto();

                    p.id = (int)lector["id"];
                    p.codigo = (string)lector["codigo"];
                    p.descripcion = (string)lector["descripcion"];
                    p.precioVenta = (decimal)lector["precioVenta"];
                    p.stock = (int)lector["stock"];
                    p.marca = (string)lector["nombre"];
                    p.proveedor = (string)lector["razonSocial"];
                    p.observaciones = (string)lector["observaciones"];
                    p.fechaAlta = (DateTime)lector["fechaAlta"];

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
