﻿using Entidad;
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
    public partial class FrmSede : Form
    {
        #region Variables Privadas
        private SedeNegocio objSedeNeg = new SedeNegocio();
        private List<Sede> listSede = new List<Sede>();
        private bool estado = true;
        private static FrmSede frmInstance = null;

        #endregion

        #region Principal Load

        //Singleton
        public static FrmSede Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmSede();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        public FrmSede()
        {
            InitializeComponent();
        }

        private void FrmPresentacion_Load(object sender, EventArgs e)
        {
            CargarSede();
        }
        #endregion

        #region Eventos
        private void FrmPresentacion_KeyDown(object sender, KeyEventArgs e)
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
            CargarSede();
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

            CargarSede();

        }
    
        #endregion

        #region Metodo Privados
        private void CargarSede()
        {
            listSede.Clear();
            listSede = objSedeNeg.ListarSede(estado);

            if (listSede.Count() > 0)
            {
                DgvSede.AutoGenerateColumns = false;
                DgvSede.DataSource = listSede;
                LblTotal.Text = "Se Encontraron " + DgvSede.Rows.Count + " Registros";
            }
            else
            {
                DgvSede.DataSource = null;
            }
        }
        private void Eliminar()
        {
            int respuesta = 0;

            if (DgvSede.RowCount > 0)
            {
                string msg = "";
                if (estado) { estado = false; msg = "Eliminar"; }
                else { estado = true; msg = "Activar"; }

                DialogResult res;
                res = MessageBox.Show("¿Desea " + msg + " el registro?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    int idSedeSele = Convert.ToInt32(DgvSede.CurrentRow.Cells[0].Value);

                    Sede objSede = new Sede()
                    {
                        nIdSede = idSedeSele,
                        sUsuario = Funciones.UsuarioActual(),
                        bEstado=estado
                    };

                    respuesta = objSedeNeg.EliminarActivarSede(objSede);

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
                        CargarSede();
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
                    MessageBox.Show("No se registran Presentación para eliminar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    MessageBox.Show("No se registran Presentación para Activar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Buscar()
        {
            if (DgvSede.Rows.Count == 0) return;

            string sedeporBuscar = Interaction.InputBox("", "Buscar Sede...");

            if (!sedeporBuscar.Equals(""))
            {
                List<Sede> dt = new List<Sede>();

                foreach (Sede col in listSede)
                {

                    if (col.sDescripcion.Contains(sedeporBuscar.ToUpper()))
                    {
                        dt.Add(col);
                    }

                }
                if (dt.Count > 0)
                {
                    DgvSede.DataSource = dt;
                }
                else
                {
                    DgvSede.DataSource = null;
                }
            }
            else
            {
                DgvSede.DataSource = listSede;
            }
        }

        private void Modificar()
        {
            if (DgvSede.Rows.Count == 0) return;

            int idSedeSele = Convert.ToInt32(DgvSede.CurrentRow.Cells[0].Value);
            string descSele = Convert.ToString(DgvSede.CurrentRow.Cells[1].Value);
            string direSele = Convert.ToString(DgvSede.CurrentRow.Cells[2].Value);

            FrmSedeActualiza frmSede = new FrmSedeActualiza();
            frmSede.tipo = 3;
            frmSede.idSede = idSedeSele;
            frmSede.descripcion = descSele;
            frmSede.direccion = direSele;
            frmSede.Text = "Actualizar Sede";
            frmSede.frmSede = this;

            if (frmSede.ShowDialog() == DialogResult.OK)
            {
                CargarSede();
            }
        }
        //validar que solo se acepten letras en la descripcion
        private void Agregar()
        {
            FrmSedeActualiza frmSede = new FrmSedeActualiza();
            //frmPresent.MdiParent = this.MdiParent;
            frmSede.tipo = 2;
            frmSede.frmSede = this;
            frmSede.Text = "Registar Sede";
       
            if (frmSede.ShowDialog() == DialogResult.OK)
            {
                CargarSede();
            }
        }
        #endregion
    }
}
