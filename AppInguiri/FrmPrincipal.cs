using System;
using System.Collections.Generic;
using DevExpress.XtraBars;
using Entidad;
using Negocio;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;

namespace AppInguiri
{
   
    public partial class FrmPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        #region Variables de Formularios
        FrmPermiso frmPermiso = null;
        FrmPresentacion frmPresentacion = null;
        FrmProveedor frmProveedor = null;
        FrmUsuario frmUsuario = null;
        FrmCategoria frmCategoria = null;
        FrmSede frmSede = null;
        FrmAlmacen frmAlmacen = null;
        FrmDocumento frmDocumento = null;
        FrmDocumentoSerie frmDocumentoSerie = null;
        FrmParametro frmParametro = null;
        FrmCliente frmCliente = null;
        FrmProducto frmProducto = null;
        FrmCompra frmCompra = null;
        FrmVenta frmVenta = null;
        FrmActualizarPrecio frmActualizarPrecio = null;
        FrmRptLoteProductoPorVencer frmRptLoteProductoPorVencer = null;
        FrmRptProductoVendido frmRptProductoVendido = null;
        FrmRptCompras frmRptCompras = null;
        FrmRptVentas frmRptVentas = null;
        FrmCerrarCaja frmCerrarCaja = null;
        FrmRptSockMinimo frmRptSockMinimo = null;
        FrmDeudasPorPagar frmDeudasPorPagar = null;
        FrmInventario frmInventario = null;
        FrmRptCajaChica frmRptCajaChica = null;
        FrmRptHistorialPrecio frmRptHistorialPrecio = null;
        FrmRptUtilidades frmRptUtilidades = null;
        FrmRptProductoStock frmRptProductoStock = null;
        FrmRptKardex frmRptKardex = null;
        FrmAjusteStock frmDevuelve = null;
        FrmRptDeudaPorVencer frmRptDeudaPorVencer = null;
        FrmRptReporteGenerales frmRptReporteGenerales = null;
        FrmRptProductos frmRptProductos = null;
        FrmVentaEstadisticas frmVentaEstadisticas = null;
        List<Form> ListaFormu = new List<Form>();
        
        #endregion

        List<Permiso> listPerm = new List<Permiso>();
        PermisoNegocio objPermNeg = new PermisoNegocio();
        CajaNegocio objCajNeg = new CajaNegocio();

        public FrmLogin frmLogin = null;
        public bool bloqueado = false;
        private LASTINPUTINFO INPUT = new LASTINPUTINFO();
        int _VidaUtil = 0;
        
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            _VidaUtil = Convert.ToInt32(ConfigurationManager.AppSettings["VidaUtil"]);
            INPUT.cbSize = Marshal.SizeOf(INPUT);

            if (VerCaja())
            {
                HabilitarMenu(false);
                ValidarPermisosUsuario();
                RibbonControl.Minimized = false;
            }
            else
            {
                RibbonControl.Minimized = true;
                FrmCaja frmCaja = new FrmCaja();
                frmCaja.frmPrincipal = this;
                frmCaja.ShowDialog();
                frmCaja.Focus();
            }
        }
        
        private bool VerCaja()
        {
            Caja objCaja = new Caja();
            objCaja.nTipo = 8;
            bool VerCaja = false;
            
            objCaja.nIdCaja = objCajNeg.ValidarCaja(objCaja);

            if (objCaja.nIdCaja > 0) VerCaja = true;
            else VerCaja = false;
            
            return VerCaja;
        }
        
        public void ValidarPermisosUsuario()
        {
            listPerm = objPermNeg.ListarPermiso(CodUsuario.Caption,1);

            if (listPerm.Count == 0) return;

            foreach (var elemento in Ribbon.Items)
            {
                var TipoElemento = elemento.GetType();

                if (TipoElemento.FullName == "DevExpress.XtraBars.BarButtonItem")
                {
                    BarButtonItem barButton = (BarButtonItem)elemento;

                    if (barButton.Tag != null)
                    {
                        foreach (var permiso in listPerm)
                        {
                            if (Convert.ToInt32(barButton.Tag) == permiso.nTag)
                            {
                                barButton.Enabled = true;
                                break;
                            }
                            else
                            {
                                barButton.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        barButton.Enabled = true;
                    }
                }
            }
        }

        public void HabilitarMenu(bool bHabilitar)
        {
            foreach (var elemento in Ribbon.Items)
            {
                var TipoElemento = elemento.GetType();

                if (TipoElemento.FullName == "DevExpress.XtraBars.BarButtonItem")
                {
                    BarButtonItem barButton = (BarButtonItem)elemento;
                    if (bHabilitar)
                        barButton.Enabled = true;
                    barButton.Enabled = false;
                }
            }
        }

        private void VerificarFormulario(Form frm)
        {
            List<Form> dd = new List<Form>();
            foreach (var item in ListaFormu) { if (item.Name == frm.Name) dd.Add(item); }
            if (dd.Count == 0) ListaFormu.Add(frm);
        }

        private void ValidarFormularioActivos()
        {
            List<Form> ListaFormu2 = new List<Form>();

            foreach (var elemento in ListaFormu)
            {
                if (((elemento == null) || (elemento.IsDisposed == true)))
                {
                    ListaFormu2.Add(elemento);
                    pbLogoInguiri.Visible = true;
                }
                else pbLogoInguiri.Visible = false;

                break;
            }

            if (ListaFormu2.Count > 0) ListaFormu.Remove(ListaFormu2[0]);
            if (ListaFormu.Count == 0) pbLogoInguiri.Visible = true;
        }

        private void barBtnPresentacion_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmPresentacion = FrmPresentacion.Instance();
            frmPresentacion.MdiParent = this;
            frmPresentacion.Show();
            VerificarFormulario(frmPresentacion);
        }

        private void barBtnProveedor_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmProveedor = FrmProveedor.Instance();
            frmProveedor.MdiParent = this;
            frmProveedor.Show();
            VerificarFormulario(frmProveedor);

        }

        private void barBtnUsuario_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmUsuario = FrmUsuario.Instance();
            frmUsuario.MdiParent = this;
            frmUsuario.Show();
            VerificarFormulario(frmUsuario);
        }

        private void barBtnCategoria_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmCategoria = FrmCategoria.Instance();
            frmCategoria.MdiParent = this;
            frmCategoria.Show();
            VerificarFormulario(frmCategoria);
        }

        private void barBtnSede_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmSede = FrmSede.Instance();
            frmSede.MdiParent = this;
            frmSede.Show();
            VerificarFormulario(frmSede);
        }

        private void barBtnAlmacen_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmAlmacen = FrmAlmacen.Instance();
            frmAlmacen.MdiParent = this;
            frmAlmacen.Show();
            VerificarFormulario(frmAlmacen);
        }

        private void barBtnDocumentos_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmDocumento = FrmDocumento.Instance();
            frmDocumento.MdiParent = this;
            frmDocumento.Show();
            VerificarFormulario(frmDocumento);
        }

        private void barBtnDocumentosSerie_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmDocumentoSerie = FrmDocumentoSerie.Instance();
            frmDocumentoSerie.MdiParent = this;
            frmDocumentoSerie.Show();
            VerificarFormulario(frmDocumentoSerie);
        }
        
        private void barBtnParametros_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            pbLogoInguiri.Visible = false;
            frmParametro = FrmParametro.Instance();
            frmParametro.frmPrincipal = this;
            frmParametro.MdiParent = this;
            frmParametro.Show();
            VerificarFormulario(frmParametro);
        }

        private void barBtnCambiarClave_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCambiarClave frmCamb = new FrmCambiarClave();
            frmCamb.sLogin = this.CodUsuario.Caption;
            frmCamb.sNombreUser =this.NomUsuario.Caption;
            frmCamb.ShowDialog();
        }
        
        private void barBtnPermisos_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmPermiso = FrmPermiso.Instance();
            frmPermiso.MdiParent = this;
            frmPermiso.Show();
            VerificarFormulario(frmPermiso);
        }

        private void barBtnCliente_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmCliente = FrmCliente.Instance();
            frmCliente.MdiParent = this;
            frmCliente.Show();
            VerificarFormulario(frmCliente);
        }

        private void barBtnProducto_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmProducto = FrmProducto.Instance();
            frmProducto.MdiParent = this;
            frmProducto.Show();
            VerificarFormulario(frmProducto);
        }

        private void barBtnCompra_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmCompra = FrmCompra.Instance();
            frmCompra.MdiParent = this;
            frmCompra.Show();
            VerificarFormulario(frmCompra);
        }

        private void barBtnVenta_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmVenta = FrmVenta.Instance();
            frmVenta.MdiParent = this;
            frmVenta.Show();
            VerificarFormulario(frmVenta);
        }

        private void barBtnProductoVendido_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmRptProductoVendido = FrmRptProductoVendido.Instance();
            frmRptProductoVendido.MdiParent = this;
            frmRptProductoVendido.Show();
            VerificarFormulario(frmRptProductoVendido);
        }

        private void barBtnActualizarPrecio_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmActualizarPrecio = FrmActualizarPrecio.Instance();
            frmActualizarPrecio.MdiParent = this;
            frmActualizarPrecio.Show();
            VerificarFormulario(frmActualizarPrecio);
        }

        private void barBtnLoteProductoPorVencer_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmRptLoteProductoPorVencer = FrmRptLoteProductoPorVencer.Instance();
            frmRptLoteProductoPorVencer.MdiParent = this;
            frmRptLoteProductoPorVencer.Show();
            VerificarFormulario(frmRptLoteProductoPorVencer);
        }

        private void barBtnCerrarCaja_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCerrarCaja = FrmCerrarCaja.Instance();
            frmCerrarCaja.frmPrincipal = this;
            frmCerrarCaja.ShowDialog();
        }

        private void barBtnReporteCompra_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmRptCompras = FrmRptCompras.Instance();
            frmRptCompras.MdiParent = this;
            frmRptCompras.Show();
            VerificarFormulario(frmRptCompras);
        }

        private void barBtnReporteVenta_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRptVentas = FrmRptVentas.Instance();
            frmRptVentas.ShowDialog();
        }

        private void barBtnStockMinimo_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmRptSockMinimo = FrmRptSockMinimo.Instance();
            frmRptSockMinimo.MdiParent = this;
            frmRptSockMinimo.Show();
            VerificarFormulario(frmRptSockMinimo);
        }

        private void barBtnCuentasPorPagar_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmDeudasPorPagar = FrmDeudasPorPagar.Instance();
            frmDeudasPorPagar.MdiParent = this;
            frmDeudasPorPagar.Show();
            VerificarFormulario(frmDeudasPorPagar);
        }

        private void barBtnIventario_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmInventario = FrmInventario.Instance();
            frmInventario.MdiParent = this;
            frmInventario.Show();
            VerificarFormulario(frmInventario);
        }
        
        private void barBtnRptCajaChica_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmRptCajaChica = FrmRptCajaChica.Instance();
            frmRptCajaChica.MdiParent = this;
            frmRptCajaChica.Show();
            VerificarFormulario(frmRptCajaChica);
        }

        private void barBtnRptHistorialPrecio_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmRptHistorialPrecio = FrmRptHistorialPrecio.Instance();
            frmRptHistorialPrecio.MdiParent = this;
            frmRptHistorialPrecio.Show();
            VerificarFormulario(frmRptHistorialPrecio);
        }

        private void barBtnUtilidadesProducto_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmRptUtilidades = FrmRptUtilidades.Instance();
            frmRptUtilidades.MdiParent = this;
            frmRptUtilidades.Show();
            VerificarFormulario(frmRptUtilidades);
        }
        
        private void barBtnConsultaStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmRptProductoStock = FrmRptProductoStock.Instance();
            frmRptProductoStock.MdiParent = this;
            frmRptProductoStock.Show();
            VerificarFormulario(frmRptProductoStock);
        }

        private void barBtnKardex_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmRptKardex = FrmRptKardex.Instance();
            frmRptKardex.MdiParent = this;
            frmRptKardex.Show();
            VerificarFormulario(frmRptKardex);
        }
        
        private void barBtnDevuelveProducto_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmDevuelve = FrmAjusteStock.Instance();
            frmDevuelve.MdiParent = this;
            frmDevuelve.Show();
            VerificarFormulario(frmDevuelve);
        }

        private void barBtnDeudasPorVencer_ItemClick(object sender, ItemClickEventArgs e)
        {
            pbLogoInguiri.Visible = false;
            frmRptDeudaPorVencer = FrmRptDeudaPorVencer.Instance();
            frmRptDeudaPorVencer.MdiParent = this;
            frmRptDeudaPorVencer.Show();
            VerificarFormulario(frmRptDeudaPorVencer);
        }
        
        private void barBtnReporteGenerales_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRptReporteGenerales = FrmRptReporteGenerales.Instance();
            frmRptReporteGenerales.ShowDialog();
        }

        private void barBtnProductos_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRptProductos = FrmRptProductos.Instance();
            frmRptProductos.ShowDialog();
        }

        private void barBtnDashboardVentas_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmVentaEstadisticas = FrmVentaEstadisticas.Instance();
            frmVentaEstadisticas.ShowDialog();
        }

        private void FrmPrincipal_SizeChanged(object sender, EventArgs e)
        {
            pbLogoInguiri.Location = new System.Drawing.Point(this.Width-240, this.Height-130);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetLastInputInfo(ref INPUT); //'COMPROBAMOS LA FUNCION CADA SEGUNDO

            int total = Environment.TickCount;
            int ultimo = INPUT.dwTime;
            int intervalo = (total - ultimo) / 1000;
            
            if (intervalo > _VidaUtil && bloqueado == false)
            {
                FrmBloqueo frmBloqueo = new FrmBloqueo();
                bloqueado = true;
                intervalo = 0;
                timer1.Stop();
                frmBloqueo.sLogin = this.CodUsuario.Caption;
                frmBloqueo.frmPrincipal = this;
                frmBloqueo.ShowDialog();

                if (frmBloqueo.DialogResult == DialogResult.OK)
                {
                    timer1.Start();
                    bloqueado = frmBloqueo.bloqueado;
                }
                else
                {
                    this.Close();
                    this.Dispose();
                }
            }

            ValidarFormularioActivos();
        }
    }
}

struct LASTINPUTINFO
{
     public int cbSize;
     public int dwTime;
}