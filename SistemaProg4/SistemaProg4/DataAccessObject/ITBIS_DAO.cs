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
        DataTable tabla;
        SqlCommand comando;

        public DataTable MostrarDatos()
        {
            comando = new SqlCommand();
            //comando.Connection = conexion.OpenConectar();
            comando.CommandText = "SP_Buscar_Todos_Registro";
            leerfilas = comando.ExecuteReader();

            tabla = new DataTable();
            tabla.Load(leerfilas);
            //conexion.CloseConectar();

            comando.Parameters.Clear();
            return tabla;
        }

        protected void Insertar(string descripcion, float tarifa)
        {
            //comando.Connection = conexion.OpenConectar();
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
            //conexion.CloseConectar();
            //comando.Parameters.Clear();
        }
        protected void Editar(int id, string descripcion, float tarifa)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = "SP_Insertar_Regristro";
                    cmd.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add(new SqlParameter("@Id_ITBIS", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar, 400));
                    cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Float));

                    comando.Parameters["@Id_ITBIS"].Value = id;
                    cmd.Parameters["@Descripcion"].Value = descripcion;
                    cmd.Parameters["@Valor"].Value = tarifa;

                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();                    
                }
            }
        }
    }
}
