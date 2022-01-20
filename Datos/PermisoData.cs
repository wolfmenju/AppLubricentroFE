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
    public class PermisoData
    {
        //Listar Varios
        public static List<Permiso> ListarPermiso(string sIdUsuario,int xTipo)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            SqlConnection cnx = null;

            List<Permiso> listPermiso = new List<Permiso>();
            try
            {
                Conexion cn = new Conexion();
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Permiso", cnx);
                cmd.Parameters.AddWithValue("@Tipo", xTipo);
                cmd.Parameters.AddWithValue("@IdPermiso", "");
                cmd.Parameters.AddWithValue("@IdMenu", "");
                cmd.Parameters.AddWithValue("@IdUsuario", sIdUsuario);
                cmd.Parameters.AddWithValue("@Estado",true);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Permiso objPermiso = new Permiso();
                    
                    if (xTipo == 1)
                    {
                        objPermiso.nIdPermiso = int.Parse(dr[0].ToString());
                        objPermiso.nIdMenu = int.Parse(dr[1].ToString());
                        objPermiso.nTag = int.Parse(dr[2].ToString());
                        objPermiso.sDescripcion = dr[3].ToString();
                    }
                    else
                    {
                        objPermiso.nIdMenu = int.Parse(dr[0].ToString());
                        objPermiso.nTag = int.Parse(dr[1].ToString());
                        objPermiso.sDescripcion = dr[2].ToString();
                    }

                    listPermiso.Add(objPermiso);

                }
                return listPermiso;
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
        
        //Actualizar
        public static int ActualizarPermiso(Permiso objPer)
        {
            int respuesta = 0, xTipo = 3;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;

            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Permiso", cnx);
                cmd.Parameters.AddWithValue("@Tipo", xTipo);
                cmd.Parameters.AddWithValue("@IdPermiso", objPer.nIdPermiso);
                cmd.Parameters.AddWithValue("@IdMenu", objPer.nIdMenu);
                cmd.Parameters.AddWithValue("@IdUsuario", objPer.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objPer.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                respuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
