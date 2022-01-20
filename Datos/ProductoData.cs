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
    public class ProductoData
    {
        //Listar Varios
        public static List<Producto> ListarProducto(Producto objProducto)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            SqlConnection cnx = null;

            List<Producto> listProducto = new List<Producto>();
            try
            {
                Conexion cn = new Conexion();
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Producto", cnx);
                cmd.Parameters.AddWithValue("@Tipo", objProducto.nTipo);
                cmd.Parameters.AddWithValue("@IdProducto", objProducto.nIdProducto);
                cmd.Parameters.AddWithValue("@PrincipioActivo", objProducto.sPrincipioActivo);
                cmd.Parameters.AddWithValue("@IdLaboratorio", objProducto.nIdLaboratorio);
                cmd.Parameters.AddWithValue("@IdPresenta", objProducto.nIdPresentacion);
                cmd.Parameters.AddWithValue("@Alternativo", objProducto.bAlternativo);
                cmd.Parameters.AddWithValue("@StockMinimo", objProducto.nStockMinimo);
                cmd.Parameters.AddWithValue("@Usuario", objProducto.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objProducto.bEstado);

                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Producto objProd = new Producto();

                    if (objProducto.nTipo == 1)
                    {
                        objProd.nIdProducto = Convert.ToInt32(dr[0]);
                        objProd.sCodigoInterno = dr[1].ToString();
                        objProd.sDescripcion = dr[2].ToString();
                        objProd.sPrincipioActivo = dr[3].ToString();
                        objProd.nIdLaboratorio = Convert.ToInt32(dr[4].ToString());
                        objProd.nIdPresentacion = Convert.ToInt32(dr[5].ToString());
                        objProd.bAlternativo = Convert.ToBoolean(dr[6].ToString());
                        objProd.nStockMinimo = Convert.ToInt32(dr[7].ToString());
                    }
                    else if (objProducto.nTipo == 7)
                    {
                        objProd.nIdProducto = Convert.ToInt32(dr[0]);
                        objProd.sDescripcion = dr[1].ToString();
                        objProd.sPrincipioActivo = dr[2].ToString();
                        objProd.sLaboratorio =dr[3].ToString();
                        objProd.sPresentacion = dr[4].ToString();
                        objProd.bAlternativo = Convert.ToBoolean(dr[5].ToString());
                        objProd.nStockMinimo = Convert.ToInt32(dr[6].ToString());
                    }
                    else if (objProducto.nTipo == 5 || objProducto.nTipo == 9 || objProducto.nTipo == 8 || objProducto.nTipo == 10)
                    {
                        objProd.nIdProducto = Convert.ToInt32(dr[0]);
                        objProd.sCodigoInterno = dr[1].ToString();
                        objProd.sDescripcion = dr[2].ToString();
                        objProd.bAlternativo = Convert.ToBoolean(dr[3].ToString());
                        objProd.sLaboratorio = dr[4].ToString();

                        if (objProducto.nTipo == 8)
                        {
                            objProd.sPresentacion = dr[5].ToString();
                            objProd.nTotal = Convert.ToInt32(dr[6].ToString());
                        }
                        else
                        {
                            objProd.sPrincipioActivo = dr[5].ToString();
                            objProd.sPresentacion = dr[6].ToString();
                            objProd.nTotal = Convert.ToInt32(dr[7].ToString());
                        }
                    }
                    else if (objProducto.nTipo == 4)
                    {
                        objProd.nIdProducto = Convert.ToInt32(dr[0]);
                        objProd.sCodigoInterno = dr[1].ToString();
                        objProd.sDescripcion = dr[2].ToString();
                        objProd.bAlternativo =Convert.ToBoolean(dr[3]);
                        if (dr[4] != DBNull.Value) objProd.dFechaVencimiento = DateTime.Parse(dr[4].ToString());
                        else objProd.dFechaVencimiento = null;
                        if (dr[5] != DBNull.Value) objProd.nStock = int.Parse(dr[5].ToString());
                        else objProd.nTotal = null;
                        if (dr[6] != DBNull.Value) objProd.sLote = dr[6].ToString();
                        else objProd.sLote = null;
                        if (dr[7] != DBNull.Value) objProd.fPrecioCompra = Decimal.Parse(dr[7].ToString());
                        else objProd.fPrecioCompra = null;
                        if (dr[8] != DBNull.Value) objProd.fPrecioVenta = Decimal.Parse(dr[8].ToString());
                        else objProd.fPrecioVenta = null;
                        objProd.sLaboratorio = dr[9].ToString();
                        objProd.sPresentacion = dr[10].ToString();
                    }

                    listProducto.Add(objProd);
                }

                return listProducto;
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
        public static int RegistrarProducto(Producto objProducto)
        {
            int respuesta = 0, tipo = 2;

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
                cmd.Parameters.AddWithValue("@Tipo", 1);
                cmd.Parameters.AddWithValue("@IdProducto", objProducto.nIdProducto);
                cmd.Parameters.AddWithValue("@CodigoInterno", objProducto.sCodigoInterno);
                cmd.Parameters.AddWithValue("@Descripcion", objProducto.sDescripcion);
                cmd.Parameters.AddWithValue("@Usuario", objProducto.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objProducto.bEstado);
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
                    cmdDetalle = new SqlCommand("IAE_Producto", cnx);
                    cmdDetalle.Parameters.AddWithValue("@Tipo", tipo);
                    cmdDetalle.Parameters.AddWithValue("@IdProducto", objProducto.nIdProducto);
                    cmdDetalle.Parameters.AddWithValue("@PrincipioActivo", objProducto.sPrincipioActivo);
                    cmdDetalle.Parameters.AddWithValue("@IdLaboratorio", objProducto.nIdLaboratorio);
                    cmdDetalle.Parameters.AddWithValue("@IdPresenta", objProducto.nIdPresentacion);
                    cmdDetalle.Parameters.AddWithValue("@Alternativo", objProducto.bAlternativo);
                    cmdDetalle.Parameters.AddWithValue("@StockMinimo", objProducto.nStockMinimo);
                    cmdDetalle.Parameters.AddWithValue("@Usuario", objProducto.sUsuario);
                    cmdDetalle.Parameters.AddWithValue("@Estado", objProducto.bEstado);
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

        //Actualizar
        public static int ActualizarProducto(Producto objProducto)
        {
            int respuesta = 0, tipo = 3;

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
                cmd.Parameters.AddWithValue("@Tipo", 2);
                cmd.Parameters.AddWithValue("@IdProducto", objProducto.nIdProducto);
                cmd.Parameters.AddWithValue("@Descripcion", objProducto.sDescripcion);
                cmd.Parameters.AddWithValue("@CodigoInterno", objProducto.sCodigoInterno);
                cmd.Parameters.AddWithValue("@Usuario", objProducto.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objProducto.bEstado);
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
                    cmdDetalle = new SqlCommand("IAE_Producto", cnx);
                    cmdDetalle.Parameters.AddWithValue("@Tipo", tipo);
                    cmdDetalle.Parameters.AddWithValue("@IdProducto", objProducto.nIdProducto);
                    cmdDetalle.Parameters.AddWithValue("@PrincipioActivo", objProducto.sPrincipioActivo);
                    cmdDetalle.Parameters.AddWithValue("@IdLaboratorio", objProducto.nIdLaboratorio);
                    cmdDetalle.Parameters.AddWithValue("@IdPresenta", objProducto.nIdPresentacion);
                    cmdDetalle.Parameters.AddWithValue("@Alternativo", objProducto.bAlternativo);
                    cmdDetalle.Parameters.AddWithValue("@StockMinimo", objProducto.nStockMinimo);
                    cmdDetalle.Parameters.AddWithValue("@Usuario", objProducto.sUsuario);
                    cmdDetalle.Parameters.AddWithValue("@Estado", objProducto.bEstado);
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

        public static int EliminarActivarProducto(Producto objProducto)
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
                cmd.Parameters.AddWithValue("@IdProducto", objProducto.nIdProducto);
                cmd.Parameters.AddWithValue("@Descripcion", objProducto.sDescripcion);
                cmd.Parameters.AddWithValue("@CodigoInterno", objProducto.sCodigoInterno);
                cmd.Parameters.AddWithValue("@Usuario", objProducto.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objProducto.bEstado);
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
