using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SistemaProg4
{
    public class ITBIS_DAO : Conexion
    {
        public DataTable ListITBIS()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = "sp_Buscar_Registro";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;

                    using (SqlDataReader leerfilas = cmd.ExecuteReader())
                    {
                        using (var table = new DataTable())
                        {
                            table.Load(leerfilas);
                            return table;
                        }
                    }
                }
            }
        }

        public void Insertar(ITBIS_DTO objIBTIS)
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
                    cmd.Parameters["@Descripcion"].Value = objIBTIS.pDescripcion;
                    cmd.Parameters["@Valor"].Value = objIBTIS.pTarifa;

                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Editar(ITBIS_DTO objITBIS_DTO)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = "sp_Actualizar_Registro";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Id_ITBIS", SqlDbType.TinyInt)).Value = objITBIS_DTO.pId;

                    cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar, 400)).Value = objITBIS_DTO.pDescripcion;

                    cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Float)).Value = objITBIS_DTO.pTarifa;

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
