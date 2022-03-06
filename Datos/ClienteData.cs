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
    public class ClienteData
    {
        //Listar Varios
        public static List<Cliente> ListarCliente(Cliente objCliente)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            SqlConnection cnx = null;
            List<Cliente> listCliente = new List<Cliente>();
            try
            {
                Conexion cn = new Conexion();
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Cliente", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tipo", objCliente.nTipo);
                cmd.Parameters.AddWithValue("@IdCliente", objCliente.nIdCliente);
                cmd.Parameters.AddWithValue("@Nombres", objCliente.sNombres);
                cmd.Parameters.AddWithValue("@TipoPersona", objCliente.bTipoPersona);
                cmd.Parameters.AddWithValue("@TipoDoc", objCliente.sTipoDoc);
                cmd.Parameters.AddWithValue("@NumDoc", objCliente.sNumeroDoc);
                cmd.Parameters.AddWithValue("@Direccion", objCliente.sDireccion);
                cmd.Parameters.AddWithValue("@Distrito", objCliente.sDistrito);
                cmd.Parameters.AddWithValue("@Provincia", objCliente.sProvincia);
                cmd.Parameters.AddWithValue("@Departamento", objCliente.sDepartamento);
                cmd.Parameters.AddWithValue("@Ubigeo", objCliente.sUbigeo);
                cmd.Parameters.AddWithValue("@Celular", objCliente.sCelular);
                cmd.Parameters.AddWithValue("@Usuario", objCliente.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objCliente.bEstado);
                cmd.Parameters.AddWithValue("@ValidadoSunat", objCliente.bValidadoSunat);

                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Cliente objUser = new Cliente();
                    objUser.nIdCliente = Convert.ToInt32(dr[0]);
                    objUser.sNombres = dr[1].ToString();

                    if (objCliente.nTipo == 6 || objCliente.nTipo == 5)
                    {
                        objUser.sTipoDoc = dr[2].ToString();
                        objUser.sNumeroDoc = dr[3].ToString();
                        objUser.sDireccion = dr[4].ToString();
                    }
                    else
                    {
                        objUser.bTipoPersona = Convert.ToBoolean(dr[2].ToString());
                        objUser.sTipoDoc= dr[3].ToString();
                        objUser.sNumeroDoc = dr[4].ToString();
                        objUser.sDireccion = dr[5].ToString();
                        objUser.sCelular = dr[6].ToString();
                    }

                    listCliente.Add(objUser);

                }
                return listCliente;
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
        public static int RegistrarCliente(Cliente objCliente)
        {
            int respuesta = 0, tipo = 2;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;    
            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Cliente", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdCliente", objCliente.nIdCliente);
                cmd.Parameters.AddWithValue("@Nombres", objCliente.sNombres);
                cmd.Parameters.AddWithValue("@TipoPersona", objCliente.bTipoPersona);
                cmd.Parameters.AddWithValue("@TipoDoc", objCliente.sTipoDoc);
                cmd.Parameters.AddWithValue("@NumDoc", objCliente.sNumeroDoc);
                cmd.Parameters.AddWithValue("@Direccion", objCliente.sDireccion);
                cmd.Parameters.AddWithValue("@Distrito", objCliente.sDistrito);
                cmd.Parameters.AddWithValue("@Provincia", objCliente.sProvincia);
                cmd.Parameters.AddWithValue("@Departamento", objCliente.sDepartamento);
                cmd.Parameters.AddWithValue("@Ubigeo", objCliente.sUbigeo);
                cmd.Parameters.AddWithValue("@Celular", objCliente.sCelular);
                cmd.Parameters.AddWithValue("@Usuario", objCliente.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objCliente.bEstado);
                cmd.Parameters.AddWithValue("@ValidadoSunat", objCliente.bValidadoSunat);
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

        public static int ActualizarCliente(Cliente objCliente)
        {
            int respuesta = 0, tipo = 3;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;
            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Cliente", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdCliente", objCliente.nIdCliente);
                cmd.Parameters.AddWithValue("@Nombres", objCliente.sNombres);
                cmd.Parameters.AddWithValue("@TipoPersona", objCliente.bTipoPersona);
                cmd.Parameters.AddWithValue("@TipoDoc", objCliente.sTipoDoc);
                cmd.Parameters.AddWithValue("@NumDoc", objCliente.sNumeroDoc);
                cmd.Parameters.AddWithValue("@Direccion", objCliente.sDireccion);
                cmd.Parameters.AddWithValue("@Distrito", objCliente.sDistrito);
                cmd.Parameters.AddWithValue("@Provincia", objCliente.sProvincia);
                cmd.Parameters.AddWithValue("@Departamento", objCliente.sDepartamento);
                cmd.Parameters.AddWithValue("@Ubigeo", objCliente.sUbigeo);
                cmd.Parameters.AddWithValue("@Celular", objCliente.sCelular);
                cmd.Parameters.AddWithValue("@Usuario", objCliente.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objCliente.bEstado);
                cmd.Parameters.AddWithValue("@ValidadoSunat", objCliente.bValidadoSunat);
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

        public static int EliminarActivarCliente(Cliente objCliente)
        {
            int respuesta = 0, tipo = 4;
            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;

            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Cliente", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdCliente", objCliente.nIdCliente);
                cmd.Parameters.AddWithValue("@Nombres", objCliente.sNombres);
                cmd.Parameters.AddWithValue("@TipoPersona", objCliente.bTipoPersona);
                cmd.Parameters.AddWithValue("@TipoDoc", objCliente.sTipoDoc);
                cmd.Parameters.AddWithValue("@NumDoc", objCliente.sNumeroDoc);
                cmd.Parameters.AddWithValue("@Direccion", objCliente.sDireccion);
                cmd.Parameters.AddWithValue("@Distrito", objCliente.sDistrito);
                cmd.Parameters.AddWithValue("@Provincia", objCliente.sProvincia);
                cmd.Parameters.AddWithValue("@Departamento", objCliente.sDepartamento);
                cmd.Parameters.AddWithValue("@Ubigeo", objCliente.sUbigeo);
                cmd.Parameters.AddWithValue("@Celular", objCliente.sCelular);
                cmd.Parameters.AddWithValue("@Usuario", objCliente.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objCliente.bEstado);
                cmd.Parameters.AddWithValue("@ValidadoSunat", objCliente.bValidadoSunat);
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
