using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Entidad;
using Negocio;
using Microsoft.VisualBasic;
using Comun;
using NPOI.HSSF.UserModel;
using System.IO;

namespace AppInguiri
{
    public partial class FrmCliente : DevExpress.XtraEditors.XtraForm
    {
        private static FrmCliente frmInstance = null;
        ClienteNegocio objClienNeg = new ClienteNegocio();
        List<Cliente> listCliente = new List<Cliente>();
        bool estado = true;

        //Singleton
        public static FrmCliente Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmCliente();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }


        public FrmCliente()
        {
            InitializeComponent();
        }

        #region Principal Load
        
        private void FrmCliente_Load(object sender, EventArgs e)
        {
            CargarCliente();
        }

        #endregion


        #region Metodo Privados
        private void CargarCliente()
        {
            listCliente.Clear();
            Cliente objCliente = new Cliente() {nTipo=1, bEstado=estado };
            listCliente = objClienNeg.ListarCliente(objCliente);

            if (listCliente.Count() > 0)
            {
                DgvCliente.AutoGenerateColumns = false;
                DgvCliente.DataSource = listCliente;
                LblTotal.Text = "Se Encontraron " + DgvCliente.Rows.Count + " Registros";
            }
            else
            {
                DgvCliente.DataSource = null;
            }

        }

        #endregion

        private void FrmCliente_KeyDown(object sender, KeyEventArgs e)
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

        private void Agregar()
        {
            FrmClienteActualiza frmCliente = new FrmClienteActualiza();
            frmCliente.Text = "Registar Cliente";

            if (frmCliente.ShowDialog() == DialogResult.OK)
            {
                CargarCliente();
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void Modificar()
        {
            if (DgvCliente.Rows.Count == 0) return;

            if (DgvCliente.CurrentCell != null || DgvCliente.CurrentCell.RowIndex != 0)
            {
                Int32 filaselecionada = DgvCliente.CurrentCell.RowIndex;
                DataGridViewRow row2 = DgvCliente.Rows[filaselecionada];
                Cliente cliente = (Cliente)row2.DataBoundItem;
                Cliente Rescliente = objClienNeg.LeerCliente(cliente.nIdCliente);
                FrmClienteActualiza frmCliente = new FrmClienteActualiza(Rescliente);
                frmCliente.tipo = 1;
                frmCliente.Text = "Actualizar Cliente";

                if (frmCliente.ShowDialog() == DialogResult.OK)
                {
                    CargarCliente();
                }
            }
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            CargarCliente();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            if (DgvCliente.Rows.Count == 0) return;

            string clienteporiaBuscar = Interaction.InputBox("", "Buscar Cliente...");

            if (!clienteporiaBuscar.Equals(""))
            {
                List<Cliente> dt = new List<Cliente>();
                foreach (Cliente col in listCliente)
                {

                    if (col.sNombres.Contains(clienteporiaBuscar.ToUpper()))
                    {
                        dt.Add(col);
                    }

                }
                if (dt.Count > 0)
                {
                    DgvCliente.DataSource = dt;
                }
                else
                {
                    DgvCliente.DataSource = null;
                }
            }
            else
            {
                DgvCliente.DataSource = listCliente;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar()
        {
            int respuesta = 0;

            if (DgvCliente.RowCount > 0)
            {
                string msg = "";
                if (estado) { estado = false; msg = "Eliminar"; }
                else { estado = true; msg = "Activar"; }

                DialogResult res;
                res = MessageBox.Show("¿Desea " + msg + " el registro?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    int idClienteSele = Convert.ToInt32(DgvCliente.CurrentRow.Cells[0].Value);

                    Cliente objClien = new Cliente()
                    {
                        nTipo=4,
                        nIdCliente = idClienteSele,
                        bEstado = estado,
                        sUsuario = Funciones.UsuarioActual()
                    };

                    respuesta = objClienNeg.EliminarActivarCliente(objClien);

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

                        CargarCliente();
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
                    MessageBox.Show("No se registran Clientes para eliminar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    MessageBox.Show("No se registran Clientes para Activar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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

            CargarCliente();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DgvCliente.Rows.Count != 0)
            {
                MessageBox.Show("Se exportarán sus datos a Excel, por favor espere", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HSSFWorkbook libro = new HSSFWorkbook();
                HSSFSheet hoja = (HSSFSheet)libro.CreateSheet("RptImprimePAGOS");
                HSSFRow fila = (HSSFRow)hoja.CreateRow(0);

                for (int i = 0; i < DgvCliente.Columns.Count; i++)
                {
                    if (DgvCliente.Columns[i].Visible)
                    {
                        fila.CreateCell(i).SetCellValue(DgvCliente.Columns[i].HeaderText);
                    }
                    else
                    {
                        hoja.SetColumnHidden(i, true);
                    }
                }

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                double nImporte = 0.00;

                for (int i = 0; i < DgvCliente.Rows.Count; i++)
                {
                    fila = (HSSFRow)hoja.CreateRow(i + 1);
                    for (int j = 0; j < (DgvCliente.Columns.Count); j++)
                    {
                        if (DgvCliente.Columns[j].Visible)
                        {
                            fila.CreateCell(j).SetCellValue(DgvCliente.Rows[i].Cells[j].Value == null ? "" : DgvCliente.Rows[i].Cells[j].Value.ToString());
                        }
                    }
                }


                for (int i = 0; i < DgvCliente.Columns.Count; i++)
                {
                    hoja.AutoSizeColumn(i);
                    hoja.HorizontallyCenter = true;
                }

                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(fichero.FileName, FileMode.OpenOrCreate);
                    libro.Write(fs);
                    fs.Close();

                    MessageBox.Show("Se Exportó Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay data que Exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

    }
}