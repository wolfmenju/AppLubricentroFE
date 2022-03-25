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
    public partial class FrmServicioActualiza : Form
    {
        private ServicioNegocio objServicNeg = new ServicioNegocio();
        private ProductoNegocio objProducNeg = new ProductoNegocio();
        public FrmServicio frmServicio = null;
        public int tipo = 0;
        private bool cerrarFormulario = true;
        private Servicio servicio = null;

        public FrmServicioActualiza(Servicio _servicio)
        {
            InitializeComponent();
            servicio = _servicio;
        }

        public FrmServicioActualiza()
        {
            InitializeComponent();
        }
        
        private bool Validar()
        {
            bool resp = true;

            if (txtDescripcion.Text.Equals(""))
            {
                MessageBox.Show("El campo Descripción se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (txtPrecio.Text.Equals(""))
            {
                MessageBox.Show("El campo Principio Activo se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }

            cerrarFormulario = resp;
            return resp;
        }

        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            int respuesta = 0;

            if (!Validar()) return;
            
            Servicio objServ = new Servicio()
            {
                nTipo=1,
                nSubTipo=2,
                sDescripcion = txtDescripcion.Text.ToUpper().Trim(),
                sCodigoInterno=lblCodigoInterno.Text,
                fPrecio =decimal.Round(Convert.ToDecimal(txtPrecio.Text),2),
                sUsuario = Funciones.UsuarioActual(),
                bEstado = true
            };

            if (tipo ==0)
            {
                if (!Funciones.Duplicados(txtDescripcion.Text, frmServicio.DgvServicio))
                {
                    txtDescripcion.Clear();
                    txtDescripcion.Focus();
                    cerrarFormulario = false;
                    return;
                }

                respuesta = objServicNeg.RegistrarServicio(objServ);

                if (respuesta == 1)
                {
                    MessageBox.Show("Se Registro Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cerrarFormulario = true;
                }
                else
                {
                    MessageBox.Show("No se Registro Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cerrarFormulario = false;
                }

            }
            else
            {
                objServ.nIdServicio = Convert.ToInt32(LblCodigo.Text);
                objServ.nTipo = 2;
                objServ.nSubTipo = 3;
                objServ.sDescripcion = txtDescripcion.Text.ToUpper();
                objServ.fPrecio = Convert.ToDecimal(txtPrecio.Text);

                respuesta = objServicNeg.ActualizarServicio(objServ);
                
                if (respuesta == 1)
                {
                    MessageBox.Show("Se Actualizó Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cerrarFormulario = true;
                }
                else
                {
                    MessageBox.Show("No se Actualizó Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cerrarFormulario = false;
                }

            }
        }

        private void FrmProveedorActualiza_Load(object sender, EventArgs e)
        {
            if (tipo == 0)
            {
                //LblCodigo.Text = "AUTOGENERADO";
                lblCodigoInterno.Text = GeneradaCodigo();

            }
            else
            {
                //Actualizar
                lblCodigoInterno.Text = servicio.sCodigoInterno.ToString();
                LblCodigo.Text = servicio.nIdServicio.ToString();
                txtDescripcion.Text = servicio.sDescripcion.ToUpper();
                txtPrecio.Text = servicio.fPrecio.ToString();
            }
        }

        private string GeneradaCodigo()
        {
            List<Producto> listProducto = new List<Producto>();
            Producto objProducto = new Producto() { bEstado = true, nTipo = 11 };
            listProducto = objProducNeg.ListarProducto(objProducto);
            int total = 0;
            total = listProducto[0].nIdProducto;

            if (total < 1)
                return "S0001";
            else
            {
                return "S" + (total + 1).ToString("0000");
            }
        }

        private void CmdCancelar_Click(object sender, EventArgs e)
        {
            cerrarFormulario = true;
            this.Close();
        }

        private void FrmProveedorActualiza_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarNumeroDecimal(e, txtPrecio);
        }
    }
}


