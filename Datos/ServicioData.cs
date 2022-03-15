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
    public class ServicioData
    {
        //Listar Varios
        public static List<Servicio> ListarServicio(Servicio objServicio)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            SqlConnection cnx = null;

            List<Servicio> listServicio = new List<Servicio>();
            try
            {
                Conexion cn = new Conexion();
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Servicio", cnx);
                cmd.Parameters.AddWithValue("@Tipo", objServicio.nTipo);
                cmd.Parameters.AddWithValue("@IdServicio", objServicio.nIdServicio);
                cmd.Parameters.AddWithValue("@Paquete", objServicio.bPaquete);
                cmd.Parameters.AddWithValue("@Precio", objServicio.fPrecio);
                cmd.Parameters.AddWithValue("@Usuario", objServicio.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objServicio.bEstado);

                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Servicio objServ = new Servicio();

                    objServ.nIdServicio = Convert.ToInt32(dr[0]);
                    objServ.sCodigoInterno = dr[1].ToString();
                    objServ.sDescripcion = dr[2].ToString();
                    objServ.fPrecio =Convert.ToDecimal(dr[3].ToString());
                    objServ.bPaquete =Convert.ToBoolean(dr[4].ToString());

                    listServicio.Add(objServ);
                }

                return listServicio;
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
        
        
        //Registrar
        public static int RegistrarServicio(Servicio objServicio)
        {
            int respuesta = 0;

            SqlCommand cmdDetalle = null;
            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlTransaction xTrans ;
            SqlConnection cnx = cn.getConecta();
            cnx.Open();
            xTrans = cnx.BeginTransaction();

            try
            {
                cmd = new SqlCommand("IAE_ProductoFinal", cnx);
                cmd.Parameters.AddWithValue("@Tipo", objServicio.nTipo);
                cmd.Parameters.AddWithValue("@IdProducto", objServicio.nIdServicio);
                cmd.Parameters.AddWithValue("@CodigoInterno", objServicio.sCodigoInterno);
                cmd.Parameters.AddWithValue("@Descripcion", objServicio.sDescripcion);
                cmd.Parameters.AddWithValue("@Usuario", objServicio.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objServicio.bEstado);
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
                    cmdDetalle = new SqlCommand("IAE_Servicio", cnx);
                    cmdDetalle.Parameters.AddWithValue("@Tipo", objServicio.nSubTipo);
                    cmdDetalle.Parameters.AddWithValue("@IdServicio", objServicio.nIdServicio);
                    cmdDetalle.Parameters.AddWithValue("@Paquete", objServicio.bPaquete);
                    cmdDetalle.Parameters.AddWithValue("@Precio", objServicio.fPrecio);
                    cmdDetalle.Parameters.AddWithValue("@Usuario", objServicio.sUsuario);
                    cmdDetalle.Parameters.AddWithValue("@Estado", objServicio.bEstado);
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

        //Registrar
        public static int ActualizarServicio(Servicio objServicio)
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
                cmd = new SqlCommand("IAE_ProductoFinal", cnx);
                cmd.Parameters.AddWithValue("@Tipo", objServicio.nTipo);
                cmd.Parameters.AddWithValue("@IdProducto", objServicio.nIdServicio);
                cmd.Parameters.AddWithValue("@CodigoInterno", objServicio.sCodigoInterno);
                cmd.Parameters.AddWithValue("@Descripcion", objServicio.sDescripcion);
                cmd.Parameters.AddWithValue("@Usuario", objServicio.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objServicio.bEstado);
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
                    cmdDetalle = new SqlCommand("IAE_Servicio", cnx);
                    cmdDetalle.Parameters.AddWithValue("@Tipo", objServicio.nSubTipo);
                    cmdDetalle.Parameters.AddWithValue("@IdServicio", objServicio.nIdServicio);
                    cmdDetalle.Parameters.AddWithValue("@Paquete", objServicio.bPaquete);
                    cmdDetalle.Parameters.AddWithValue("@Precio", objServicio.fPrecio);
                    cmdDetalle.Parameters.AddWithValue("@Usuario", objServicio.sUsuario);
                    cmdDetalle.Parameters.AddWithValue("@Estado", objServicio.bEstado);
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


        public static int EliminarActivarServicio(Servicio objServicio)
        {
            int respuesta = 0, tipo = 3;
            
            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;

            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_ProductoFinal", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdProducto", objServicio.nIdServicio);
                cmd.Parameters.AddWithValue("@Descripcion", objServicio.sDescripcion);
                cmd.Parameters.AddWithValue("@CodigoInterno", objServicio.sCodigoInterno);
                cmd.Parameters.AddWithValue("@Usuario", objServicio.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objServicio.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                respuesta = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
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
