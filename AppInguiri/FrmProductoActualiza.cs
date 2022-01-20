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
    public partial class FrmProductoActualiza : Form
    {
        ProductoNegocio objProducNeg = new ProductoNegocio();
        CategoriaNegocio objCateNeg = new CategoriaNegocio();
        PresentacionNegocio objPreseNeg = new PresentacionNegocio();
        public FrmProducto frmProducto = null;

        public int tipo = 0;
        private bool cerrarFormulario = true;
        private Producto producto = null;

        public FrmProductoActualiza(Producto _producto)
        {
            InitializeComponent();
            producto = _producto;
            LLenarMaestro();
        }

        public FrmProductoActualiza()
        {
            InitializeComponent();
            LLenarMaestro();
        }

        private void LLenarMaestro()
        {
            List<Categoria> lisCat = objCateNeg.ListarCategoria(true);
            cbxLaboratorio.ValueMember = "nIdCategoria";
            cbxLaboratorio.DisplayMember = "sDescripcion";
            cbxLaboratorio.DataSource = lisCat;
            
            List<Presentacion> lisPrese = objPreseNeg.ListarPresentacion(true);
            cbxPresentacion.ValueMember = "nIdPresentacion";
            cbxPresentacion.DisplayMember = "sDescripcion";
            cbxPresentacion.DataSource = lisPrese;

            if (producto != null)
            {
                for (int i = 0; i < lisCat.Count; i++)
                {
                    if (lisCat[i].nIdCategoria == producto.nIdLaboratorio)
                    {
                        cbxLaboratorio.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < lisPrese.Count; i++)
                {
                    if (lisPrese[i].nIdPresentacion == producto.nIdPresentacion)
                    {
                        cbxPresentacion.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private bool Validar()
        {
            bool resp = true;

            if (txtDescripcion.Text.Equals(""))
            {
                MessageBox.Show("El campo Descripción se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (txtPrincipioActivo.Text.Equals(""))
            {
                MessageBox.Show("El campo Principio Activo se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }

            else if (cbxLaboratorio.Text.Equals(""))
            {
                MessageBox.Show("El campo Laboratorio se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (cbxPresentacion.Text.Equals(""))
            {
                MessageBox.Show("El campo Presentacion se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (NdMinimo.Equals("0"))
            {
                MessageBox.Show("El campo Stock Minimo no debe ser cero, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }

            cerrarFormulario = resp;
            return resp;
        }

        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            int respuesta = 0;

            if (Validar())
            { }
            else { return; }

            Producto objProduc = new Producto()
            {
                sDescripcion = txtDescripcion.Text.ToUpper().Trim(),
                sCodigoInterno=lblCodigoInterno.Text,
                bAlternativo = ChkAlternativo.Checked,
                sPrincipioActivo = txtPrincipioActivo.Text.ToUpper().Trim(),
                nIdLaboratorio = (int)cbxLaboratorio.SelectedValue,
                nIdPresentacion = (int)cbxPresentacion.SelectedValue,
                sUsuario = Funciones.UsuarioActual(),
                nStockMinimo=Convert.ToInt32(NdMinimo.Value),
                bEstado = true
            };

            if (tipo ==0)
            {
                respuesta = objProducNeg.RegistrarProducto(objProduc);

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
                objProduc.nIdProducto = Convert.ToInt32(LblCodigo.Text);

                respuesta = objProducNeg.ActualizarProducto(objProduc);

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
                lblCodigoInterno.Text = producto.sCodigoInterno.ToString();
                LblCodigo.Text = producto.nIdProducto.ToString();
                txtDescripcion.Text = producto.sDescripcion.ToUpper();
                txtPrincipioActivo.Text = producto.sPrincipioActivo.ToUpper();
                ChkAlternativo.Checked = producto.bAlternativo;
                NdMinimo.Text =  producto.nStockMinimo.ToString();
            }
        }

        private string GeneradaCodigo()
        {
            List<Producto> listProducto = new List<Producto>();
            List<Producto> listProducto2 = new List<Producto>();
            Producto objProducto = new Producto() { bEstado = true, nTipo=1 };
            listProducto = objProducNeg.ListarProducto(objProducto);
            objProducto.bEstado = false;
            listProducto2 = objProducNeg.ListarProducto(objProducto);
            int total = 0;
            total = listProducto.Count + listProducto2.Count;
            
            if (total < 1)
                return "P0001";
            else
            {
                return "P" + (total + 1).ToString("0000");
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
    }
}


