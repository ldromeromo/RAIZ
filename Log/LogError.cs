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
    public class LogError
    {
        public void AgregarLogError(ref string error, string proyecto, string ruta, string metodo, string mensaje, string excepcionInterna)
        {
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["STC_NUEVA_MALLA"].ToString();

                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("SP_LOG_ERROR", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PROYECTO", proyecto);
                    cmd.Parameters.AddWithValue("@RUTA", ruta);
                    cmd.Parameters.AddWithValue("@METODO", metodo);
                    cmd.Parameters.AddWithValue("@MENSAJE", mensaje);
                    cmd.Parameters.AddWithValue("@EXECPCION_INTERNA", excepcionInterna);

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
