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
    public class AlmacenData
    {
        //Listar Varios
        public static List<Almacen> ListarAlmacen(bool estado)
        {
            int tipo = 1;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            SqlConnection cnx = null;
            List<Almacen> listAlmacen = new List<Almacen>();
            try
            {
                Conexion cn = new Conexion();
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Almacen", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdAlmacen", "");
                cmd.Parameters.AddWithValue("@Descripcion", "");
                cmd.Parameters.AddWithValue("@Direccion", "");
                cmd.Parameters.AddWithValue("@IdSede", "");
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Almacen objAlmacen = new Almacen();
                    objAlmacen.nIdAlmacen = int.Parse(dr[0].ToString());
                    objAlmacen.sDescripcion = dr[1].ToString();
                    objAlmacen.sDireccion = dr[2].ToString();
                    
                    listAlmacen.Add(objAlmacen);

                }
                return listAlmacen;
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
        public static int ActualizarAlmacen(Almacen objAlm)
        {
            int respuesta = 0, tipo = 3;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();

            try
            {
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Almacen", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdAlmacen", objAlm.nIdAlmacen);
                cmd.Parameters.AddWithValue("@Descripcion", objAlm.sDescripcion);
                cmd.Parameters.AddWithValue("@Direccion", objAlm.sDireccion);
                cmd.Parameters.AddWithValue("@IdSede", objAlm.nIdSede);
                cmd.Parameters.AddWithValue("@Usuario", objAlm.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objAlm.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                respuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                respuesta = 2;
                MessageBox.Show(ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                cmd = null;
                cn = null;
            }

            return respuesta;
        }

        public static int RegistrarAlmacen(Almacen objAlm)
        {
            int respuesta = 0, tipo = 2;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx=null;
            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Almacen", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdAlmacen", objAlm.nIdAlmacen);
                cmd.Parameters.AddWithValue("@Descripcion", objAlm.sDescripcion);
                cmd.Parameters.AddWithValue("@Direccion", objAlm.sDireccion);
                cmd.Parameters.AddWithValue("@IdSede", objAlm.nIdSede);
                cmd.Parameters.AddWithValue("@Usuario", objAlm.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objAlm.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                respuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                respuesta = 2;
                MessageBox.Show(ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                cnx.Close();
                cnx.Dispose();
            }

            return respuesta;
        }

        //Eliminar
        public static int EliminarActivarAlmacen(Almacen objAlm)
        {
            int respuesta = 0, tipo = 4;
            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;

            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Almacen", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdAlmacen", objAlm.nIdAlmacen);
                cmd.Parameters.AddWithValue("@Descripcion", objAlm.sDescripcion);
                cmd.Parameters.AddWithValue("@Direccion", objAlm.sDireccion);
                cmd.Parameters.AddWithValue("@IdSede", objAlm.nIdSede);
                cmd.Parameters.AddWithValue("@Usuario", objAlm.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objAlm.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                respuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                respuesta = 2;
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
