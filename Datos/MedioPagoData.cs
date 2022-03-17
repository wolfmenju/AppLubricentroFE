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
    public class MedioPagoData
    {
        //Listar Varios
        public static List<MedioPago> ListarMedioPago(bool estado)
        {
            int tipo = 1;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<MedioPago> listMedioPago = new List<MedioPago>();
            SqlConnection cnx = null;
            try
            {
                Conexion cn = new Conexion();
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_MedioPago", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdMedioPago", "");
                cmd.Parameters.AddWithValue("@Descripcion", "");
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    MedioPago objMedPago = new MedioPago();
                    objMedPago.nIdMedioPago = int.Parse(dr[0].ToString());
                    objMedPago.sDescripcion = dr[1].ToString();

                    listMedioPago.Add(objMedPago);

                }
                return listMedioPago;
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
        
        //Actualizar
        public static int ActualizarMedioPago(MedioPago objMedioPago)
        {
            int respuesta = 0, tipo = 3 ;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;

            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_MedioPago", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdMedioPago", objMedioPago.nIdMedioPago);
                cmd.Parameters.AddWithValue("@Descripcion", objMedioPago.sDescripcion);
                cmd.Parameters.AddWithValue("@Usuario", objMedioPago.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objMedioPago.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                respuesta= cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                respuesta = 2;
                MessageBox.Show(ex.Message,"Alerta",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {
                cnx.Close();
                cnx.Dispose();
            }

            return respuesta;
        }

        //Registrar
        public static int RegistrarMedioPago(MedioPago objMedioPago)
        {
            int respuesta = 0, tipo = 2;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;

            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_MedioPago", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdMedioPago", objMedioPago.nIdMedioPago);
                cmd.Parameters.AddWithValue("@Descripcion", objMedioPago.sDescripcion);
                cmd.Parameters.AddWithValue("@Usuario", objMedioPago.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objMedioPago.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                respuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                respuesta = 2;
                MessageBox.Show(ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                cnx.Close();
                cnx.Dispose();
            }

            return respuesta;
        }

        //Eliminar
        public static int EliminarActivarMedioPago(MedioPago objMedioPago)
        {
            int respuesta = 0, tipo=4;
            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;
            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_MedioPago", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdMedioPago", objMedioPago.nIdMedioPago);
                cmd.Parameters.AddWithValue("@Descripcion", objMedioPago.sDescripcion);
                cmd.Parameters.AddWithValue("@Usuario", objMedioPago.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objMedioPago.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                respuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                respuesta = 2;
                MessageBox.Show(ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                cnx.Close();
                cnx.Dispose();
            }

            return respuesta;
        }

    }
}
