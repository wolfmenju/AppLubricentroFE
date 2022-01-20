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
    public class InventarioDetalleData
    {
        //Listar Varios
        public static List<InventarioDetalle> ListarInventarioDetalle(InventarioDetalle objInvenDetalle)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            SqlConnection cnx = null;
            List<InventarioDetalle> listInventDetalle = new List<InventarioDetalle>();
            try
            {
                Conexion cn = new Conexion();
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_DetalleInventario", cnx);
                cmd.Parameters.AddWithValue("@Tipo", objInvenDetalle.nTipo);
                cmd.Parameters.AddWithValue("@IdDetalleInventario", objInvenDetalle.nIdInventario);
                cmd.Parameters.AddWithValue("@IdInventario", objInvenDetalle.nIdInventario);
                cmd.Parameters.AddWithValue("@IdProducto", objInvenDetalle.nIdInventario);
                cmd.Parameters.AddWithValue("@IdLote", objInvenDetalle.nIdInventario);
                cmd.Parameters.AddWithValue("@Vencimiento", objInvenDetalle.dFechaVencimiento);
                cmd.Parameters.AddWithValue("@Stock", objInvenDetalle.nStock);
                cmd.Parameters.AddWithValue("@PrecioCompra", objInvenDetalle.fPrecioCompra);
                cmd.Parameters.AddWithValue("@Ganancia", objInvenDetalle.fGanancia);
                cmd.Parameters.AddWithValue("@PrecioVenta", objInvenDetalle.fPrecioVenta);
                cmd.Parameters.AddWithValue("@Usuario", objInvenDetalle.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objInvenDetalle.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    InventarioDetalle objInvent = new InventarioDetalle();
                    listInventDetalle.Add(objInvent);

                }
                return listInventDetalle;
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

        public static int ActualizarInventarioDetalle(InventarioDetalle objInvenDetalle)
        {
            int respuesta = 0;
            SqlCommand cmd = null;
            SqlCommand cmdHistorial = null;
            SqlCommand cmdTarjeta = null;

            Conexion cn = new Conexion();
            SqlTransaction xTrans;
            SqlConnection cnx = cn.getConecta();
            cnx.Open();
            xTrans = cnx.BeginTransaction();

            try
            {
                cmd = new SqlCommand("IAE_DetalleInventario", cnx);
                cmd.Parameters.AddWithValue("@Tipo", objInvenDetalle.nTipo);
                cmd.Parameters.AddWithValue("@IdDetalleInventario", objInvenDetalle.nIdInventario);
                cmd.Parameters.AddWithValue("@IdInventario", objInvenDetalle.nIdInventario);
                cmd.Parameters.AddWithValue("@IdProducto", objInvenDetalle.nIdProducto);
                cmd.Parameters.AddWithValue("@IdLote", objInvenDetalle.sLote);
                cmd.Parameters.AddWithValue("@Vencimiento", objInvenDetalle.dFechaVencimiento);
                cmd.Parameters.AddWithValue("@Stock", objInvenDetalle.nStock);
                cmd.Parameters.AddWithValue("@PrecioCompra", objInvenDetalle.fPrecioCompra);
                cmd.Parameters.AddWithValue("@Ganancia", objInvenDetalle.fGanancia);
                cmd.Parameters.AddWithValue("@PrecioVenta", objInvenDetalle.fPrecioVenta);
                cmd.Parameters.AddWithValue("@Usuario", objInvenDetalle.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objInvenDetalle.bEstado);
                cmd.Transaction = xTrans;
                cmd.CommandType = CommandType.StoredProcedure;
 
                respuesta = cmd.ExecuteNonQuery();

                if (respuesta <= 0)
                {
                    xTrans.Rollback();
                    return respuesta;
                }

                if (objInvenDetalle.nIdInventario == 1)
                {
                    respuesta = 0;
                    cmdHistorial = new SqlCommand("IAE_HistorialProducto", cnx);
                    cmdHistorial.Parameters.AddWithValue("@Tipo", objInvenDetalle.nSubTipo);
                    cmdHistorial.Parameters.AddWithValue("@IdHistorial", objInvenDetalle.nIdHistorial);
                    cmdHistorial.Parameters.AddWithValue("@IdProducto", objInvenDetalle.nIdProducto);
                    cmdHistorial.Parameters.AddWithValue("@IdAlmacen", objInvenDetalle.nIdAlmacen);
                    cmdHistorial.Parameters.AddWithValue("@Lote", objInvenDetalle.sLote);
                    cmdHistorial.Parameters.AddWithValue("@IdLote", objInvenDetalle.sIdLote);
                    cmdHistorial.Parameters.AddWithValue("@PrecioCompra", objInvenDetalle.fPrecioCompra);
                    cmdHistorial.Parameters.AddWithValue("@Ganancia", objInvenDetalle.fGanancia);
                    cmdHistorial.Parameters.AddWithValue("@PrecioVenta", objInvenDetalle.fPrecioVenta);
                    cmdHistorial.Parameters.AddWithValue("@Stock", objInvenDetalle.nStock);
                    cmdHistorial.Parameters.AddWithValue("@Vencimiento", objInvenDetalle.dFechaVencimiento);

                    SqlParameter paramResultado = new SqlParameter("@Codigo", SqlDbType.Int);
                    paramResultado.Direction = ParameterDirection.Output;
                    cmdHistorial.Parameters.Add(paramResultado);

                    cmdHistorial.Parameters.AddWithValue("@Usuario", objInvenDetalle.sUsuario);
                    cmdHistorial.Parameters.AddWithValue("@Estado", objInvenDetalle.bEstado);
                    cmdHistorial.CommandType = CommandType.StoredProcedure;
                    cmdHistorial.Transaction = xTrans;

                    respuesta = cmdHistorial.ExecuteNonQuery();
                    objInvenDetalle.nIdHistorial = (int)paramResultado.Value;

                    if (respuesta <= 0)
                    {
                        xTrans.Rollback();
                        return respuesta;
                    }

                    respuesta = 0;
                    cmdTarjeta = new SqlCommand("IAE_Tarjeta", cnx);
                    cmdTarjeta.Parameters.AddWithValue("@Tipo", objInvenDetalle.nSubTipo);
                    cmdTarjeta.Parameters.AddWithValue("@IdTarjeta", objInvenDetalle.nIdTarjeta);
                    cmdTarjeta.Parameters.AddWithValue("@Fecha", objInvenDetalle.dFecha);
                    cmdTarjeta.Parameters.AddWithValue("@IdAlmacen", objInvenDetalle.nIdAlmacen);
                    cmdTarjeta.Parameters.AddWithValue("@IdHistorial", objInvenDetalle.nIdHistorial);
                    cmdTarjeta.Parameters.AddWithValue("@TipoMovimiento", objInvenDetalle.bTipoMovimiento);
                    cmdTarjeta.Parameters.AddWithValue("@IdReferencia", objInvenDetalle.nIdReferencia);
                    cmdTarjeta.Parameters.AddWithValue("@Lote", objInvenDetalle.sLote);
                    cmdTarjeta.Parameters.AddWithValue("@Vencimiento", objInvenDetalle.dFechaVencimiento);
                    cmdTarjeta.Parameters.AddWithValue("@IdDocumento", objInvenDetalle.sIdDocumento);
                    cmdTarjeta.Parameters.AddWithValue("@Serie", objInvenDetalle.sSerie);
                    cmdTarjeta.Parameters.AddWithValue("@Numero", objInvenDetalle.nNumero);
                    cmdTarjeta.Parameters.AddWithValue("@IdProducto", objInvenDetalle.nIdProducto);
                    cmdTarjeta.Parameters.AddWithValue("@Entrada", objInvenDetalle.nEntrada);
                    cmdTarjeta.Parameters.AddWithValue("@Salida", objInvenDetalle.nSalida);
                    cmdTarjeta.Parameters.AddWithValue("@Existencia", objInvenDetalle.nExistencia);
                    cmdTarjeta.Parameters.AddWithValue("@PrecioCompra", objInvenDetalle.fPrecioCompra);
                    cmdTarjeta.Parameters.AddWithValue("@PrecioVenta", objInvenDetalle.fPrecioVenta);
                    cmdTarjeta.Parameters.AddWithValue("@Debe", objInvenDetalle.fDebe);
                    cmdTarjeta.Parameters.AddWithValue("@Haber", objInvenDetalle.fHaber);
                    cmdTarjeta.Parameters.AddWithValue("@Codigo", 0);
                    cmdTarjeta.Parameters.AddWithValue("@Saldo", objInvenDetalle.fSaldo);
                    cmdTarjeta.Parameters.AddWithValue("@Usuario", objInvenDetalle.sUsuario);
                    cmdTarjeta.Parameters.AddWithValue("@Estado", objInvenDetalle.bEstado);
                    cmdTarjeta.CommandType = CommandType.StoredProcedure;
                    cmdTarjeta.Transaction = xTrans;

                    respuesta = cmdTarjeta.ExecuteNonQuery();

                    if (respuesta <= 0)
                    {
                        xTrans.Rollback();
                        return respuesta;
                    }
                }

                if (respuesta > 0) xTrans.Commit();

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
