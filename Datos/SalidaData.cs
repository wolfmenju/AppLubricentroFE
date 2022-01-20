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
    public class SalidaData
    {
        //Listar Varios
        public static List<Salida> ListarSalida(Salida objVenta)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Salida> listSalida = new List<Salida>();
            SqlConnection cnx = null;
            try
            {
                Conexion cn = new Conexion();
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Salida", cnx);
                cmd.Parameters.AddWithValue("@Tipo", objVenta.nTipo);
                cmd.Parameters.AddWithValue("@IdSalida", objVenta.nIdVenta);
                cmd.Parameters.AddWithValue("@IdAlmacen", objVenta.nIdAlmacen);
                cmd.Parameters.AddWithValue("@IdPedido", objVenta.nIdPedido);
                cmd.Parameters.AddWithValue("@IdDocumento", objVenta.sIdDocumento);
                cmd.Parameters.AddWithValue("@Serie", objVenta.sSerie);
                cmd.Parameters.AddWithValue("@Numero", objVenta.nNumero);
                cmd.Parameters.AddWithValue("@Fecha", objVenta.dFecha);
                cmd.Parameters.AddWithValue("@Porcentaje", objVenta.nPorcentaje);
                cmd.Parameters.AddWithValue("@SubTotal", objVenta.fSubTotal);
                cmd.Parameters.AddWithValue("@Igv", objVenta.fIgv);
                cmd.Parameters.AddWithValue("@Total", objVenta.fTotal);
                cmd.Parameters.AddWithValue("@IdProveedor", objVenta.nIdProveedor);
                cmd.Parameters.AddWithValue("@Nombre", objVenta.sNombre);
                cmd.Parameters.AddWithValue("@Codigo", objVenta.nCodigo);
                cmd.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objVenta.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Salida objVent = new Salida();
                    
                    if (objVenta.nTipo == 7)
                    {
                        objVent.dFecha = Convert.ToDateTime(dr[0].ToString());
                        objVent.fTotal = Convert.ToDecimal(dr[1]);
                        objVent.fDescuento = Convert.ToInt32(dr[2]);
                    }
                    else if (objVenta.nTipo == 8)
                    {
                        objVent.nIdVenta = int.Parse(dr[0].ToString());
                        objVent.dFecha =Convert.ToDateTime(dr[1].ToString());
                        objVent.sSerie = dr[2].ToString();
                        objVent.sIdDocumento= dr[3].ToString();
                        objVent.nNumero = Convert.ToInt32(dr[4]);
                        objVent.fTotal =                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           Convert.ToDecimal(dr[5]);
                        objVent.sNombre= dr[6].ToString();
                        objVent.sProducto= dr[7].ToString();
                        objVent.fPrecioVenta= Convert.ToDecimal(dr[8]);
                        objVent.nCodigo =Convert.ToInt32(dr[9]);
                        objVent.sIdVendedor =dr[10].ToString();
                        objVent.dFechaRegistrado= Convert.ToDateTime(dr[11].ToString());
                        objVent.fDescuento = Convert.ToDecimal(dr[12].ToString());
                    }
                    else if (objVenta.nTipo == 9)
                    {
                        objVent.nIdVenta = int.Parse(dr[0].ToString());
                        objVent.dFecha = Convert.ToDateTime(dr[1].ToString());
                        objVent.sProducto = dr[2].ToString();
                        //Lote
                        objVent.sIdDocumento = dr[3].ToString();
                        //Cantidad
                        objVent.nNumero = Convert.ToInt32(dr[4]);
                        objVent.fPrecioVenta = Convert.ToDecimal(dr[5]);
                        objVent.fSubTotal= Convert.ToDecimal(dr[6]);
                        objVent.fDescuento = Convert.ToDecimal(dr[7]);
                        objVent.fTotal = Convert.ToDecimal(dr[8]);
                  
                   }
                    else if (objVenta.nTipo == 10)
                    {
                        objVent.nIdVenta = int.Parse(dr[0].ToString());
                        objVent.sNombre = dr[1].ToString();
                        objVent.dFecha = Convert.ToDateTime(dr[2].ToString());
                        objVent.sIdDocumento = dr[3].ToString();
                        objVent.sIdCajero = dr[4].ToString();
                        objVent.sProducto = dr[5].ToString();
                        objVent.nCodigo = Convert.ToInt32(dr[6]);
                        objVent.fPrecioVenta = Convert.ToDecimal(dr[7]);
                        objVent.fDescuento = Convert.ToDecimal(dr[8].ToString());
                    }
                    else if (objVenta.nTipo == 2)
                    {
                        objVent.nIdVenta = int.Parse(dr[0].ToString());
                        objVent.nIdAlmacen = int.Parse(dr[1].ToString());
                        objVent.sIdDocumento = dr[2].ToString();
                        objVent.sSerie = dr[3].ToString();
                        objVent.nIdProveedor = Convert.ToInt32(dr[4]);
                        objVent.sNombre = dr[5].ToString();
                        objVent.dFecha = Convert.ToDateTime(dr[6].ToString());
                        objVent.fTotal = Convert.ToDecimal(dr[7]);
                        objVent.bEstado = Convert.ToBoolean(dr[8]);
                        if(DBNull.Value== dr[9]) objVent.nNumero = null;
                        else objVent.nNumero = Convert.ToInt32(dr[9]);

                    }
                    else if (objVenta.nTipo == 3)
                    {
                        SalidaDetalle objVentaDetalle = new SalidaDetalle();

                        objVentaDetalle.nIdVentaDetalle = int.Parse(dr[0].ToString());
                        objVent.nIdVenta = int.Parse(dr[1].ToString());
                        objVent.nIdTarjeta = int.Parse(dr[2].ToString());
                        objVent.nIdProducto = int.Parse(dr[3].ToString());
                        objVent.sProducto = dr[4].ToString();
                        objVentaDetalle.sLote = dr[5].ToString();
                        objVentaDetalle.nCantidad = int.Parse(dr[6].ToString());
                        objVentaDetalle.fPrecioVenta = decimal.Parse(dr[7].ToString());
                        objVentaDetalle.fSubTotal = decimal.Parse(dr[8].ToString());
                        objVentaDetalle.fDescuento = decimal.Parse(dr[9].ToString());
                        objVent.fTotal = Convert.ToDecimal(dr[10]);
                        objVent.listSalidaDetalle.Add(objVentaDetalle);
                    }
                    else
                    {
                        objVent.nIdProducto = int.Parse(dr[0].ToString());
                        objVent.sNombre = dr[1].ToString();
                        objVent.bAlternativo = Convert.ToBoolean(dr[2]);
                        objVent.sLaboratorio = dr[3].ToString();
                        objVent.fTotal = Convert.ToDecimal(dr[4]);
                    }

                    listSalida.Add(objVent);

                }
                return listSalida;
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

        public static int ActualizaSalida(Salida objVenta)
        {
            int respuesta = 0;

            SqlCommand cmd = null;
            SqlCommand cmdDocumento = null;
            SqlCommand cmdHistorial = null;
            SqlCommand cmdTarjeta = null;
            SqlCommand cmdDetalle = null;

            Conexion cn = new Conexion();
            SqlTransaction xTrans;
            SqlConnection cnx = cn.getConecta();
            cnx.Open();
            xTrans = cnx.BeginTransaction();

            try
            {
                cmd = new SqlCommand("IAE_Salida", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tipo", objVenta.nTipo);
                cmd.Parameters.AddWithValue("@IdSalida", objVenta.nIdVenta);
                cmd.Parameters.AddWithValue("@IdAlmacen", objVenta.nIdAlmacen);
                if (objVenta.nIdPedido == 0) cmd.Parameters.AddWithValue("@IdPedido", DBNull.Value);
                else cmd.Parameters.AddWithValue("@IdPedido", objVenta.nIdPedido);
                cmd.Parameters.AddWithValue("@IdProveedor", objVenta.nIdProveedor);
                cmd.Parameters.AddWithValue("@Nombre", objVenta.sNombre);
                cmd.Parameters.AddWithValue("@IdDocumento", objVenta.sIdDocumento);
                cmd.Parameters.AddWithValue("@Serie", objVenta.sSerie);
                cmd.Parameters.AddWithValue("@Numero", objVenta.nNumero);
                cmd.Parameters.AddWithValue("@Fecha", objVenta.dFecha);
                cmd.Parameters.AddWithValue("@Porcentaje", objVenta.nPorcentaje);
                cmd.Parameters.AddWithValue("@SubTotal", objVenta.fSubTotal);
                cmd.Parameters.AddWithValue("@Igv", objVenta.fIgv);
                cmd.Parameters.AddWithValue("@Total", objVenta.fTotal);

                SqlParameter paramResultado = new SqlParameter("@Codigo", SqlDbType.Int);
                paramResultado.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramResultado);

                cmd.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objVenta.bEstado);
                cmd.Transaction = xTrans;

                respuesta = cmd.ExecuteNonQuery();
                objVenta.nCodigo = (int)paramResultado.Value;
                if (respuesta <= 0)
                {
                    xTrans.Rollback();
                    return respuesta;
                }

                respuesta = 0;
                cmdDocumento = new SqlCommand("IAE_DocumentoSerie", cnx);
                cmdDocumento.Parameters.AddWithValue("@Tipo", 6);
                cmdDocumento.Parameters.AddWithValue("@IdDocumentoSerie", 0);
                cmdDocumento.Parameters.AddWithValue("@IdDocumento", objVenta.sIdDocumento);
                cmdDocumento.Parameters.AddWithValue("@Serie", objVenta.sSerie);
                cmdDocumento.Parameters.AddWithValue("@Ultimo", 0);
                cmdDocumento.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                cmdDocumento.Parameters.AddWithValue("@Estado", objVenta.bEstado);
                cmdDocumento.CommandType = CommandType.StoredProcedure;
                cmdDocumento.Transaction = xTrans;
                respuesta = cmdDocumento.ExecuteNonQuery();

                if (respuesta <= 0)
                {
                    xTrans.Rollback();
                    return respuesta;
                }

                int contador = 1;

                foreach (SalidaDetalle item in objVenta.listSalidaDetalle)
                {
                    respuesta = 0;

                    cmdHistorial = new SqlCommand("IAE_HistorialProducto", cnx);
                    cmdHistorial.Parameters.AddWithValue("@Tipo", 4);
                    cmdHistorial.Parameters.AddWithValue("@IdHistorial", item.nIdMovimiento);
                    cmdHistorial.Parameters.AddWithValue("@IdProducto", item.nIdProducto);
                    cmdHistorial.Parameters.AddWithValue("@IdAlmacen", objVenta.nIdAlmacen);
                    cmdHistorial.Parameters.AddWithValue("@Lote", item.sLote);
                    cmdHistorial.Parameters.AddWithValue("@IdLote", item.sLote);
                    cmdHistorial.Parameters.AddWithValue("@PrecioCompra", item.fPrecioCompra);
                    cmdHistorial.Parameters.AddWithValue("@Ganancia", item.fGanancia);
                    cmdHistorial.Parameters.AddWithValue("@PrecioVenta", item.fPrecioVenta);
                    cmdHistorial.Parameters.AddWithValue("@Stock", item.nCantidad);
                    cmdHistorial.Parameters.AddWithValue("@Vencimiento", item.dFechaVencimiento);

                    SqlParameter paramResultado1 = new SqlParameter("@Codigo", SqlDbType.Int);
                    paramResultado1.Direction = ParameterDirection.Output;
                    cmdHistorial.Parameters.Add(paramResultado1);

                    cmdHistorial.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                    cmdHistorial.Parameters.AddWithValue("@Estado", objVenta.bEstado);

                    cmdHistorial.CommandType = CommandType.StoredProcedure;
                    cmdHistorial.Transaction = xTrans;
                    respuesta = cmdHistorial.ExecuteNonQuery();
                    objVenta.nIdHistorial = (int)paramResultado1.Value;

                    if (respuesta <= 0)
                    {
                        xTrans.Rollback();
                        break;
                    }

                    respuesta = 0;
                    cmdTarjeta = new SqlCommand("IAE_Tarjeta", cnx);
                    cmdTarjeta.Parameters.AddWithValue("@Tipo", 3);
                    cmdTarjeta.Parameters.AddWithValue("@IdTarjeta", 0);
                    cmdTarjeta.Parameters.AddWithValue("@Fecha", objVenta.dFecha);
                    cmdTarjeta.Parameters.AddWithValue("@IdAlmacen", objVenta.nIdAlmacen);
                    cmdTarjeta.Parameters.AddWithValue("@IdHistorial", objVenta.nIdHistorial);
                    cmdTarjeta.Parameters.AddWithValue("@TipoMovimiento", 2);
                    cmdTarjeta.Parameters.AddWithValue("@IdReferencia", objVenta.nCodigo);
                    cmdTarjeta.Parameters.AddWithValue("@Lote", item.sLote);

                    cmdTarjeta.Parameters.AddWithValue("@Vencimiento", item.dFechaVencimiento);
                    cmdTarjeta.Parameters.AddWithValue("@IdDocumento", objVenta.sIdDocumento);
                    cmdTarjeta.Parameters.AddWithValue("@Serie", objVenta.sSerie);

                    cmdTarjeta.Parameters.AddWithValue("@Numero", objVenta.nNumero);
                    cmdTarjeta.Parameters.AddWithValue("@IdProducto", item.nIdProducto);
                    cmdTarjeta.Parameters.AddWithValue("@Entrada", 0);

                    cmdTarjeta.Parameters.AddWithValue("@Salida", item.nCantidad);
                    cmdTarjeta.Parameters.AddWithValue("@Existencia", 0);
                    cmdTarjeta.Parameters.AddWithValue("@PrecioCompra", item.fPrecioCompra);

                    cmdTarjeta.Parameters.AddWithValue("@PrecioVenta", item.fPrecioVenta);
                    cmdTarjeta.Parameters.AddWithValue("@Debe", 0);
                    cmdTarjeta.Parameters.AddWithValue("@Haber", item.fSubTotal);

                    cmdTarjeta.Parameters.AddWithValue("@Saldo", 0);

                    SqlParameter paramResultado2 = new SqlParameter("@Codigo", SqlDbType.Int);
                    paramResultado2.Direction = ParameterDirection.Output;
                    cmdTarjeta.Parameters.Add(paramResultado2);

                    cmdTarjeta.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                    cmdTarjeta.Parameters.AddWithValue("@Estado", objVenta.bEstado);

                    cmdTarjeta.CommandType = CommandType.StoredProcedure;
                    cmdTarjeta.Transaction = xTrans;
                    respuesta = cmdTarjeta.ExecuteNonQuery();
                    objVenta.nIdTarjeta = (int)paramResultado2.Value;

                    if (respuesta <= 0)
                    {
                        xTrans.Rollback();
                        break;
                    }

                    respuesta = 0;
                    cmdDetalle = new SqlCommand("IAE_DetalleSalida", cnx);
                    cmdDetalle.Parameters.AddWithValue("@Tipo", objVenta.nTipo);
                    cmdDetalle.Parameters.AddWithValue("@IdDetalleSalida", 0);
                    cmdDetalle.Parameters.AddWithValue("@IdSalida", objVenta.nCodigo);
                    cmdDetalle.Parameters.AddWithValue("@IdTarjeta", objVenta.nIdTarjeta);
                    cmdDetalle.Parameters.AddWithValue("@IdProducto", item.nIdProducto);
                    cmdDetalle.Parameters.AddWithValue("@Cantidad", item.nCantidad);
                    cmdDetalle.Parameters.AddWithValue("@Precio", item.fPrecioVenta);
                    cmdDetalle.Parameters.AddWithValue("@Ganancia", item.fGanancia);
                    cmdDetalle.Parameters.AddWithValue("@Lote", item.sLote);
                    cmdDetalle.Parameters.AddWithValue("@Descuento", item.fDescuento);
                    cmdDetalle.Parameters.AddWithValue("@Total", objVenta.fTotal);
                    cmdDetalle.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                    cmdDetalle.Parameters.AddWithValue("@Estado", objVenta.bEstado);

                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Transaction = xTrans;
                    respuesta = cmdDetalle.ExecuteNonQuery();

                    if (respuesta <= 0)
                    {
                        xTrans.Rollback();
                        break;
                    }

                    contador++;
                }

                if (respuesta > 0)
                {
                    respuesta = objVenta.nCodigo;
                    xTrans.Commit();
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

        public static int ActualizaIngreso(Salida objVenta)
        {
            int respuesta = 0;

            SqlCommand cmd = null;
            SqlCommand cmdDocumento = null;
            SqlCommand cmdHistorial = null;
            SqlCommand cmdTarjeta = null;
            SqlCommand cmdDetalle = null;

            Conexion cn = new Conexion();
            SqlTransaction xTrans;
            SqlConnection cnx = cn.getConecta();
            cnx.Open();
            xTrans = cnx.BeginTransaction();

            try
            {
                cmd = new SqlCommand("IAE_Salida", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tipo", objVenta.nTipo);
                cmd.Parameters.AddWithValue("@IdSalida", objVenta.nIdVenta);
                cmd.Parameters.AddWithValue("@IdAlmacen", objVenta.nIdAlmacen);
                if (objVenta.nIdPedido == 0) cmd.Parameters.AddWithValue("@IdPedido", DBNull.Value);
                else cmd.Parameters.AddWithValue("@IdPedido", objVenta.nIdPedido);
                cmd.Parameters.AddWithValue("@IdProveedor", objVenta.nIdProveedor);
                cmd.Parameters.AddWithValue("@Nombre", objVenta.sNombre);
                cmd.Parameters.AddWithValue("@IdDocumento", objVenta.sIdDocumento);
                cmd.Parameters.AddWithValue("@Serie", objVenta.sSerie);
                cmd.Parameters.AddWithValue("@Numero", objVenta.nNumero);
                cmd.Parameters.AddWithValue("@Fecha", objVenta.dFecha);
                cmd.Parameters.AddWithValue("@Porcentaje", objVenta.nPorcentaje);
                cmd.Parameters.AddWithValue("@SubTotal", objVenta.fSubTotal);
                cmd.Parameters.AddWithValue("@Igv", objVenta.fIgv);
                cmd.Parameters.AddWithValue("@Total", objVenta.fTotal);

                SqlParameter paramResultado = new SqlParameter("@Codigo", SqlDbType.Int);
                paramResultado.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramResultado);

                cmd.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objVenta.bEstado);
                cmd.Transaction = xTrans;

                respuesta = cmd.ExecuteNonQuery();
                objVenta.nCodigo = (int)paramResultado.Value;
                if (respuesta <= 0)
                {
                    xTrans.Rollback();
                    return respuesta;
                }

                respuesta = 0;
                cmdDocumento = new SqlCommand("IAE_DocumentoSerie", cnx);
                cmdDocumento.Parameters.AddWithValue("@Tipo", 6);
                cmdDocumento.Parameters.AddWithValue("@IdDocumentoSerie", 0);
                cmdDocumento.Parameters.AddWithValue("@IdDocumento", objVenta.sIdDocumento);
                cmdDocumento.Parameters.AddWithValue("@Serie", objVenta.sSerie);
                cmdDocumento.Parameters.AddWithValue("@Ultimo", 0);
                cmdDocumento.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                cmdDocumento.Parameters.AddWithValue("@Estado", objVenta.bEstado);
                cmdDocumento.CommandType = CommandType.StoredProcedure;
                cmdDocumento.Transaction = xTrans;
                respuesta = cmdDocumento.ExecuteNonQuery();

                if (respuesta <= 0)
                {
                    xTrans.Rollback();
                    return respuesta;
                }

                int contador = 1;

                foreach (SalidaDetalle item in objVenta.listSalidaDetalle)
                {
                    respuesta = 0;

                    cmdHistorial = new SqlCommand("IAE_HistorialProducto", cnx);
                    cmdHistorial.Parameters.AddWithValue("@Tipo", 3);
                    cmdHistorial.Parameters.AddWithValue("@IdHistorial", item.nIdMovimiento);
                    cmdHistorial.Parameters.AddWithValue("@IdProducto", item.nIdProducto);
                    cmdHistorial.Parameters.AddWithValue("@IdAlmacen", objVenta.nIdAlmacen);
                    cmdHistorial.Parameters.AddWithValue("@Lote", item.sLote);
                    cmdHistorial.Parameters.AddWithValue("@IdLote", item.sLote);
                    cmdHistorial.Parameters.AddWithValue("@PrecioCompra", item.fPrecioCompra);
                    cmdHistorial.Parameters.AddWithValue("@Ganancia", item.fGanancia);
                    cmdHistorial.Parameters.AddWithValue("@PrecioVenta", item.fPrecioVenta);
                    cmdHistorial.Parameters.AddWithValue("@Stock", item.nCantidad);
                    cmdHistorial.Parameters.AddWithValue("@Vencimiento", item.dFechaVencimiento);

                    SqlParameter paramResultado1 = new SqlParameter("@Codigo", SqlDbType.Int);
                    paramResultado1.Direction = ParameterDirection.Output;
                    cmdHistorial.Parameters.Add(paramResultado1);

                    cmdHistorial.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                    cmdHistorial.Parameters.AddWithValue("@Estado", objVenta.bEstado);

                    cmdHistorial.CommandType = CommandType.StoredProcedure;
                    cmdHistorial.Transaction = xTrans;
                    respuesta = cmdHistorial.ExecuteNonQuery();
                    objVenta.nIdHistorial = (int)paramResultado1.Value;

                    if (respuesta <= 0)
                    {
                        xTrans.Rollback();
                        break;
                    }

                    respuesta = 0;
                    cmdTarjeta = new SqlCommand("IAE_Tarjeta", cnx);
                    cmdTarjeta.Parameters.AddWithValue("@Tipo", 2);
                    cmdTarjeta.Parameters.AddWithValue("@IdTarjeta", 0);
                    cmdTarjeta.Parameters.AddWithValue("@Fecha", objVenta.dFecha);
                    cmdTarjeta.Parameters.AddWithValue("@IdAlmacen", objVenta.nIdAlmacen);
                    cmdTarjeta.Parameters.AddWithValue("@IdHistorial", objVenta.nIdHistorial);
                    cmdTarjeta.Parameters.AddWithValue("@TipoMovimiento", 1);
                    cmdTarjeta.Parameters.AddWithValue("@IdReferencia", objVenta.nCodigo);
                    cmdTarjeta.Parameters.AddWithValue("@Lote", item.sLote);

                    cmdTarjeta.Parameters.AddWithValue("@Vencimiento", item.dFechaVencimiento);
                    cmdTarjeta.Parameters.AddWithValue("@IdDocumento", objVenta.sIdDocumento);
                    cmdTarjeta.Parameters.AddWithValue("@Serie", objVenta.sSerie);

                    cmdTarjeta.Parameters.AddWithValue("@Numero", objVenta.nNumero);
                    cmdTarjeta.Parameters.AddWithValue("@IdProducto", item.nIdProducto);
                    cmdTarjeta.Parameters.AddWithValue("@Entrada", item.nCantidad);

                    cmdTarjeta.Parameters.AddWithValue("@Salida", 0);
                    cmdTarjeta.Parameters.AddWithValue("@Existencia", 0);
                    cmdTarjeta.Parameters.AddWithValue("@PrecioCompra", item.fPrecioCompra);

                    cmdTarjeta.Parameters.AddWithValue("@PrecioVenta", item.fPrecioVenta);
                    cmdTarjeta.Parameters.AddWithValue("@Debe", 0);
                    cmdTarjeta.Parameters.AddWithValue("@Haber",0);

                    cmdTarjeta.Parameters.AddWithValue("@Saldo", 0);

                    SqlParameter paramResultado2 = new SqlParameter("@Codigo", SqlDbType.Int);
                    paramResultado2.Direction = ParameterDirection.Output;
                    cmdTarjeta.Parameters.Add(paramResultado2);

                    cmdTarjeta.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                    cmdTarjeta.Parameters.AddWithValue("@Estado", objVenta.bEstado);

                    cmdTarjeta.CommandType = CommandType.StoredProcedure;
                    cmdTarjeta.Transaction = xTrans;
                    respuesta = cmdTarjeta.ExecuteNonQuery();
                    objVenta.nIdTarjeta = (int)paramResultado2.Value;

                    if (respuesta <= 0)
                    {
                        xTrans.Rollback();
                        break;
                    }

                    respuesta = 0;
                    cmdDetalle = new SqlCommand("IAE_DetalleSalida", cnx);
                    cmdDetalle.Parameters.AddWithValue("@Tipo", objVenta.nTipo);
                    cmdDetalle.Parameters.AddWithValue("@IdDetalleSalida", 0);
                    cmdDetalle.Parameters.AddWithValue("@IdSalida", objVenta.nCodigo);
                    cmdDetalle.Parameters.AddWithValue("@IdTarjeta", objVenta.nIdTarjeta);
                    cmdDetalle.Parameters.AddWithValue("@IdProducto", item.nIdProducto);
                    cmdDetalle.Parameters.AddWithValue("@Cantidad", item.nCantidad);
                    cmdDetalle.Parameters.AddWithValue("@Precio", item.fPrecioVenta);
                    cmdDetalle.Parameters.AddWithValue("@Ganancia", item.fGanancia);
                    cmdDetalle.Parameters.AddWithValue("@Lote", item.sLote);
                    cmdDetalle.Parameters.AddWithValue("@Descuento", item.fDescuento);
                    cmdDetalle.Parameters.AddWithValue("@Total", objVenta.fTotal);
                    cmdDetalle.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                    cmdDetalle.Parameters.AddWithValue("@Estado", objVenta.bEstado);

                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Transaction = xTrans;
                    respuesta = cmdDetalle.ExecuteNonQuery();

                    if (respuesta <= 0)
                    {
                        xTrans.Rollback();
                        break;
                    }

                    contador++;
                }

                if (respuesta > 0)
                {
                    respuesta = objVenta.nCodigo;
                    xTrans.Commit();
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
