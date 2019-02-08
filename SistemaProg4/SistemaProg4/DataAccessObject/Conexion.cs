using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SistemaProg4
{
    public abstract class Conexion
    {
        private readonly string cadenaConexion;
        public Conexion()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["SistemaBD"].ToString();
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(cadenaConexion);
        }



        //private SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-HJ9CFT2\\FRANPAULINO;Initial Catalog=SistemaBD;Integrated Security=True");

        //public SqlConnection OpenConectar()
        //{
        //    if (conexion.State == ConnectionState.Closed)
        //    {
        //        conexion.Open();
        //    }
        //    return conexion;
        //}

        //public SqlConnection CloseConectar()
        //{
        //    if (conexion.State == ConnectionState.Open)
        //    {
        //        conexion.Close();
        //    }
        //    return conexion;
        //}
    }


}
