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
    public class DocumentoSerieData
    {
        //Listar Varios
        public static List<DocumentoSerie> ListarDocumentoSerie(DocumentoSerie objDocSerie)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            SqlConnection cnx = null;

            List<DocumentoSerie> listDocumento = new List<DocumentoSerie>();
            try
            {
                Conexion cn = new Conexion();
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_DocumentoSerie", cnx);
                cmd.Parameters.AddWithValue("@Tipo", objDocSerie.nTipo);
                cmd.Parameters.AddWithValue("@IdDocumentoSerie", objDocSerie.nIdDocumentoSerie);
                cmd.Parameters.AddWithValue("@IdDocumento", objDocSerie.sIdDocumento);
                cmd.Parameters.AddWithValue("@Serie", "");
                cmd.Parameters.AddWithValue("@Ultimo", "");
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Estado", objDocSerie.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DocumentoSerie objDocument = new DocumentoSerie();

                    if (objDocSerie.nTipo == 5)
                    {
                        objDocument.sSerie = dr[0].ToString();
                        objDocument.nUltimo = Convert.ToInt32(dr[1]);
                    }
                    else
                    {
                        objDocument.nIdDocumentoSerie = Convert.ToInt32(dr[0].ToString());
                        objDocument.sIdDocumento = dr[1].ToString();
                        objDocument.sDescripcion = dr[2].ToString();
                        objDocument.sSerie = dr[3].ToString();
                        objDocument.nUltimo = Convert.ToInt32(dr[4].ToString());
                    }
                  
                    listDocumento.Add(objDocument);

                }
                return listDocumento;
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
        public static int ActualizarDocumentoSerie(DocumentoSerie objDocumt)
        {
            int respuesta = 0, tipo = 3 ;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;

            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_DocumentoSerie", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdDocumentoSerie", objDocumt.nIdDocumentoSerie);
                cmd.Parameters.AddWithValue("@IdDocumento", objDocumt.sIdDocumento);
                cmd.Parameters.AddWithValue("@Serie", objDocumt.sSerie);
                cmd.Parameters.AddWithValue("@Ultimo", objDocumt.nUltimo);
                cmd.Parameters.AddWithValue("@Usuario", objDocumt.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objDocumt.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                respuesta= cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                respuesta = 2;
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
        public static int RegistrarDocumentoSerie(DocumentoSerie objDocumt)
        {
            int respuesta = 0, tipo = 2;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = null;

            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_DocumentoSerie", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdDocumentoSerie", objDocumt.nIdDocumentoSerie);
                cmd.Parameters.AddWithValue("@IdDocumento", objDocumt.sIdDocumento);
                cmd.Parameters.AddWithValue("@Serie", objDocumt.sSerie);
                cmd.Parameters.AddWithValue("@Ultimo", objDocumt.nUltimo);
                cmd.Parameters.AddWithValue("@Usuario", objDocumt.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objDocumt.bEstado);
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
        public static int EliminarActivarDocumentoSerie(DocumentoSerie objDocumt)
        {
            int respuesta = 0, tipo=4;
            SqlCommand cmd = null;
            SqlConnection cnx = null;
            Conexion cn = new Conexion();

            try
            {
                cnx = new SqlConnection();
                cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_DocumentoSerie", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdDocumentoSerie", objDocumt.nIdDocumentoSerie);
                cmd.Parameters.AddWithValue("@IdDocumento", objDocumt.sIdDocumento);
                cmd.Parameters.AddWithValue("@Serie", objDocumt.sSerie);
                cmd.Parameters.AddWithValue("@Ultimo", objDocumt.nUltimo);
                cmd.Parameters.AddWithValue("@Usuario", objDocumt.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objDocumt.bEstado);
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
