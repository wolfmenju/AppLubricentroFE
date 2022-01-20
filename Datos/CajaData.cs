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
    public class CajaData
    {
        //Listar Varios
        public static List<Caja> ListarCaja(Caja objCaja)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Caja> listCaja = new List<Caja>();
            SqlConnection cnx = null;
            try
            {
                Conexion cn = new Conexion();
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Caja", cnx);
                cmd.Parameters.AddWithValue("@Tipo", objCaja.nTipo);
                cmd.Parameters.AddWithValue("@IdTurno", objCaja.nIdTurno);
                cmd.Parameters.AddWithValue("@IdCaja", objCaja.nIdCaja);
                cmd.Parameters.AddWithValue("@FechaInicio", objCaja.dFechaInicio);
                cmd.Parameters.AddWithValue("@MontoInicio", objCaja.fMontoInicio);
                cmd.Parameters.AddWithValue("@FechaFinal", objCaja.dFechaFinal);
                cmd.Parameters.AddWithValue("@MontoFinal", objCaja.fMontoFinal);
                cmd.Parameters.AddWithValue("@Usuario", objCaja.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objCaja.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Caja objCajaRe = new Caja();

                    if (objCaja.nTipo == 8)
                    {
                        objCajaRe.nIdCaja= int.Parse(dr[0].ToString());
                    }
                    else if (objCaja.nTipo == 9)
                    {
                        objCajaRe.fMontoInicio = decimal.Parse(dr[0].ToString());
                        objCajaRe.fMontoFinal = decimal.Parse(dr[1].ToString());
                    }
                    else if (objCaja.nTipo == 10)
                    {
                        objCajaRe.nIdCaja = int.Parse(dr[0].ToString());
                        objCajaRe.nIdTurno = int.Parse(dr[1].ToString());
                        objCajaRe.sUsuario = dr[2].ToString();
                        objCajaRe.dFechaInicio =DateTime.Parse(dr[3].ToString());
                        
                        objCajaRe.fMontoInicio = Decimal.Parse(dr[4].ToString());

                        if (dr[5] == DBNull.Value) objCajaRe.dFechaFinal = null;
                        else objCajaRe.dFechaFinal = DateTime.Parse(dr[5].ToString());

                        if (dr[6] == DBNull.Value) objCajaRe.fMontoFinal = null;
                        else objCajaRe.fMontoFinal = Decimal.Parse(dr[6].ToString());
                    }
                    
                    listCaja.Add(objCajaRe);
                }

                return listCaja;
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

        public static int ActualizarCaja(Caja objCaja)
        {
            int respuesta = 0;
            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;
            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Caja", cnx);
                cmd.Parameters.AddWithValue("@Tipo", objCaja.nTipo);
                cmd.Parameters.AddWithValue("@IdTurno", objCaja.nIdTurno);
                cmd.Parameters.AddWithValue("@IdCaja", objCaja.nIdCaja);
                cmd.Parameters.AddWithValue("@FechaInicio", objCaja.dFechaInicio);
                cmd.Parameters.AddWithValue("@MontoInicio", objCaja.fMontoInicio);
                cmd.Parameters.AddWithValue("@FechaFinal", objCaja.dFechaFinal);
                cmd.Parameters.AddWithValue("@MontoFinal", objCaja.fMontoFinal);
                cmd.Parameters.AddWithValue("@Usuario", objCaja.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objCaja.bEstado);
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
