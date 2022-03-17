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
    public class PedidoData
    {

        public static int RegistrarPedido(Pedido objPedido)
        {
            int respuesta = 0;

            SqlCommand cmd = null;
            SqlCommand cmdDetalle = null;

            Conexion cn = new Conexion();
            SqlTransaction xTrans;
            SqlConnection cnx = cn.getConecta();
            cnx.Open();
            xTrans = cnx.BeginTransaction();

            try
            {
                cmd = new SqlCommand("IAE_Pedido", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tipo", objPedido.nTipo);
                cmd.Parameters.AddWithValue("@IdPedido", objPedido.nIdPedido);
                cmd.Parameters.AddWithValue("@IdAlmacen", objPedido.nIdAlmacen);
                cmd.Parameters.AddWithValue("@Fecha", objPedido.nIdPedido);
                cmd.Parameters.AddWithValue("@Porcentaje", objPedido.nIdAlmacen);
                cmd.Parameters.AddWithValue("@SubTotal", objPedido.nIdPedido);
                cmd.Parameters.AddWithValue("@Igv", objPedido.nIdAlmacen);
                cmd.Parameters.AddWithValue("@Total", objPedido.nIdPedido);
                cmd.Parameters.AddWithValue("@IdCliente", objPedido.nIdAlmacen);
                cmd.Parameters.AddWithValue("@Nombre", objPedido.nIdPedido);
           
                SqlParameter paramNum = new SqlParameter("@Numero", SqlDbType.Int);
                paramNum.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramNum);

                SqlParameter paramResultado = new SqlParameter("@Codigo", SqlDbType.Int);
                paramResultado.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramResultado);

                cmd.Parameters.AddWithValue("@Usuario", objPedido.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objPedido.bEstado);
                cmd.Transaction = xTrans;

                respuesta = cmd.ExecuteNonQuery();
                objPedido.nCodigo = (int)paramResultado.Value;
                objPedido.nNumero = (int)paramNum.Value;

                if (respuesta <= 0)
                {
                    xTrans.Rollback();
                    return respuesta;
                }
                
                foreach (PedidoDetalle item in objPedido.ListDetallePedido)
                {
                    respuesta = 0;
                    cmdDetalle = new SqlCommand("IAE_DetallePedido", cnx);
                    cmdDetalle.Parameters.AddWithValue("@Tipo", objPedido.nTipo);
                    cmdDetalle.Parameters.AddWithValue("@IdDetallePedido", 0);
                    cmdDetalle.Parameters.AddWithValue("@IdPedido", objPedido.nCodigo);
                    cmdDetalle.Parameters.AddWithValue("@IdProducto", item.nIdProducto);
                    cmdDetalle.Parameters.AddWithValue("@IdTarjeta", item.nCantidad);
                    cmdDetalle.Parameters.AddWithValue("@Cantidad", item.nCantidad);
                    cmdDetalle.Parameters.AddWithValue("@Precio", item.fPrecioVenta);
                    cmdDetalle.Parameters.AddWithValue("@Ganancia", item.fGanancia);
                    cmdDetalle.Parameters.AddWithValue("@Lote", item.sLote);
                    cmdDetalle.Parameters.AddWithValue("@Total", objPedido.fTotal);
                    cmdDetalle.Parameters.AddWithValue("@Servicio", item.bServicio);
                    cmdDetalle.Parameters.AddWithValue("@Usuario", objPedido.sUsuario);
                    cmdDetalle.Parameters.AddWithValue("@Estado", objPedido.bEstado);

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
                    respuesta = objPedido.nCodigo;
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
    }
}
