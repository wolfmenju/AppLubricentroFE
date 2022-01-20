using Comun;
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

namespace AppInguiri
{
    public partial class FrmInventarioInicial : Form
    {
        private bool cerrarFormulario = true;
        private AlmacenNegocio objAlmNeg = new AlmacenNegocio();
        private InventarioNegocio objInventNeg = new InventarioNegocio();
        public FrmInventario frmInventario = null;

        public FrmInventarioInicial()
        {
            InitializeComponent();
        }

        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            if (dtFechaInicia.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("La fecha del inventario no puede ser menor a la fecha actual.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cerrarFormulario = false;
                return;
            }

            Inventario objInventario = new Inventario()
            {
                nTipo = 2,
                dFechaInicio = dtFechaInicia.Value,
                nIdAlmacen = (int)cboAlmacen.SelectedValue,
                sUsuario = Funciones.UsuarioActual()
            };

            int resp = 0;
            resp = objInventNeg.ActualizarInventario(objInventario);

            if (resp > 0)
            {
                MessageBox.Show("El inventario Se Logró Insertar Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmInventario.CargarInventario();
                cerrarFormulario = true;
            }
            else
            {
                MessageBox.Show("El inventario No Se Pudo Registrar Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cerrarFormulario = false;
            }

        }

        private void CmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmInventarioInicial_Load(object sender, EventArgs e)
        {
            lblCodigo.Text = "Autogenerado";
            lblCodigo.ForeColor = Color.Blue;

            List<Almacen> LisAlmacen = objAlmNeg.ListarAlmacen(true);

            if (LisAlmacen.Count > 0)
            {
                cboAlmacen.ValueMember = "nIdAlmacen";
                cboAlmacen.DisplayMember = "sDescripcion";
                cboAlmacen.DataSource = LisAlmacen;
            }   
        }

        private void FrmInventarioInicial_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;

            cerrarFormulario = true;
        }
    }
}
