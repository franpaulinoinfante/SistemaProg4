using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace SistemaProg4
{
    public class ITBIS_DAO : Conexion
    {
        SqlDataReader leerfilas;
        //DataTable tabla;


        protected DataTable MostrarRegistro()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_Buscar_Registro";

                    cmd.Connection = connection;
                    leerfilas = cmd.ExecuteReader();

                    using (var tabla = new DataTable())
                    {
                        //tabla = new DataTable();
                        tabla.Load(leerfilas);
                        return tabla;
                    }
                }
            }
        }

        protected void Insertar(string descripcion, float tarifa)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = "SP_Insertar_Regristro";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar, 400));
                    cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Float));
                    cmd.Parameters["@Descripcion"].Value = descripcion;
                    cmd.Parameters["@Valor"].Value = tarifa;

                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        protected void Editar(int id, string descripcion, float tarifa)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = "sp_Actualizar_Registro";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Id_ITBIS", SqlDbType.TinyInt)).Value = id;
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar, 400)).Value = descripcion;
                    cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Float)).Value = tarifa;

                    //cmd.Parameters["@Id_ITBIS"].Value = id;
                    //cmd.Parameters["@Descripcion"].Value = descripcion;
                    //cmd.Parameters["@Valor"].Value = tarifa;

                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
