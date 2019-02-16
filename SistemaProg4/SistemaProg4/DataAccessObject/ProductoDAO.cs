using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaProg4.DataTransferObjects;

namespace SistemaProg4.DataAccessObject
{
    public class ProductoDAO : Conexion
    {
        //public DataTable ListarImpuesto()
        //{
        //    using (var connection = GetConnection())
        //    {
        //        connection.Open();
        //        using (var cmd = new SqlCommand())
        //        {
        //            cmd.Connection = connection;
        //            cmd.CommandText = "sp_Listar_Impuesto";
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            using (SqlDataReader leerfilas = cmd.ExecuteReader())
        //            {
        //                using (var table = new DataTable())
        //                {
        //                    table.Load(leerfilas);
        //                    return table;
        //                }
        //            }
        //        }
        //    }
        //}
        public DataTable ListProducto()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using(var cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_Listar_Producto";
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leerfilas = cmd.ExecuteReader())
                    {
                        using (var table = new  DataTable())
                        {
                            table.Load(leerfilas);
                            return table;
                        }
                    }
                }
            }
        }

        public void InsertarProducto(ProductoDTO producto)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd=new SqlCommand())
                {
                    cmd.CommandText = "sp_Insertar_Producto";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Marca", SqlDbType.NVarChar, 400)).Value = producto.pMarca;

                    cmd.Parameters.Add(new SqlParameter("@Modelo", SqlDbType.NVarChar, 400)).Value = producto.pModelo;

                    cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar, 400)).Value = producto.pDescripcion;

                    cmd.Parameters.Add(new SqlParameter("@Notas", SqlDbType.NVarChar, 400)).Value = producto.pNotas;

                    //cmd.Parameters.Add(new SqlParameter("@Imagen", SqlDbType.VarBinary)).Value = producto.pImagen;

                    cmd.Parameters.Add(new SqlParameter("@Id_ITBIS", SqlDbType.Int)).Value = producto.pId_ITBIS;

                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditarProducto(ProductoDTO producto)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = "sp_Actualizar_Producto";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Id_Producto", SqlDbType.Int)).Value = producto.pId;

                    cmd.Parameters.Add(new SqlParameter("@Marca", SqlDbType.NVarChar, 400)).Value = producto.pMarca;

                    cmd.Parameters.Add(new SqlParameter("@Modelo", SqlDbType.NVarChar, 400)).Value = producto.pModelo;

                    cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar, 400)).Value = producto.pDescripcion;

                    cmd.Parameters.Add(new SqlParameter("@Notas", SqlDbType.NVarChar, 400)).Value = producto.pNotas;

                    //cmd.Parameters.Add(new SqlParameter("@Imagen", SqlDbType.VarBinary)).Value = producto.pImagen;

                    cmd.Parameters.Add(new SqlParameter("@Id_ITBIS", SqlDbType.Int)).Value = producto.pId_ITBIS;

                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
