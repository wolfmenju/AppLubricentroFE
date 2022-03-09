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
    public class VentaData
    {
        //Listar Varios
        public static List<Venta> ListarVentas(Venta objVenta)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Venta> listVenta = new List<Venta>();
            SqlConnection cnx = null;
            try
            {
                Conexion cn = new Conexion();
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Venta", cnx);
                cmd.Parameters.AddWithValue("@Tipo", objVenta.nTipo);
                cmd.Parameters.AddWithValue("@IdVenta", objVenta.nIdVenta);
                cmd.Parameters.AddWithValue("@IdAlmacen", objVenta.nIdAlmacen);
                cmd.Parameters.AddWithValue("@IdPedido", objVenta.nIdPedido);
                cmd.Parameters.AddWithValue("@IdDocumento", objVenta.sIdDocumento);
                cmd.Parameters.AddWithValue("@Serie", objVenta.sSerie);
                cmd.Parameters.AddWithValue("@Numero", objVenta.nNumero);
                cmd.Parameters.AddWithValue("@Fecha", objVenta.dFecha);
                cmd.Parameters.AddWithValue("@Porcentaje", objVenta.fPorcentajeIgv);
                cmd.Parameters.AddWithValue("@SubTotal", objVenta.fSubTotal);
                cmd.Parameters.AddWithValue("@Igv", objVenta.fIgv);
                cmd.Parameters.AddWithValue("@Total", objVenta.fTotal);
                cmd.Parameters.AddWithValue("@IdCliente", objVenta.nIdCliente);
                cmd.Parameters.AddWithValue("@Nombre", objVenta.sNombre);
                cmd.Parameters.AddWithValue("@IdVendedor", objVenta.sIdVendedor);
                cmd.Parameters.AddWithValue("@IdCajero", objVenta.sIdCajero);
                cmd.Parameters.AddWithValue("@Codigo", objVenta.nCodigo);
                cmd.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                cmd.Parameters.AddWithValue("@DocAnulacion", objVenta.sDocumentoAnulacion);
                cmd.Parameters.AddWithValue("@Estado", objVenta.bEstado);
                cmd.Parameters.AddWithValue("@IgvAplica", objVenta.bIgvAplica);

                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Venta objVent = new Venta();
                    
                    if (objVenta.nTipo == 7)
                    {
                        objVent.dFecha = Convert.ToDateTime(dr[0].ToString());
                        objVent.fTotal = Convert.ToDecimal(dr[1]);
                        objVent.fDescuento = Convert.ToDecimal(dr[2]);
                    }
                    else if (objVenta.nTipo == 8)
                    {
                        objVent.nIdVenta = int.Parse(dr[0].ToString());
                        objVent.dFecha =Convert.ToDateTime(dr[1].ToString());
                        objVent.sSerie = dr[2].ToString();
                        objVent.sIdDocumento = dr[3].ToString();
                        objVent.sDescripDocumento= dr[4].ToString();
                        objVent.nNumero = Convert.ToInt32(dr[5]);
                        objVent.nIdCliente = Convert.ToInt32(dr[6]);
                        objVent.fTotal = Convert.ToDecimal(dr[7]);
                        objVent.fPorcentajeIgv= Convert.ToDecimal(dr[8]);
                        objVent.fSubTotal = Convert.ToDecimal(dr[9]);
                        objVent.fIgv = Convert.ToDecimal(dr[10]);
                        objVent.fIgvDetalle = Convert.ToDecimal(dr[11]);
                        objVent.sNombre= dr[12].ToString();
                        objVent.sCodigoInterno = dr[13].ToString();
                        objVent.sProducto= dr[14].ToString();
                        objVent.fPrecioVenta= Convert.ToDecimal(dr[15]);
                        objVent.nCodigo =Convert.ToInt32(dr[16]);
                        objVent.sIdVendedor =dr[17].ToString();
                        objVent.dFechaRegistrado= Convert.ToDateTime(dr[18].ToString());
                        objVent.fDescuento = Convert.ToDecimal(dr[19].ToString());
                        objVent.bIgvAplica = Convert.ToBoolean(dr[20]);
                        objVent.sDocumentoAnulacion = dr[21].ToString();
                        objVent.sCdr =dr[22].ToString();
                        objVent.sHash = dr[23].ToString();
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
                        objVent.sCodigoInterno = dr[5].ToString();
                        objVent.sProducto = dr[6].ToString();
                        objVent.nCodigo = Convert.ToInt32(dr[7]);
                        objVent.fPrecioVenta = Convert.ToDecimal(dr[8]);
                        objVent.fDescuento = Convert.ToDecimal(dr[9].ToString());
                        objVent.fIgv = Convert.ToDecimal(dr[10].ToString());
                    }
                    else if (objVenta.nTipo == 11)
                    {
                        objVent.nCodigo = Convert.ToInt32(dr[0].ToString());
                        objVent.fTotal= Convert.ToDecimal(dr[1].ToString());

                    }
                    else if (objVenta.nTipo == 12)
                    {
                        objVent.sProducto =dr[0].ToString()+"-"+ dr[1].ToString();
                        objVent.fTotal = Convert.ToDecimal(dr[2].ToString());

                    }
                    else if (objVenta.nTipo == 2)
                    {
                        objVent.nIdVenta = int.Parse(dr[0].ToString());
                        objVent.nIdAlmacen = int.Parse(dr[1].ToString());
                        objVent.sIdDocumento = dr[2].ToString();
                        objVent.sDescripDocumento = dr[3].ToString();
                        objVent.sSerie = dr[4].ToString();
                        objVent.nIdCliente = Convert.ToInt32(dr[5]);
                        objVent.sNombre = dr[6].ToString();
                        objVent.dFecha = Convert.ToDateTime(dr[7].ToString());
                        objVent.fTotal = Convert.ToDecimal(dr[8]);
                        objVent.bEstado = Convert.ToBoolean(dr[9]);
                        objVent.sEstado = dr[10].ToString();
                        if (DBNull.Value== dr[11]) objVent.nNumero = null;
                        else objVent.nNumero = Convert.ToInt32(dr[11]);
                        objVent.bSunat = Convert.ToInt32(dr[12]);
                        objVent.sSunat = Convert.ToString(dr[13]);
                        objVent.sDocumentoAnulacion = dr[14].ToString();
                        if (DBNull.Value == dr[15]) objVent.dFechaNotificacionSunat = null;
                        else objVent.dFechaNotificacionSunat = Convert.ToDateTime(dr[15]);
                        if (DBNull.Value == dr[16]) objVent.FechaAnuladoSunat = null;
                        else objVent.FechaAnuladoSunat = Convert.ToDateTime(dr[16]);

                    }
                    else if (objVenta.nTipo == 3)
                    {
                        VentaDetalle objVentaDetalle = new VentaDetalle();

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
                        objVent.listVentaDetalle.Add(objVentaDetalle);
                    }
                    else
                    {
                        objVent.nIdProducto = int.Parse(dr[0].ToString());
                        objVent.sCodigoInterno = dr[1].ToString();
                        objVent.sNombre = dr[2].ToString();
                        objVent.bAlternativo = Convert.ToBoolean(dr[3]);
                        objVent.sLaboratorio = dr[4].ToString();
                        objVent.fTotal = Convert.ToDecimal(dr[5]);
                    }
                    
                    listVenta.Add(objVent);

                }
                return listVenta;
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

        public static int RegistrarVenta(Venta objVenta)
        {
            int respuesta = 0;

            SqlCommand cmd = null;
            SqlCommand cmdDocumento = null;
            SqlCommand cmdCaja = null;
            SqlCommand cmdPedido = null;

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
                cmd = new SqlCommand("IAE_Venta", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tipo", objVenta.nTipo);
                cmd.Parameters.AddWithValue("@IdVenta", objVenta.nIdVenta);
                cmd.Parameters.AddWithValue("@IdAlmacen", objVenta.nIdAlmacen);
                if (objVenta.nIdPedido == 0) cmd.Parameters.AddWithValue("@IdPedido", DBNull.Value);
                else cmd.Parameters.AddWithValue("@IdPedido", objVenta.nIdPedido);
                cmd.Parameters.AddWithValue("@IdCliente", objVenta.nIdCliente);
                cmd.Parameters.AddWithValue("@Nombre", objVenta.sNombre);
                cmd.Parameters.AddWithValue("@IdDocumento", objVenta.sIdDocumento);
                cmd.Parameters.AddWithValue("@Serie", objVenta.sSerie);
                cmd.Parameters.AddWithValue("@Numero", objVenta.nNumero);
                cmd.Parameters.AddWithValue("@Fecha", objVenta.dFecha);
                cmd.Parameters.AddWithValue("@Porcentaje", objVenta.fPorcentajeIgv);
                cmd.Parameters.AddWithValue("@SubTotal", objVenta.fSubTotal);
                cmd.Parameters.AddWithValue("@Igv", objVenta.fIgv);
                cmd.Parameters.AddWithValue("@Total", objVenta.fTotal);
                cmd.Parameters.AddWithValue("@DocAnulacion", objVenta.sDocumentoAnulacion);
                cmd.Parameters.AddWithValue("@IdVendedor", objVenta.sIdVendedor);
                cmd.Parameters.AddWithValue("@IdCajero", objVenta.sIdCajero);
                cmd.Parameters.AddWithValue("@IgvAplica", objVenta.bIgvAplica);

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

                respuesta = 0;
                cmdCaja = new SqlCommand("IAE_Caja", cnx);
                cmdCaja.Parameters.AddWithValue("@Tipo", 4);
                cmdCaja.Parameters.AddWithValue("@IdTurno", 0);
                cmdCaja.Parameters.AddWithValue("@IdCaja", 0);
                cmdCaja.Parameters.AddWithValue("@FechaInicio", objVenta.dFecha);
                cmdCaja.Parameters.AddWithValue("@MontoInicio", 0.0);
                cmdCaja.Parameters.AddWithValue("@FechaFinal", DateTime.Now);
                cmdCaja.Parameters.AddWithValue("@MontoFinal", objVenta.fTotal);
                cmdCaja.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                cmdCaja.Parameters.AddWithValue("@Estado", objVenta.bEstado);
                cmdCaja.CommandType = CommandType.StoredProcedure;
                cmdCaja.Transaction = xTrans;
                respuesta = cmdCaja.ExecuteNonQuery();

                if (respuesta <= 0)
                {
                    xTrans.Rollback();
                    return respuesta;
                }

                if (objVenta.nIdPedido > 0)
                {
                    respuesta = 0;
                    cmdPedido = new SqlCommand("IAE_Pedido", cnx);
                    cmdPedido.Parameters.AddWithValue("@Tipo", 5);
                    cmdPedido.Parameters.AddWithValue("@IdPedido", objVenta.nIdPedido);
                    cmdPedido.Parameters.AddWithValue("@IdAlmacen", objVenta.nIdAlmacen);
                    cmdPedido.Parameters.AddWithValue("@Numero", objVenta.nNumero);
                    cmdPedido.Parameters.AddWithValue("@Fecha", objVenta.dFecha);
                    cmdPedido.Parameters.AddWithValue("@Porcentaje", objVenta.fPorcentajeIgv);
                    cmdPedido.Parameters.AddWithValue("@SubTotal", objVenta.fSubTotal);
                    cmdPedido.Parameters.AddWithValue("@Igv", objVenta.fIgv);
                    cmdPedido.Parameters.AddWithValue("@IdCliente", objVenta.nIdCliente);
                    cmdPedido.Parameters.AddWithValue("@Nombre", objVenta.sNombre);
                    cmdPedido.Parameters.AddWithValue("@Codigo", objVenta.nCodigo);
                    cmdPedido.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                    cmdPedido.Parameters.AddWithValue("@Estado", objVenta.bEstado);
                    cmdPedido.CommandType = CommandType.StoredProcedure;
                    cmdPedido.Transaction = xTrans;
                    respuesta = cmdPedido.ExecuteNonQuery();

                    if (respuesta <= 0)
                    {
                        xTrans.Rollback();
                        return respuesta;
                    }
                }

                int contador = 1;

                foreach (VentaDetalle item in objVenta.listVentaDetalle)
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
                    cmdDetalle = new SqlCommand("IAE_DetalleVenta", cnx);
                    cmdDetalle.Parameters.AddWithValue("@Tipo", objVenta.nTipo);
                    cmdDetalle.Parameters.AddWithValue("@IdDetalleVenta", 0);
                    cmdDetalle.Parameters.AddWithValue("@IdVenta", objVenta.nCodigo);
                    cmdDetalle.Parameters.AddWithValue("@IdTarjeta", objVenta.nIdTarjeta);
                    cmdDetalle.Parameters.AddWithValue("@IdProducto", item.nIdProducto);
                    cmdDetalle.Parameters.AddWithValue("@Cantidad", item.nCantidad);
                    cmdDetalle.Parameters.AddWithValue("@Precio", item.fPrecioVenta);
                    cmdDetalle.Parameters.AddWithValue("@Ganancia", item.fGanancia);
                    cmdDetalle.Parameters.AddWithValue("@Lote", item.sLote);
                    cmdDetalle.Parameters.AddWithValue("@IgvDetalle", item.fIgvDetalle);
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
                    cmd = null;
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

        public static int AnularVenta(Venta objVenta)
        {
            int respuesta = 0;

            SqlCommand cmd = null;
            SqlCommand cmdCaja = null;

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
                cmd = new SqlCommand("IAE_Venta", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tipo", 4);
                cmd.Parameters.AddWithValue("@IdVenta", objVenta.nIdVenta);
                cmd.Parameters.AddWithValue("@IdAlmacen", objVenta.nIdAlmacen);
                if (objVenta.nIdPedido == 0) cmd.Parameters.AddWithValue("@IdPedido", DBNull.Value);
                else cmd.Parameters.AddWithValue("@IdPedido", objVenta.nIdPedido);
                cmd.Parameters.AddWithValue("@IdCliente", objVenta.nIdCliente);
                cmd.Parameters.AddWithValue("@Nombre", objVenta.sNombre);
                cmd.Parameters.AddWithValue("@IdDocumento", objVenta.sIdDocumento);
                cmd.Parameters.AddWithValue("@Serie", objVenta.sSerie);
                cmd.Parameters.AddWithValue("@Numero", objVenta.nNumero);
                cmd.Parameters.AddWithValue("@Fecha", objVenta.dFecha);
                cmd.Parameters.AddWithValue("@Codigo", objVenta.nCodigo);
                cmd.Parameters.AddWithValue("@Porcentaje", objVenta.fPorcentajeIgv);
                cmd.Parameters.AddWithValue("@SubTotal", objVenta.fSubTotal);
                cmd.Parameters.AddWithValue("@Igv", objVenta.fIgv);
                cmd.Parameters.AddWithValue("@Total", objVenta.fTotal);
                cmd.Parameters.AddWithValue("@IdVendedor", objVenta.sIdVendedor);
                cmd.Parameters.AddWithValue("@IdCajero", objVenta.sIdCajero);
                cmd.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                cmd.Parameters.AddWithValue("@DocAnulacion", objVenta.sDocumentoAnulacion);
                cmd.Parameters.AddWithValue("@Estado", objVenta.bEstado);
                cmd.Parameters.AddWithValue("@IgvAplica", objVenta.bIgvAplica);

                cmd.Transaction = xTrans;

                respuesta = cmd.ExecuteNonQuery();
                if (respuesta <= 0)
                {
                    xTrans.Rollback();
                    return respuesta;
                }

                respuesta = 0;
                cmdCaja = new SqlCommand("IAE_Caja", cnx);
                cmdCaja.Parameters.AddWithValue("@Tipo", 3);
                cmdCaja.Parameters.AddWithValue("@IdTurno", 0);
                cmdCaja.Parameters.AddWithValue("@IdCaja", 0);
                cmdCaja.Parameters.AddWithValue("@FechaInicio", objVenta.dFecha);
                cmdCaja.Parameters.AddWithValue("@MontoInicio", 0.0);
                cmdCaja.Parameters.AddWithValue("@FechaFinal", DateTime.Now);
                cmdCaja.Parameters.AddWithValue("@MontoFinal", objVenta.fTotal);
                cmdCaja.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                cmdCaja.Parameters.AddWithValue("@Estado", objVenta.bEstado);
                cmdCaja.CommandType = CommandType.StoredProcedure;
                cmdCaja.Transaction = xTrans;
                respuesta = cmdCaja.ExecuteNonQuery();

                if (respuesta <= 0)
                {
                    xTrans.Rollback();
                    return respuesta;
                }

                foreach (VentaDetalle item in objVenta.listVentaDetalle)
                {
                    respuesta = 0;
                    cmdTarjeta = new SqlCommand("IAE_Tarjeta", cnx);
                    cmdTarjeta.Parameters.AddWithValue("@Tipo", 4);
                    cmdTarjeta.Parameters.AddWithValue("@IdTarjeta", item.nIdTarjeta);
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
                    cmdTarjeta.Parameters.AddWithValue("@Entrada", 0);

                    cmdTarjeta.Parameters.AddWithValue("@Salida",0);
                    cmdTarjeta.Parameters.AddWithValue("@Existencia", 0);
                    cmdTarjeta.Parameters.AddWithValue("@PrecioCompra", 0);

                    cmdTarjeta.Parameters.AddWithValue("@PrecioVenta",0);
                    cmdTarjeta.Parameters.AddWithValue("@Debe", 0);
                    cmdTarjeta.Parameters.AddWithValue("@Haber", 0);

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
                    cmdHistorial = new SqlCommand("IAE_HistorialProducto", cnx);
                    cmdHistorial.Parameters.AddWithValue("@Tipo", 6);
                    cmdHistorial.Parameters.AddWithValue("@IdHistorial", objVenta.nIdTarjeta);
                    cmdHistorial.Parameters.AddWithValue("@IdProducto", item.nIdProducto);
                    cmdHistorial.Parameters.AddWithValue("@IdAlmacen", objVenta.nIdAlmacen);
                    cmdHistorial.Parameters.AddWithValue("@Lote", item.sLote);
                    cmdHistorial.Parameters.AddWithValue("@IdLote", item.sLote);
                    cmdHistorial.Parameters.AddWithValue("@PrecioCompra", item.fPrecioCompra);
                    cmdHistorial.Parameters.AddWithValue("@Ganancia", item.fGanancia);
                    cmdHistorial.Parameters.AddWithValue("@PrecioVenta", item.fPrecioVenta);
                    cmdHistorial.Parameters.AddWithValue("@Stock", item.nCantidad);
                    cmdHistorial.Parameters.AddWithValue("@Vencimiento", item.dFechaVencimiento);

                    cmdHistorial.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                    cmdHistorial.Parameters.AddWithValue("@Estado", objVenta.bEstado);

                    cmdHistorial.CommandType = CommandType.StoredProcedure;
                    cmdHistorial.Transaction = xTrans;
                    respuesta = cmdHistorial.ExecuteNonQuery();

                    if (respuesta <= 0)
                    {
                        xTrans.Rollback();
                        break;
                    }
                    
                    respuesta = 0;
                    cmdDetalle = new SqlCommand("IAE_DetalleVenta", cnx);
                    cmdDetalle.Parameters.AddWithValue("@Tipo",2);
                    cmdDetalle.Parameters.AddWithValue("@IdDetalleVenta", item.nIdVentaDetalle);
                    cmdDetalle.Parameters.AddWithValue("@IdVenta", objVenta.nIdVenta);
                    cmdDetalle.Parameters.AddWithValue("@IdTarjeta", objVenta.nIdTarjeta);
                    cmdDetalle.Parameters.AddWithValue("@IdProducto", item.nIdProducto);
                    cmdDetalle.Parameters.AddWithValue("@Cantidad", item.nCantidad);
                    cmdDetalle.Parameters.AddWithValue("@Precio", item.fPrecioVenta);
                    cmdDetalle.Parameters.AddWithValue("@IgvDetalle", item.fIgvDetalle);
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
                }

                if (respuesta > 0)
                {
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

        public static int ActualizarVentaNotficacionSunat(Venta objVenta)
        {
            int respuesta = 0;
            

            SqlCommand cmd = null;
            SqlCommand cmdDocumento = null;

            Conexion cn = new Conexion();
            SqlTransaction xTrans;
            SqlConnection cnx = cn.getConecta();
            cnx.Open();
            xTrans = cnx.BeginTransaction();
            try
            {
                //cnx.Open();
                cmd = new SqlCommand("IAE_VentaFE", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tipo", objVenta.nTipo);
                cmd.Parameters.AddWithValue("@IdVenta", objVenta.nIdVenta);
                cmd.Parameters.AddWithValue("@Usuario", objVenta.sUsuario);
                cmd.Parameters.AddWithValue("@Cdr", objVenta.sCdr);
                cmd.Parameters.AddWithValue("@Hash", objVenta.sHash);
                cmd.Parameters.AddWithValue("@CodigoResp", objVenta.sCodigoResp);
                cmd.Parameters.AddWithValue("@Mensaje", objVenta.sMensajeResp);
                cmd.Transaction = xTrans;
                respuesta = cmd.ExecuteNonQuery();

                if (respuesta <= 0)
                {
                    xTrans.Rollback();
                }
                else
                {
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
                }

                if (respuesta > 0)
                {
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
