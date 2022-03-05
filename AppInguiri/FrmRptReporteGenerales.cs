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
using AppInguiri.EntidadReporte;
using AppInguiri.Reporte;
using AppInguiri.ReporteFormulario;

namespace AppInguiri
{
    public partial class FrmRptReporteGenerales : DevExpress.XtraEditors.XtraForm
    {
        private static FrmRptReporteGenerales frmInstance = null;
        ParametroNegocio objParaNeg = new ParametroNegocio();
        private AlmacenNegocio objAlmNeg = new AlmacenNegocio();
        private ProveedorNegocio objProvNeg = new ProveedorNegocio();
        private CategoriaNegocio objCatNeg = new CategoriaNegocio();
        private ClienteNegocio objCliNeg = new ClienteNegocio();
        private List<Almacen> listAlm = new List<Almacen>();
        private List<Categoria> listCat= new List<Categoria>();
        private List<Proveedor> listProv = new List<Proveedor>();
        private List<Cliente> listCli = new List<Cliente>();
        
        private bool cerrarFormulario = true;

        //Singleton
        public static FrmRptReporteGenerales Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmRptReporteGenerales();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }


        public FrmRptReporteGenerales()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            cerrarFormulario = true;
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        private void GenerarReporte()
        {

            switch (cboDocumento.SelectedIndex)
            {
                case 0:
                    ReporteClientes();
                    break;
                case 1:
                    ReporteProveedores();
                    break;
                case 2:
                    ReporteLaboratorios();
                    break;
                case 3:
                    ReporteAlmacenes();
                    break;

            }
            
            cerrarFormulario = false;
        }

        private void ReporteClientes()
        {
            listCli.Clear();
            Cliente objCli = new Cliente() {bEstado=true,nTipo=1};
            listCli = objCliNeg.ListarCliente(objCli);

            if (listCli.Count < 1) return;

            List<ClienteRpt> lisClienteRpt = new List<ClienteRpt>();
            RptCliente rpt = new RptCliente();

            foreach (Cliente item in listCli)
            {
                ClienteRpt objProvRpt = new ClienteRpt();
                objProvRpt.sDni = item.sNumeroDoc;
                objProvRpt.sRazonSocial = item.sNombres;
                objProvRpt.sTelefono = item.sCelular;
                lisClienteRpt.Add(objProvRpt);
            }

            rpt.SetDataSource(lisClienteRpt);
            rpt.SetParameterValue("Usuario", Funciones.UsuarioActual());
            rpt.SetParameterValue("NombreEmpresa", objParaNeg.LeerUnParametro("ID_TITULO"));
            rpt.SetParameterValue("Nombres", Funciones.UsuarioActual());
            RptMaestro Reporte = new RptMaestro();
            Reporte.Show();
            Reporte.Text = "";//cboOpcion.Text;
            Reporte.Focus();
            Reporte.cReporte.ReportSource = rpt;
        }

        private void ReporteProveedores()
        {
            listProv.Clear();
            listProv = objProvNeg.ListarProveedor(true);

            if (listProv.Count < 1) return;

            List<ProveedorRpt> lisProveedorRpt = new List<ProveedorRpt>();
            RptProveedor rpt = new RptProveedor();

            foreach (Proveedor item in listProv)
            {
                ProveedorRpt objProvRpt = new ProveedorRpt();
                objProvRpt.sRuc = item.sRuc;
                objProvRpt.sRazonSocial = item.sRazonSocial;
                objProvRpt.sContacto = item.sContacto;
                objProvRpt.sTelefono = item.sCelular;
                lisProveedorRpt.Add(objProvRpt);
            }

            rpt.SetDataSource(lisProveedorRpt);
            rpt.SetParameterValue("Usuario", Funciones.UsuarioActual());
            rpt.SetParameterValue("NombreEmpresa", objParaNeg.LeerUnParametro("ID_TITULO"));
            rpt.SetParameterValue("Nombres", Funciones.UsuarioActual());
            RptMaestro Reporte = new RptMaestro();
            Reporte.Show();
            Reporte.Text = "";//cboOpcion.Text;
            Reporte.Focus();
            Reporte.cReporte.ReportSource = rpt;
        }

        private void ReporteLaboratorios()
        {
            listCat.Clear();
            listCat = objCatNeg.ListarCategoria(true);

            if (listCat.Count < 1) return;

            List<LaboratorioRpt> lisObjLabRpt = new List<LaboratorioRpt>();
            RptLaboratorio rpt = new RptLaboratorio();

            foreach (Categoria item in listCat)
            {
                LaboratorioRpt objLabRpt = new LaboratorioRpt();
                objLabRpt.sDescripcion = item.sDescripcion;
                objLabRpt.sCodigo = item.nIdCategoria.ToString();
                lisObjLabRpt.Add(objLabRpt);
            }

            rpt.SetDataSource(lisObjLabRpt);
            rpt.SetParameterValue("Usuario", Funciones.UsuarioActual());
            rpt.SetParameterValue("NombreEmpresa", objParaNeg.LeerUnParametro("ID_TITULO"));
            rpt.SetParameterValue("Nombres", Funciones.UsuarioActual());
            RptMaestro Reporte = new RptMaestro();
            Reporte.Show();
            Reporte.Text = "";//cboOpcion.Text;
            Reporte.Focus();
            Reporte.cReporte.ReportSource = rpt;
        }

        private void ReporteAlmacenes()
        {
            listAlm.Clear();
            listAlm = objAlmNeg.ListarAlmacen(true);
            
            if (listAlm.Count < 1) return;

            List<AlmacenRpt> lisAlmacenRpt = new List<AlmacenRpt>();
            RptAlmacen rpt = new RptAlmacen();

            foreach (Almacen item in listAlm)
            {
                AlmacenRpt objAlmacenRpt = new AlmacenRpt();
                objAlmacenRpt.sDescripcion = item.sDescripcion;
                objAlmacenRpt.sDireccion = item.sDireccion;
                lisAlmacenRpt.Add(objAlmacenRpt);
            }

            rpt.SetDataSource(lisAlmacenRpt);
            rpt.SetParameterValue("Usuario", Funciones.UsuarioActual());
            rpt.SetParameterValue("NombreEmpresa", objParaNeg.LeerUnParametro("ID_TITULO"));
            rpt.SetParameterValue("Nombres", Funciones.UsuarioActual());
            RptMaestro Reporte = new RptMaestro();
            Reporte.Show();
            Reporte.Text = "";//cboOpcion.Text;
            Reporte.Focus();
            Reporte.cReporte.ReportSource = rpt;
        }

        private void FrmRptReporteGenerales_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;

            cerrarFormulario = true;
        }

        private void FrmRptReporteGenerales_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void FrmRptReporteGenerales_Load(object sender, EventArgs e)
        {
            cboDocumento.SelectedIndex = 0;
        }
    }
}