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
    public class InventarioData
    {
        //Listar Varios
        public static List<Inventario> ListarInventario(Inventario objInventario)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            SqlConnection cnx = null;
            List<Inventario> listInvent = new List<Inventario>();
            try
            {
                Conexion cn = new Conexion();
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Inventario", cnx);
                cmd.Parameters.AddWithValue("@Tipo", objInventario.nTipo);
                cmd.Parameters.AddWithValue("@IdInventario", objInventario.nIdInventario);
                cmd.Parameters.AddWithValue("@Item", objInventario.nItem);
                cmd.Parameters.AddWithValue("@FechaInicia", objInventario.dFechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", objInventario.dFechaFin);
                cmd.Parameters.AddWithValue("@IdAlmacen", objInventario.nIdAlmacen);
                cmd.Parameters.AddWithValue("@Usuario", objInventario.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objInventario.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Inventario objInvent = new Inventario();
                    objInvent.nIdInventario = int.Parse(dr[0].ToString());
                    objInvent.nItem = int.Parse(dr[1].ToString());
                    objInvent.nIdAlmacen = int.Parse(dr[2].ToString());
                    objInvent.sDecripcion =dr[3].ToString();
                    objInvent.dFechaInicio =DateTime.Parse(dr[4].ToString());
                    if(dr[5] != DBNull.Value) objInvent.dFechaFin = DateTime.Parse(dr[5].ToString());
                    else objInvent.dFechaFin = null;
                    objInvent.bEstado =bool.Parse(dr[6].ToString());

                    listInvent.Add(objInvent);

                }
                return listInvent;
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

        public static int ActualizarInventario(Inventario objInventario)
        {
            int respuesta = 0;
            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;
            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Inventario", cnx);
                cmd.Parameters.AddWithValue("@Tipo", objInventario.nTipo);
                cmd.Parameters.AddWithValue("@IdInventario", objInventario.nIdInventario);
                cmd.Parameters.AddWithValue("@Item", objInventario.nItem);
                cmd.Parameters.AddWithValue("@FechaInicia", objInventario.dFechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", objInventario.dFechaFin);
                cmd.Parameters.AddWithValue("@IdAlmacen", objInventario.nIdAlmacen);
                cmd.Parameters.AddWithValue("@Usuario", objInventario.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objInventario.bEstado);
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
