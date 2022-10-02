using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    public class LogInfo
    {
        public int AgregarLogInfo(ref string error, string proyecto)
        {
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["STC_NUEVA_MALLA"].ToString();
                int idSalida = default;

                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("SP_LOG_INFO", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PROCESO", 1);
                    cmd.Parameters.AddWithValue("@PROYECTO", proyecto);
                    cmd.Parameters.AddWithValue("@ID_PROCESO", 0);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            idSalida = Convert.ToInt32(rdr["id"]);
                        }
                    }

                    cn.Close();

                    return idSalida;
                }
            }
            catch (Exception e)
            {
                error = e.Message;
                throw;
            }
        }

        public void ActualizarLogInfo(ref string error, int id)
        {
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["STC_NUEVA_MALLA"].ToString();
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("SP_LOG_INFO", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PROCESO", 2);
                    cmd.Parameters.AddWithValue("@PROYECTO", string.Empty);
                    cmd.Parameters.AddWithValue("@ID_PROCESO", id);
                    cmd.ExecuteReader();

                    cn.Close();
                }
            }
            catch (Exception e)
            {
                error = e.Message;
                throw;
            }
        }
    }
}
