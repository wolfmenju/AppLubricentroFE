using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Comun;

namespace AppInguiri
{
    public partial class FrmPermiso : Form
    {
        #region Variables Privadas
        private UsuarioNegocio objUserNeg = new UsuarioNegocio();
        private PermisoNegocio objPermisoNeg = new PermisoNegocio();
        private List<Permiso> listPermiso = new List<Permiso>();
        private bool estado = true;
        private static FrmPermiso frmInstance = null;
        //julio

        #endregion

        //Singleton
        public static FrmPermiso Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmPermiso();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        #region Principal Load

        public FrmPermiso()
        {
            InitializeComponent();
        }
        
        private void FrmPermiso_Load(object sender, EventArgs e)
        {
            CargarUsuario();
        }

        #endregion

        #region Eventos

        private void FrmPermiso_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    BtnAgregar_Click(sender, e);
                    break;
                case Keys.F2:
                    BtnQuitar_Click(sender, e);
                    break;
                case Keys.F3:
                    BtnRefrescar_Click(sender, e);
                    break;
                case Keys.F4:
                    BtnBuscar_Click(sender, e);
                    break;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }
        
        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            Quitar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            if (cboUsuario.Items.Count > 0)
                CargaPermiso(cboUsuario.SelectedValue.ToString());
            CargaMenu(cboUsuario.SelectedValue.ToString());
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Metodo Privados
        private void CargarUsuario()
        {
            List<Usuario> ListUser= objUserNeg.ListarUsuario(true);
            cboUsuario.DisplayMember = "sNombres";
            cboUsuario.ValueMember = "sLogin";
            cboUsuario.DataSource = ListUser;
            cboUsuario.SelectedIndex = -1;
        }


        private void CargaMenu(string sLogin)
        {
            listPermiso = objPermisoNeg.ListarPermiso(sLogin,2);
            DgvTodoPermiso.AutoGenerateColumns = false;
            DgvTodoPermiso.DataSource = listPermiso;
        }
        
        private void CargaPermiso(string sLogin)
        {
            List<Permiso> ListPermiso = objPermisoNeg.ListarPermiso(sLogin,1);
            DgvPermiso.AutoGenerateColumns = false;
            DgvPermiso.DataSource = ListPermiso;
        }

       
        private void Buscar()
        {
            if (DgvTodoPermiso.Rows.Count == 0) return;

            string permisoporBuscar = Interaction.InputBox("", "Buscar Permiso...");

            if (!permisoporBuscar.Equals(""))
            {
                List<Permiso> dt = new List<Permiso>();

                foreach (Permiso col in listPermiso)
                {

                    if (col.sDescripcion.Contains(permisoporBuscar.ToUpper()))
                    {
                        dt.Add(col);
                    }

                }
                if (dt.Count > 0)
                {
                    DgvTodoPermiso.DataSource = dt;
                }
                else
                {
                    DgvTodoPermiso.DataSource = null;
                }
            }
            else
            {
                DgvTodoPermiso.DataSource = listPermiso;
            }
        }

        private void Quitar()
        {
            if (DgvPermiso.Rows.Count == 0) return;
            int respuesta = 0;

            int nIdMenu = Convert.ToInt32(DgvPermiso.CurrentRow.Cells[1].Value.ToString());
            int nIdPermiso= Convert.ToInt32(DgvPermiso .CurrentRow.Cells[0].Value.ToString());
            string sUsuario = (string)cboUsuario.SelectedValue;

            Permiso objPermi = new Permiso()
            {
                nIdMenu = nIdMenu,
                sUsuario = sUsuario,
                nIdPermiso= nIdPermiso,
                bEstado = false
            };

            respuesta = objPermisoNeg.ActualizarPermiso(objPermi);

            if (respuesta > 0)
                CargaPermiso(sUsuario);
            CargaMenu(sUsuario);

        }
        //validar que solo se acepten letras en la descripcion
        private void Agregar()
        {
            if (DgvTodoPermiso.Rows.Count == 0) return;
            int respuesta = 0;

            int nIdMenu = Convert.ToInt32(DgvTodoPermiso.CurrentRow.Cells[0].Value.ToString());
            string sUsuario = (string)cboUsuario.SelectedValue;

            Permiso objPermi = new Permiso()
            {
                nIdMenu = nIdMenu,
                sUsuario = sUsuario,
                bEstado = true
            };

            respuesta = objPermisoNeg.ActualizarPermiso(objPermi);

            if (respuesta > 0)
                CargaPermiso(sUsuario);
            CargaMenu(sUsuario);

        }
        #endregion

        private void FrmPermiso_SizeChanged(object sender, EventArgs e)
        {
            Panel2.Width = 116;
            PanIzquierdo.Width = this.Width / 2 - 116 / 2;
            PanDerecho.Width = this.Width / 2 - 116 / 2;
            Panel2.Width = 116;
        }

        private void cboUsuario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboUsuario.Items.Count > 0)
                CargaPermiso(cboUsuario.SelectedValue.ToString());
             CargaMenu(cboUsuario.SelectedValue.ToString());
            
        }
        
    }
}
