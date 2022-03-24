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
    public partial class FrmParametro : Form
    {
        #region Variables Privadas
        private ParametroNegocio objParametNeg = new ParametroNegocio();
        private List<Parametro> listParamet = new List<Parametro>();
        private bool estado = true;
        private static FrmParametro frmInstance = null;
        public FrmPrincipal frmPrincipal = null;

        #endregion

        #region Principal Load

        //Singleton
        public static FrmParametro Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmParametro();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        public FrmParametro()
        {
            InitializeComponent();
        }
        
        private void FrmParametro_Load(object sender, EventArgs e)
        {
            CargarParametros();
        }

        #endregion

        private void FrmParametro_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    BtnAgregar_Click(sender, e);
                    break;
                case Keys.F2:
                    BtnModificar_Click(sender, e);
                    break;
                case Keys.F3:
                    BtnRefrescar_Click(sender, e);
                    break;
                case Keys.F4:
                    BtnBuscar_Click(sender, e);
                    break;
                case Keys.F5:
                    BtnEliminar_Click(sender, e);
                    break;
            }
        }

        #region Eventos

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            CargarParametros();
        }
        
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChkTodos_CheckedChanged(object sender, EventArgs e)
        {
            estado = ChkTodos.Checked;

            if (ChkTodos.Checked)
            {
                BtnEliminar.Image = Properties.Resources.X;
                BtnEliminar.Text = "&Eliminar  [F5]";
            }
            else
            {
                BtnEliminar.Image = Properties.Resources.xActivar;
                BtnEliminar.Text = "&Activar  [F5]";
            }

            CargarParametros();

        }
    
        #endregion

        #region Metodo Privados
        private void CargarParametros()
        {
            listParamet.Clear();

            Parametro objPara = new Parametro()
            {
                nTipo=1,
                bEstado=estado
            };
            
            listParamet = objParametNeg.ListarParametro(objPara);

            if (listParamet.Count() > 0)
            {
                DgvParametros.AutoGenerateColumns = false;
                DgvParametros.DataSource = listParamet;
                LblTotal.Text = "Se Encontraron " + DgvParametros.Rows.Count + " Registros";
            }
            else
            {
                DgvParametros.DataSource = null;
            }
        }
        private void Eliminar()
        {
            int respuesta = 0;

            if (DgvParametros.RowCount > 0)
            {
                string msg = "";
                if (estado) { estado = false; msg = "Eliminar"; }
                else { estado = true; msg = "Activar"; }

                DialogResult res;
                res = MessageBox.Show("¿Desea " + msg + " el registro?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    int idParaSele =Convert.ToInt32(DgvParametros.CurrentRow.Cells[0].Value.ToString());

                    Parametro objDoc= new Parametro()
                    {
                        nIdParametro = idParaSele,
                        bEstado = estado,
                        sUsuario = Funciones.UsuarioActual()
                    };
                    
                    respuesta = objParametNeg.EliminarActivarParametro(objDoc);

                    if (respuesta == 1)
                    {
                        if (estado)
                        {
                            estado = false;
                            MessageBox.Show("Se Activó Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            estado = true;
                            MessageBox.Show("Se Eliminó Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        CargarParametros();
                    }
                }
                else
                {
                    if (estado) { estado = false; }
                    else { estado = true; }
                }
            }
            else
            {
                if (estado)
                {
                    MessageBox.Show("No se registran Documento para eliminar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    MessageBox.Show("No se registran Documento para Activar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Buscar()
        {
            if (DgvParametros.Rows.Count == 0) return;

            string documentoserieporBuscar = Interaction.InputBox("", "Buscar Parametros...");

            if (!documentoserieporBuscar.Equals(""))
            {
                List<Parametro> dt = new List<Parametro>();

                foreach (Parametro col in listParamet)
                {

                    if (col.sDescripcion.Contains(documentoserieporBuscar.ToUpper()))
                    {
                        dt.Add(col);
                    }

                }
                if (dt.Count > 0)
                {
                    DgvParametros.DataSource = dt;
                }
                else
                {
                    DgvParametros.DataSource = null;
                }
            }
            else
            {
                DgvParametros.DataSource = listParamet;
            }
        }

        private void Modificar()
        {
            if (DgvParametros.Rows.Count == 0) return;

            string idDocSele = DgvParametros.CurrentRow.Cells[0].Value.ToString();
            string descSele = Convert.ToString(DgvParametros.CurrentRow.Cells[1].Value);
            string abreSele = Convert.ToString(DgvParametros.CurrentRow.Cells[2].Value);
            
            Int32 filaselecionada = DgvParametros.CurrentCell.RowIndex;
            DataGridViewRow row2 = DgvParametros.Rows[filaselecionada];
            Parametro objParame = (Parametro)row2.DataBoundItem;

            FrmParametroActualiza frmParame = new FrmParametroActualiza(objParame);
            //frmPresent.MdiParent = this.MdiParent;
            frmParame.tipo = 3;
            frmParame.Text = "Actualizar Parametro";
            frmParame.frmPrincipal = frmPrincipal;
            frmParame.frmParametro = this;

            if (frmParame.ShowDialog() == DialogResult.OK)
            {
                CargarParametros();
            }

        }
        //validar que solo se acepten letras en la descripcion
        private void Agregar()
        {
            FrmParametroActualiza frmParametro = new FrmParametroActualiza();
            //frmPresent.MdiParent = this.MdiParent;
            frmParametro.tipo = 2;
            frmParametro.Text = "Registrar Parametro";
            frmParametro.frmParametro = this;

            if (frmParametro.ShowDialog() == DialogResult.OK)
            {
                CargarParametros();
            }
        }
        #endregion
        
    }
}
