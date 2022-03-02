using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public class ServerData
    {
        //Fecha Actual de BD
        public static DateTime FechaActual()
        {
            SqlCommand cmd = null;
            SqlConnection cnx = null;

            try
            {
                Conexion cn = new Conexion();
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("SELECT GETDATE() FECHAHORA", cnx);
                cmd.CommandType = CommandType.Text;
                cnx.Open();
                return (DateTime)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnx.Close();
                cnx.Dispose();
            }
        }

    }
}
