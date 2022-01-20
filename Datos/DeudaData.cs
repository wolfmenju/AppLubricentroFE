using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public class DeudaData
    {
        //Listar Varios
        public static List<Deuda> ListarDeuda(Deuda objDeuda)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Deuda> listDeuda = new List<Deuda>();
            SqlConnection cnx = null;
            try
            {
                Conexion cn = new Conexion();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Deuda", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tipo", objDeuda.nTipo);
                cmd.Parameters.AddWithValue("@IdDeuda", objDeuda.nIdDeuda);
                cmd.Parameters.AddWithValue("@Fecha", objDeuda.dFecha);
                cmd.Parameters.AddWithValue("@FechaPago", objDeuda.dFechaPago);
                cmd.Parameters.AddWithValue("@IdProveedor", objDeuda.nIdProveedor);
                cmd.Parameters.AddWithValue("@IdReferencia", objDeuda.nIdReferencia);
                cmd.Parameters.AddWithValue("@Entrada", objDeuda.bEntrada);
                cmd.Parameters.AddWithValue("@IdDocumento", objDeuda.sIdDocumento);
                cmd.Parameters.AddWithValue("@Serie", objDeuda.sSerie); 
                cmd.Parameters.AddWithValue("@Numero", objDeuda.nNumero);
                cmd.Parameters.AddWithValue("@Monto", objDeuda.fMonto);
                cmd.Parameters.AddWithValue("@Saldo", objDeuda.fSaldo);
                cmd.Parameters.AddWithValue("@Usuario", objDeuda.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objDeuda.bEstado);
            
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Deuda objDeu = new Deuda();

                    if (objDeuda.nTipo == 5)
                    {
                        objDeu.nIdDetalleDeuda = int.Parse(dr[0].ToString());
                        objDeu.nIdDeuda = int.Parse(dr[1].ToString());
                        objDeu.dFecha = DateTime.Parse(dr[2].ToString());
                        objDeu.sObservacion = dr[3].ToString();
                        objDeu.fMonto = decimal.Parse(dr[4].ToString());
                    }
                    else if (objDeuda.nTipo == 8 || objDeuda.nTipo == 9)
                    { 
                        objDeu.nIdDeuda = int.Parse(dr[0].ToString());
                        objDeu.sIdDocumento = dr[1].ToString();
                        objDeu.sSerie = dr[2].ToString();
                        objDeu.dFecha = DateTime.Parse(dr[3].ToString());
                        objDeu.sRuc = dr[4].ToString();
                        objDeu.sObservacion= dr[5].ToString();
                        objDeu.nNumero = int.Parse(dr[6].ToString());
                        objDeu.fSaldo = decimal.Parse(dr[7].ToString());
                    }
                    else
                    {
                        objDeu.nIdDeuda = int.Parse(dr[0].ToString());
                        objDeu.sIdDocumento = dr[1].ToString();
                        objDeu.sSerie = dr[2].ToString();
                        objDeu.dFecha = DateTime.Parse(dr[3].ToString());
                        objDeu.sRuc = dr[4].ToString();
                        objDeu.sObservacion = dr[5].ToString();
                        objDeu.nNumero = int.Parse(dr[6].ToString());
                        objDeu.fMonto = decimal.Parse(dr[7].ToString());
                        objDeu.fSaldo = decimal.Parse(dr[8].ToString());
                    }

                    listDeuda.Add(objDeu);
                }

                return listDeuda;
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

        public static int RegistrarAbonoDeuda(Deuda objDeuda)
        {
            int respuesta = 0;

            SqlCommand cmdDetalle = null;
            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlTransaction xTrans;
            
            SqlConnection cnx = cn.getConecta();
            cnx.Open();
            xTrans = cnx.BeginTransaction();
            
            try
            {
                cmd = new SqlCommand("IAE_Deuda", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tipo", objDeuda.nTipo);
                cmd.Parameters.AddWithValue("@IdDeuda", objDeuda.nIdDeuda);
                cmd.Parameters.AddWithValue("@Fecha", objDeuda.dFecha);
                cmd.Parameters.AddWithValue("@FechaPago", objDeuda.dFechaPago);
                cmd.Parameters.AddWithValue("@IdProveedor", objDeuda.nIdProveedor);
                cmd.Parameters.AddWithValue("@IdReferencia", objDeuda.nIdReferencia);
                cmd.Parameters.AddWithValue("@Entrada", objDeuda.bEntrada);
                cmd.Parameters.AddWithValue("@IdDocumento", objDeuda.sIdDocumento);
                cmd.Parameters.AddWithValue("@Serie", objDeuda.sSerie);
                cmd.Parameters.AddWithValue("@Numero", objDeuda.nNumero);
                cmd.Parameters.AddWithValue("@Monto", objDeuda.fMonto);
                cmd.Parameters.AddWithValue("@Saldo", objDeuda.fSaldo);
                cmd.Parameters.AddWithValue("@Usuario", objDeuda.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objDeuda.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = xTrans;
                respuesta = cmd.ExecuteNonQuery();

                if (respuesta <= 0)
                {
                    xTrans.Rollback();
                }
                else
                {
                    respuesta = 0;
                    cmdDetalle = new SqlCommand("IAE_DetalleDeuda", cnx);
                    cmdDetalle.Parameters.AddWithValue("@Tipo", objDeuda.nSubTipo);
                    cmdDetalle.Parameters.AddWithValue("@IdDetalleDeuda", objDeuda.nIdDetalleDeuda);
                    cmdDetalle.Parameters.AddWithValue("@IdDeuda", objDeuda.nIdDeuda);
                    cmdDetalle.Parameters.AddWithValue("@Fecha", objDeuda.dFecha);
                    cmdDetalle.Parameters.AddWithValue("@Observacion", objDeuda.sObservacion);
                    cmdDetalle.Parameters.AddWithValue("@Monto", objDeuda.fSaldo);
                    cmdDetalle.Parameters.AddWithValue("@Usuario", objDeuda.sUsuario);
                    cmdDetalle.Parameters.AddWithValue("@Estado", objDeuda.bEstado);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Transaction = xTrans;
                    respuesta = cmdDetalle.ExecuteNonQuery();

                    if (respuesta <= 0)
                    {
                        xTrans.Rollback();
                    }
                    else
                    {
                        xTrans.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                xTrans.Rollback();
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
