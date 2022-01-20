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
    public class ParametrosData
    {
        //Listar Varios
        public static List<Parametro> ListarParametro(Parametro objPara)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            SqlConnection cnx = null;

            List<Parametro> listParametro = new List<Parametro>();
            try
            {
                Conexion cn = new Conexion();
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Parametro", cnx);
                cmd.Parameters.AddWithValue("@Tipo", objPara.nTipo);
                cmd.Parameters.AddWithValue("@IdParametro", objPara.nIdParametro);
                cmd.Parameters.AddWithValue("@Clave", objPara.sClave);
                cmd.Parameters.AddWithValue("@Valor", objPara.sValor);
                cmd.Parameters.AddWithValue("@Descripcion", objPara.sDescripcion);
                cmd.Parameters.AddWithValue("@Usuario", objPara.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objPara.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Parametro objParametro = new Parametro();

                    if (objPara.nTipo == 5)
                    {
                        objParametro.sValor = dr[0].ToString();
                    }
                    else
                    {
                        objParametro.nIdParametro = int.Parse(dr[0].ToString());
                        objParametro.sClave = dr[1].ToString();
                        objParametro.sValor = dr[2].ToString();
                        objParametro.sDescripcion = dr[3].ToString();
                    }
                    
                    listParametro.Add(objParametro);
                }
              
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

            return listParametro;
        }
        
        //Actualizar
        public static int ActualizarParametro(Parametro objPara)
        {
            int respuesta = 0, tipo = 3 ;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;
            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Parametro", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdParametro", objPara.nIdParametro);
                cmd.Parameters.AddWithValue("@Clave", objPara.sClave);
                cmd.Parameters.AddWithValue("@Valor", objPara.sValor);
                cmd.Parameters.AddWithValue("@Descripcion", objPara.sDescripcion);
                cmd.Parameters.AddWithValue("@Usuario", objPara.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objPara.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                respuesta= cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"InguiriSoft",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {
                cnx.Close();
                cnx.Dispose();
            }

            return respuesta;
        }

        //Registrar
        public static int RegistrarParametro(Parametro objPara)
        {
            int respuesta = 0, tipo = 2;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;

            try
            {
                cnx= new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Parametro", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdParametro", objPara.nIdParametro);
                cmd.Parameters.AddWithValue("@Clave", objPara.sClave);
                cmd.Parameters.AddWithValue("@Valor", objPara.sValor);
                cmd.Parameters.AddWithValue("@Descripcion", objPara.sDescripcion);
                cmd.Parameters.AddWithValue("@Usuario", objPara.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objPara.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                respuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                respuesta = 2;
                MessageBox.Show(ex.Message, "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                cnx.Close();
                cnx.Dispose();
            }

            return respuesta;
        }

        //Eliminar
        public static int EliminarActivarParametro(Parametro objPara)
        {
            int respuesta = 0, tipo=4;
            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;
            
            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Parametro", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdParametro", objPara.nIdParametro);
                cmd.Parameters.AddWithValue("@Clave", objPara.sClave);
                cmd.Parameters.AddWithValue("@Valor", objPara.sValor);
                cmd.Parameters.AddWithValue("@Descripcion", objPara.sDescripcion);
                cmd.Parameters.AddWithValue("@Usuario", objPara.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objPara.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                respuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                respuesta = 2;
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
