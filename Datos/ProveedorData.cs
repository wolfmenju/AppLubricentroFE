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
    public class ProveedorData
    {
        //Listar Varios
        public static List<Proveedor> ListarProveedor(bool bEstado)
        {
            int tipo = 1;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            SqlConnection cnx = null;
            List<Proveedor> listProveedor = new List<Proveedor>();
            try
            {
                Conexion cn = new Conexion();
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Proveedor", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdProveedor", 0);
                cmd.Parameters.AddWithValue("@RazonSocial", "");
                cmd.Parameters.AddWithValue("@Ruc", "");
                cmd.Parameters.AddWithValue("@Direccion", "");
                cmd.Parameters.AddWithValue("@Celular", "");
                cmd.Parameters.AddWithValue("@Contacto", "");
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Estado", bEstado);

                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Proveedor objUser = new Proveedor();
                    objUser.nIdProveedor = Convert.ToInt32(dr[0]);
                    objUser.sRazonSocial = dr[1].ToString();
                    objUser.sRuc = dr[2].ToString();
                    objUser.sDireccion = dr[3].ToString();
                    objUser.sCelular = dr[4].ToString();
                    objUser.sContacto = dr[5].ToString();

                    listProveedor.Add(objUser);

                }
                return listProveedor;
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
        public static int RegistrarProveedor(Proveedor objProvee)
        {
            int respuesta = 0, tipo = 2;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;
            
            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Proveedor", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdProveedor", objProvee.nIdProveedor);
                cmd.Parameters.AddWithValue("@RazonSocial", objProvee.sRazonSocial);
                cmd.Parameters.AddWithValue("@Ruc", objProvee.sRuc);
                cmd.Parameters.AddWithValue("@Direccion", objProvee.sDireccion);
                cmd.Parameters.AddWithValue("@Celular", objProvee.sCelular);
                cmd.Parameters.AddWithValue("@Contacto", objProvee.sContacto);
                cmd.Parameters.AddWithValue("@Usuario", objProvee.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objProvee.bEstado);
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

        //Actualizar
        public static int ActualizarProveedor(Proveedor objProvee)
        {
            int respuesta = 0, tipo = 3;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;

            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Proveedor", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdProveedor", objProvee.nIdProveedor);
                cmd.Parameters.AddWithValue("@RazonSocial", objProvee.sRazonSocial);
                cmd.Parameters.AddWithValue("@Ruc", objProvee.sRuc);
                cmd.Parameters.AddWithValue("@Direccion", objProvee.sDireccion);
                cmd.Parameters.AddWithValue("@Celular", objProvee.sCelular);
                cmd.Parameters.AddWithValue("@Contacto", objProvee.sContacto);
                cmd.Parameters.AddWithValue("@Usuario", objProvee.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objProvee.bEstado);
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

        public static int EliminarActivarProveedor(Proveedor objProvee)
        {
            int respuesta = 0, tipo = 4;
            SqlCommand cmd = null;
            SqlConnection cnx = null;
            Conexion cn = new Conexion();

            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Proveedor", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdProveedor", objProvee.nIdProveedor);
                cmd.Parameters.AddWithValue("@RazonSocial", objProvee.sRazonSocial);
                cmd.Parameters.AddWithValue("@Ruc", objProvee.sRuc);
                cmd.Parameters.AddWithValue("@Direccion", objProvee.sDireccion);
                cmd.Parameters.AddWithValue("@Celular", objProvee.sCelular);
                cmd.Parameters.AddWithValue("@Contacto", objProvee.sContacto);
                cmd.Parameters.AddWithValue("@Usuario", objProvee.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objProvee.bEstado);
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
