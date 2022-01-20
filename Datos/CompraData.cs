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
    public class CompraData
    {
        //Listar Varios
        public static List<Compra> ListarCompras(Compra objCompra)
        {

            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Compra> listCompra = new List<Compra>();
            SqlConnection cnx = null;
            try
            {
                Conexion cn = new Conexion();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Compra", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tipo", objCompra.nTipo);
                cmd.Parameters.AddWithValue("@IdCompra", objCompra.nIdCompra);
                cmd.Parameters.AddWithValue("@IdAlmacen", objCompra.nIdAlmacen);
                cmd.Parameters.AddWithValue("@IdDocumento", objCompra.sIdDocumento);
                cmd.Parameters.AddWithValue("@Serie", objCompra.sSerie);
                cmd.Parameters.AddWithValue("@Numero", objCompra.nNumero);
                cmd.Parameters.AddWithValue("@Fecha", objCompra.dFecha);
                cmd.Parameters.AddWithValue("@Porcentaje", objCompra.nPorcentaje);
                cmd.Parameters.AddWithValue("@Codigo", objCompra.nCodigo); 
                cmd.Parameters.AddWithValue("@SubTotal", objCompra.fSubTotal);
                cmd.Parameters.AddWithValue("@Igv", objCompra.fIgv);
                cmd.Parameters.AddWithValue("@Total", objCompra.fTotal);
                if (objCompra.nTipo == 5)
                {
                    if(objCompra.nIdProveedor==0) cmd.Parameters.AddWithValue("@IdProveedor", DBNull.Value);
                    else cmd.Parameters.AddWithValue("@IdProveedor", objCompra.nIdProveedor);

                    if (objCompra.nCodigo == 1) cmd.Parameters.AddWithValue("@Credito", DBNull.Value);
                    else cmd.Parameters.AddWithValue("@Credito", objCompra.bCredito);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IdProveedor", objCompra.nIdProveedor);
                    cmd.Parameters.AddWithValue("@Credito", objCompra.bCredito);
                }

                cmd.Parameters.AddWithValue("@Dias", objCompra.nDias);
                cmd.Parameters.AddWithValue("@Usuario", objCompra.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objCompra.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Compra objCom = new Compra();

                    if (objCompra.nTipo == 2 || objCompra.nTipo == 5)
                    {
                        objCom.nIdCompra = int.Parse(dr[0].ToString());
                        objCom.nIdAlmacen = Convert.ToInt32(dr[1].ToString());
                        objCom.nIdProveedor = Convert.ToInt32(dr[2].ToString());
                        if (objCompra.nTipo == 5)
                        {
                            objCom.sRuc = dr[3].ToString();
                            objCom.sRazonSocial = dr[4].ToString();
                            objCom.bCredito = Convert.ToBoolean(dr[5].ToString());
                            objCom.sIdDocumento = dr[6].ToString();
                            objCom.dFecha = Convert.ToDateTime(dr[7]);
                            objCom.fTotal = Convert.ToDecimal(dr[8]);
                            objCom.bEstado = Convert.ToInt32(dr[9].ToString()) == 1 ? true : false;
                        }
                        else
                        {
                            objCom.sRazonSocial = dr[3].ToString();
                            objCom.bCredito = Convert.ToBoolean(dr[4].ToString());
                            objCom.sIdDocumento = dr[5].ToString();
                            objCom.dFecha = Convert.ToDateTime(dr[6]);
                            objCom.fTotal = Convert.ToDecimal(dr[7]);
                            objCom.bEstado = Convert.ToInt32(dr[8].ToString()) == 1 ? true : false;
                        }
                    }

                    else if (objCompra.nTipo == 3)
                    {
                        CompraDetalle objCompraDetalle = new CompraDetalle();

                        objCompraDetalle.nIdCompraDetalle = int.Parse(dr[0].ToString());
                        objCom.nIdCompra = int.Parse(dr[1].ToString());
                        objCom.nIdTarjeta = int.Parse(dr[2].ToString());
                        objCompraDetalle.nIdProducto = int.Parse(dr[3].ToString());
                        objCom.sProducto= dr[4].ToString(); 
                        objCompraDetalle.sLote =dr[5].ToString();
                        objCompraDetalle.nCantidad = int.Parse(dr[6].ToString());
                        objCompraDetalle.fPrecioCompra = decimal.Parse(dr[7].ToString());
                        objCompraDetalle.fSubTotal = decimal.Parse(dr[8].ToString());
        
                        objCom.listCompraDetalle.Add(objCompraDetalle);

                    }

                    listCompra.Add(objCom);

                }
                return listCompra;
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
        public static int RegistrarCompra(Compra objCompra)
        {
            int respuesta = 0;
          
            SqlCommand cmd = null;
            SqlCommand cmdDeuda = null;
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
                cmd = new SqlCommand("IAE_Compra", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tipo", objCompra.nTipo);
                cmd.Parameters.AddWithValue("@IdCompra", objCompra.nIdCompra);
                cmd.Parameters.AddWithValue("@IdAlmacen", objCompra.nIdAlmacen);
                cmd.Parameters.AddWithValue("@IdDocumento", objCompra.sIdDocumento);
                cmd.Parameters.AddWithValue("@Serie", objCompra.sSerie);
                cmd.Parameters.AddWithValue("@Numero", objCompra.nNumero);
                cmd.Parameters.AddWithValue("@Fecha", objCompra.dFecha);
                cmd.Parameters.AddWithValue("@Porcentaje", objCompra.nPorcentaje);
                cmd.Parameters.AddWithValue("@SubTotal", objCompra.fSubTotal);
                cmd.Parameters.AddWithValue("@Igv", objCompra.fIgv);
                cmd.Parameters.AddWithValue("@Total", objCompra.fTotal);
                cmd.Parameters.AddWithValue("@IdProveedor", objCompra.nIdProveedor);
                cmd.Parameters.AddWithValue("@Credito", objCompra.bCredito);
                cmd.Parameters.AddWithValue("@Dias", objCompra.nDias);

                SqlParameter paramResultado = new SqlParameter("@Codigo", SqlDbType.Int);
                paramResultado.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramResultado);

                cmd.Parameters.AddWithValue("@Usuario", objCompra.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objCompra.bEstado);
                cmd.Transaction = xTrans;

                respuesta = cmd.ExecuteNonQuery();
                objCompra.nCodigo =(int)paramResultado.Value;
                if (respuesta <= 0)
                {
                    xTrans.Rollback();
                    return respuesta;
                }
                else
                {
                    if (objCompra.nDias > 0)
                    {
                        respuesta = 0;
                        cmdDeuda = new SqlCommand("IAE_Deuda", cnx);
                        cmdDeuda.Parameters.AddWithValue("@Tipo", objCompra.nTipo);
                        cmdDeuda.Parameters.AddWithValue("@IdDeuda", 0);
                        cmdDeuda.Parameters.AddWithValue("@Fecha", objCompra.dFecha);
                        cmdDeuda.Parameters.AddWithValue("@FechaPago",objCompra.dFecha.AddDays(objCompra.nDias));
                        cmdDeuda.Parameters.AddWithValue("@IdProveedor", objCompra.nIdProveedor);
                        cmdDeuda.Parameters.AddWithValue("@IdReferencia", objCompra.nCodigo);
                        cmdDeuda.Parameters.AddWithValue("@Numero", objCompra.nNumero);
                        cmdDeuda.Parameters.AddWithValue("@Entrada", 1);
                        cmdDeuda.Parameters.AddWithValue("@IdDocumento", objCompra.sIdDocumento);
                        cmdDeuda.Parameters.AddWithValue("@Serie", objCompra.sSerie);
                        cmdDeuda.Parameters.AddWithValue("@Monto", objCompra.fTotal);
                        cmdDeuda.Parameters.AddWithValue("@Saldo", objCompra.fTotal);
                        
                        cmdDeuda.Parameters.AddWithValue("@Usuario", objCompra.sUsuario);
                        cmdDeuda.Parameters.AddWithValue("@Estado", objCompra.bEstado);
                        cmdDeuda.CommandType = CommandType.StoredProcedure;
                        cmdDeuda.Transaction = xTrans;
                        respuesta = cmdDeuda.ExecuteNonQuery();

                        if (respuesta <= 0)
                        {
                            xTrans.Rollback();
                            return respuesta;
                        }
                    }
                    
                    foreach (CompraDetalle item in objCompra.listCompraDetalle)
                    {
                        respuesta = 0;
                        cmdHistorial = new SqlCommand("IAE_HistorialProducto", cnx);
                        cmdHistorial.Parameters.AddWithValue("@Tipo", 3);
                        cmdHistorial.Parameters.AddWithValue("@IdHistorial", item.nIdMovimiento);
                        cmdHistorial.Parameters.AddWithValue("@IdProducto", item.nIdProducto);
                        cmdHistorial.Parameters.AddWithValue("@IdAlmacen", objCompra.nIdAlmacen);
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

                        cmdHistorial.Parameters.AddWithValue("@Usuario", objCompra.sUsuario);
                        cmdHistorial.Parameters.AddWithValue("@Estado", objCompra.bEstado);
                        
                        cmdHistorial.CommandType = CommandType.StoredProcedure;
                        cmdHistorial.Transaction = xTrans;
                        respuesta = cmdHistorial.ExecuteNonQuery();
                        objCompra.nIdHistorial =(int)paramResultado1.Value;

                        if (respuesta <= 0)
                        {
                            xTrans.Rollback();
                            break;
                        }

                        respuesta = 0;
                        cmdTarjeta = new SqlCommand("IAE_Tarjeta", cnx);
                        cmdTarjeta.Parameters.AddWithValue("@Tipo", 2);
                        cmdTarjeta.Parameters.AddWithValue("@IdTarjeta", 0);
                        cmdTarjeta.Parameters.AddWithValue("@Fecha", objCompra.dFecha);
                        cmdTarjeta.Parameters.AddWithValue("@IdAlmacen", objCompra.nIdAlmacen);
                        cmdTarjeta.Parameters.AddWithValue("@IdHistorial", objCompra.nIdHistorial);
                        cmdTarjeta.Parameters.AddWithValue("@TipoMovimiento", 1);
                        cmdTarjeta.Parameters.AddWithValue("@IdReferencia", objCompra.nCodigo);
                        cmdTarjeta.Parameters.AddWithValue("@Lote", item.sLote);

                        cmdTarjeta.Parameters.AddWithValue("@Vencimiento", item.dFechaVencimiento);
                        cmdTarjeta.Parameters.AddWithValue("@IdDocumento", objCompra.sIdDocumento);
                        cmdTarjeta.Parameters.AddWithValue("@Serie", objCompra.sSerie);

                        cmdTarjeta.Parameters.AddWithValue("@Numero", objCompra.nNumero);
                        cmdTarjeta.Parameters.AddWithValue("@IdProducto", item.nIdProducto);
                        cmdTarjeta.Parameters.AddWithValue("@Entrada", item.nCantidad);

                        cmdTarjeta.Parameters.AddWithValue("@Salida", 0);
                        cmdTarjeta.Parameters.AddWithValue("@Existencia", 0);
                        cmdTarjeta.Parameters.AddWithValue("@PrecioCompra", item.fPrecioCompra);

                        cmdTarjeta.Parameters.AddWithValue("@PrecioVenta", item.fPrecioVenta);
                        cmdTarjeta.Parameters.AddWithValue("@Debe", item.fSubTotal);
                        cmdTarjeta.Parameters.AddWithValue("@Haber",0);
            
                        cmdTarjeta.Parameters.AddWithValue("@Saldo", 0);
                        
                        SqlParameter paramResultado2 = new SqlParameter("@Codigo", SqlDbType.Int);
                        paramResultado2.Direction = ParameterDirection.Output;
                        cmdTarjeta.Parameters.Add(paramResultado2);

                        cmdTarjeta.Parameters.AddWithValue("@Usuario", objCompra.sUsuario);
                        cmdTarjeta.Parameters.AddWithValue("@Estado", objCompra.bEstado);

                        cmdTarjeta.CommandType = CommandType.StoredProcedure;
                        cmdTarjeta.Transaction = xTrans;
                        respuesta = cmdTarjeta.ExecuteNonQuery();
                        objCompra.nIdTarjeta = (int)paramResultado2.Value;

                        if (respuesta <= 0)
                        {
                            xTrans.Rollback();
                            break;
                        }

                        respuesta = 0;
                        cmdDetalle = new SqlCommand("IAE_DetalleCompra", cnx);
                        cmdDetalle.Parameters.AddWithValue("@Tipo", objCompra.nTipo);
                        cmdDetalle.Parameters.AddWithValue("@IdDetalleCompra", 0);
                        cmdDetalle.Parameters.AddWithValue("@IdTarjeta", objCompra.nIdTarjeta);
                        cmdDetalle.Parameters.AddWithValue("@IdCompra", objCompra.nCodigo);
                        cmdDetalle.Parameters.AddWithValue("@IdProducto", item.nIdProducto);
                        cmdDetalle.Parameters.AddWithValue("@Cantidad", item.nCantidad);
                        cmdDetalle.Parameters.AddWithValue("@Precio", item.fPrecioCompra);
                        cmdDetalle.Parameters.AddWithValue("@Ganancia", item.fGanancia);
                        cmdDetalle.Parameters.AddWithValue("@Lote", item.sLote);

                        cmdDetalle.Parameters.AddWithValue("@Usuario", objCompra.sUsuario);
                        cmdDetalle.Parameters.AddWithValue("@Estado", objCompra.bEstado);

                        cmdDetalle.CommandType = CommandType.StoredProcedure;
                        cmdDetalle.Transaction = xTrans;
                        respuesta = cmdDetalle.ExecuteNonQuery();

                        if (respuesta <= 0)
                        {
                            xTrans.Rollback();
                            break;
                        }
                    }

                    if(respuesta>0) xTrans.Commit();
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

        public static int AnularCompra(Compra objCompra)
        {
            int respuesta = 0;

            SqlCommand cmd = null;
            SqlCommand cmdDeuda = null;
            
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
                cmd = new SqlCommand("IAE_Compra", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tipo", 4);
                cmd.Parameters.AddWithValue("@IdCompra", objCompra.nIdCompra);
                cmd.Parameters.AddWithValue("@IdAlmacen", objCompra.nIdAlmacen);
                cmd.Parameters.AddWithValue("@IdDocumento", objCompra.sIdDocumento);
                cmd.Parameters.AddWithValue("@Serie", objCompra.sSerie);
                cmd.Parameters.AddWithValue("@Numero", objCompra.nNumero);
                cmd.Parameters.AddWithValue("@Fecha", objCompra.dFecha);
                cmd.Parameters.AddWithValue("@Porcentaje", objCompra.nPorcentaje);
                cmd.Parameters.AddWithValue("@SubTotal", objCompra.fSubTotal);
                cmd.Parameters.AddWithValue("@Igv", objCompra.fIgv);
                cmd.Parameters.AddWithValue("@Total", objCompra.fTotal);
                cmd.Parameters.AddWithValue("@IdProveedor", objCompra.nIdProveedor);
                cmd.Parameters.AddWithValue("@Credito", objCompra.bCredito);
                cmd.Parameters.AddWithValue("@Dias", objCompra.nDias);
                cmd.Parameters.AddWithValue("@Codigo", 0);
                cmd.Parameters.AddWithValue("@Usuario", objCompra.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objCompra.bEstado);
                cmd.Transaction = xTrans;
                respuesta = cmd.ExecuteNonQuery();

                if (respuesta <= 0)
                {
                    xTrans.Rollback();
                    return respuesta;
                }
                else
                {
                    if (objCompra.bCredito)
                    {
                        respuesta = 0;
                        cmdDeuda = new SqlCommand("IAE_Deuda", cnx);
                        cmdDeuda.Parameters.AddWithValue("@Tipo", 2);
                        cmdDeuda.Parameters.AddWithValue("@IdDeuda", objCompra.nIdCompra);
                        cmdDeuda.Parameters.AddWithValue("@Fecha", objCompra.dFecha);
                        cmdDeuda.Parameters.AddWithValue("@FechaPago", objCompra.dFecha.AddDays(objCompra.nDias));
                        cmdDeuda.Parameters.AddWithValue("@IdProveedor", objCompra.nIdProveedor);
                        cmdDeuda.Parameters.AddWithValue("@IdReferencia", objCompra.nIdCompra);
                        cmdDeuda.Parameters.AddWithValue("@Numero", objCompra.nNumero);
                        cmdDeuda.Parameters.AddWithValue("@Entrada", 1);
                        cmdDeuda.Parameters.AddWithValue("@IdDocumento", objCompra.sIdDocumento);
                        cmdDeuda.Parameters.AddWithValue("@Serie", objCompra.sSerie);
                        cmdDeuda.Parameters.AddWithValue("@Monto", objCompra.fTotal);
                        cmdDeuda.Parameters.AddWithValue("@Saldo", objCompra.fTotal);

                        cmdDeuda.Parameters.AddWithValue("@Usuario", objCompra.sUsuario);
                        cmdDeuda.Parameters.AddWithValue("@Estado", objCompra.bEstado);
                        cmdDeuda.CommandType = CommandType.StoredProcedure;
                        cmdDeuda.Transaction = xTrans;
                        respuesta = cmdDeuda.ExecuteNonQuery();

                        if (respuesta <= 0)
                        {
                            xTrans.Rollback();
                            return respuesta;
                        }
                    }

                    foreach (var item in objCompra.listCompraDetalle)
                    {
                        respuesta = 0;
                        cmdTarjeta = new SqlCommand("IAE_Tarjeta", cnx);
                        cmdTarjeta.Parameters.AddWithValue("@Tipo", 4);
                        cmdTarjeta.Parameters.AddWithValue("@IdTarjeta", item.nIdTarjeta);
                        cmdTarjeta.Parameters.AddWithValue("@Fecha", objCompra.dFecha);
                        cmdTarjeta.Parameters.AddWithValue("@IdAlmacen", objCompra.nIdAlmacen);
                        cmdTarjeta.Parameters.AddWithValue("@IdHistorial", objCompra.nIdHistorial);
                        cmdTarjeta.Parameters.AddWithValue("@TipoMovimiento", 1);
                        cmdTarjeta.Parameters.AddWithValue("@IdReferencia", objCompra.nCodigo);
                        cmdTarjeta.Parameters.AddWithValue("@Lote", item.sLote);

                        cmdTarjeta.Parameters.AddWithValue("@Vencimiento", item.dFechaVencimiento);
                        cmdTarjeta.Parameters.AddWithValue("@IdDocumento", objCompra.sIdDocumento);
                        cmdTarjeta.Parameters.AddWithValue("@Serie", objCompra.sSerie);

                        cmdTarjeta.Parameters.AddWithValue("@Numero", objCompra.nNumero);
                        cmdTarjeta.Parameters.AddWithValue("@IdProducto", item.nIdProducto);
                        cmdTarjeta.Parameters.AddWithValue("@Entrada", item.nCantidad);

                        cmdTarjeta.Parameters.AddWithValue("@Salida", 0);
                        cmdTarjeta.Parameters.AddWithValue("@Existencia", 0);
                        cmdTarjeta.Parameters.AddWithValue("@PrecioCompra", 0);

                        cmdTarjeta.Parameters.AddWithValue("@PrecioVenta", 0);
                        cmdTarjeta.Parameters.AddWithValue("@Debe", 0);
                        cmdTarjeta.Parameters.AddWithValue("@Haber", 0);

                        cmdTarjeta.Parameters.AddWithValue("@Saldo", 0);

                        SqlParameter paramResultado2 = new SqlParameter("@Codigo", SqlDbType.Int);
                        paramResultado2.Direction = ParameterDirection.Output;
                        cmdTarjeta.Parameters.Add(paramResultado2);

                        cmdTarjeta.Parameters.AddWithValue("@Usuario", objCompra.sUsuario);
                        cmdTarjeta.Parameters.AddWithValue("@Estado", objCompra.bEstado);

                        cmdTarjeta.CommandType = CommandType.StoredProcedure;
                        cmdTarjeta.Transaction = xTrans;
                        respuesta = cmdTarjeta.ExecuteNonQuery();
                        objCompra.nIdTarjeta = (int)paramResultado2.Value;

                        if (respuesta <= 0)
                        {
                            xTrans.Rollback();
                            break;
                        }

                        respuesta = 0;
                        cmdHistorial = new SqlCommand("IAE_HistorialProducto", cnx);
                        cmdHistorial.Parameters.AddWithValue("@Tipo", 5);
                        cmdHistorial.Parameters.AddWithValue("@IdHistorial", objCompra.nIdTarjeta);
                        cmdHistorial.Parameters.AddWithValue("@IdProducto", item.nIdProducto);
                        cmdHistorial.Parameters.AddWithValue("@IdAlmacen", objCompra.nIdAlmacen);
                        cmdHistorial.Parameters.AddWithValue("@Lote", item.sLote);
                        cmdHistorial.Parameters.AddWithValue("@IdLote", item.sLote);
                        cmdHistorial.Parameters.AddWithValue("@PrecioCompra", 0);
                        cmdHistorial.Parameters.AddWithValue("@Ganancia", 0);
                        cmdHistorial.Parameters.AddWithValue("@PrecioVenta", 0);
                        cmdHistorial.Parameters.AddWithValue("@Stock", item.nCantidad);
                        cmdHistorial.Parameters.AddWithValue("@Codigo", 0);
                        cmdHistorial.Parameters.AddWithValue("@Vencimiento", item.dFechaVencimiento);
                        cmdHistorial.Parameters.AddWithValue("@Usuario", objCompra.sUsuario);
                        cmdHistorial.Parameters.AddWithValue("@Estado", objCompra.bEstado);

                        cmdHistorial.CommandType = CommandType.StoredProcedure;
                        cmdHistorial.Transaction = xTrans;
                        respuesta = cmdHistorial.ExecuteNonQuery();

                        if (respuesta <= 0)
                        {
                            xTrans.Rollback();
                            break;
                        }
                        
                        respuesta = 0;
                        cmdDetalle = new SqlCommand("IAE_DetalleCompra", cnx);
                        cmdDetalle.Parameters.AddWithValue("@Tipo", 2);
                        cmdDetalle.Parameters.AddWithValue("@IdDetalleCompra", item.nIdCompraDetalle);
                        cmdDetalle.Parameters.AddWithValue("@IdTarjeta", objCompra.nIdTarjeta);
                        cmdDetalle.Parameters.AddWithValue("@IdCompra", objCompra.nIdCompra);
                        cmdDetalle.Parameters.AddWithValue("@IdProducto", item.nIdProducto);
                        cmdDetalle.Parameters.AddWithValue("@Cantidad", item.nCantidad);
                        cmdDetalle.Parameters.AddWithValue("@Precio", 0);
                        cmdDetalle.Parameters.AddWithValue("@Ganancia", 0);
                        cmdDetalle.Parameters.AddWithValue("@Lote", item.sLote);

                        cmdDetalle.Parameters.AddWithValue("@Usuario", objCompra.sUsuario);
                        cmdDetalle.Parameters.AddWithValue("@Estado", objCompra.bEstado);

                        cmdDetalle.CommandType = CommandType.StoredProcedure;
                        cmdDetalle.Transaction = xTrans;
                        respuesta = cmdDetalle.ExecuteNonQuery();

                        if (respuesta <= 0)
                        {
                            xTrans.Rollback();
                            break;
                        }

                    }

                    if (respuesta > 0) xTrans.Commit();
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
