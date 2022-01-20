using System;
using System.Collections.Generic;
using DevExpress.XtraBars;
using Entidad;
using Negocio;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Windows.Forms;

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
        
        #endregion

        List<Permiso> listPerm = new List<Permiso>();
        PermisoNegocio objPermNeg = new PermisoNegocio();
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

        CajaNegocio objCajNeg = new CajaNegocio();

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

        private void barBtnPresentacion_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPresentacion = FrmPresentacion.Instance();
            frmPresentacion.MdiParent = this;
            frmPresentacion.Show();
        }

        private void barBtnProveedor_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProveedor = FrmProveedor.Instance();
            frmProveedor.MdiParent = this;
            frmProveedor.Show();
        }

        private void barBtnUsuario_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUsuario = FrmUsuario.Instance();
            frmUsuario.MdiParent = this;
            frmUsuario.Show();
        }

        private void barBtnCategoria_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCategoria = FrmCategoria.Instance();
            frmCategoria.MdiParent = this;
            frmCategoria.Show();
        }

        private void barBtnSede_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSede = FrmSede.Instance();
            frmSede.MdiParent = this;
            frmSede.Show();
        }

        private void barBtnAlmacen_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAlmacen = FrmAlmacen.Instance();
            frmAlmacen.MdiParent = this;
            frmAlmacen.Show();
        }

        private void barBtnDocumentos_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDocumento = FrmDocumento.Instance();
            frmDocumento.MdiParent = this;
            frmDocumento.Show();
        }

        private void barBtnDocumentosSerie_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDocumentoSerie = FrmDocumentoSerie.Instance();
            frmDocumentoSerie.MdiParent = this;
            frmDocumentoSerie.Show();
        }
        
        private void barBtnParametros_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmParametro = FrmParametro.Instance();
            frmParametro.MdiParent = this;
            frmParametro.Show();
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
            frmPermiso = FrmPermiso.Instance();
            frmPermiso.MdiParent = this;
            frmPermiso.Show();
        }

        private void barBtnCliente_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCliente = FrmCliente.Instance();
            frmCliente.MdiParent = this;
            frmCliente.Show();
        }

        private void barBtnProducto_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProducto = FrmProducto.Instance();
            frmProducto.MdiParent = this;
            frmProducto.Show();
        }

        private void barBtnCompra_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCompra = FrmCompra.Instance();
            frmCompra.MdiParent = this;
            frmCompra.Show();
        }

        private void barBtnVenta_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmVenta = FrmVenta.Instance();
            frmVenta.MdiParent = this;
            frmVenta.Show();
        }

        private void barBtnProductoVendido_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRptProductoVendido = FrmRptProductoVendido.Instance();
            frmRptProductoVendido.MdiParent = this;
            frmRptProductoVendido.Show();   
        }

        private void barBtnActualizarPrecio_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmActualizarPrecio = FrmActualizarPrecio.Instance();
            frmActualizarPrecio.MdiParent = this;
            frmActualizarPrecio.Show();
        }

        private void barBtnLoteProductoPorVencer_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRptLoteProductoPorVencer = FrmRptLoteProductoPorVencer.Instance();
            frmRptLoteProductoPorVencer.MdiParent = this;
            frmRptLoteProductoPorVencer.Show();
        }

        private void barBtnCerrarCaja_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCerrarCaja = FrmCerrarCaja.Instance();
            frmCerrarCaja.frmPrincipal = this;
            frmCerrarCaja.ShowDialog();
        }

        private void barBtnReporteCompra_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRptCompras = FrmRptCompras.Instance();
            frmRptCompras.MdiParent = this;
            frmRptCompras.Show();
        }

        private void barBtnReporteVenta_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRptVentas = FrmRptVentas.Instance();
            frmRptVentas.ShowDialog();
        }

        private void barBtnStockMinimo_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRptSockMinimo = FrmRptSockMinimo.Instance();
            frmRptSockMinimo.MdiParent = this;
            frmRptSockMinimo.Show();
        }

        private void barBtnCuentasPorPagar_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDeudasPorPagar = FrmDeudasPorPagar.Instance();
            frmDeudasPorPagar.MdiParent = this;
            frmDeudasPorPagar.Show();
        }

        private void barBtnIventario_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmInventario = FrmInventario.Instance();
            frmInventario.MdiParent = this;
            frmInventario.Show();
        }
        
        private void barBtnRptCajaChica_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRptCajaChica = FrmRptCajaChica.Instance();
            frmRptCajaChica.MdiParent = this;
            frmRptCajaChica.Show();
        }

        private void barBtnRptHistorialPrecio_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRptHistorialPrecio = FrmRptHistorialPrecio.Instance();
            frmRptHistorialPrecio.MdiParent = this;
            frmRptHistorialPrecio.Show();
        }

        private void barBtnUtilidadesProducto_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRptUtilidades = FrmRptUtilidades.Instance();
            frmRptUtilidades.MdiParent = this;
            frmRptUtilidades.Show();
        }
        
        private void barBtnConsultaStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRptProductoStock = FrmRptProductoStock.Instance();
            frmRptProductoStock.MdiParent = this;
            frmRptProductoStock.Show();
        }

        private void barBtnKardex_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRptKardex = FrmRptKardex.Instance();
            frmRptKardex.MdiParent = this;
            frmRptKardex.Show();
        }
        
        private void barBtnDevuelveProducto_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDevuelve = FrmAjusteStock.Instance();
            frmDevuelve.MdiParent = this;
            frmDevuelve.Show();
        }

        private void barBtnDeudasPorVencer_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRptDeudaPorVencer = FrmRptDeudaPorVencer.Instance();
            frmRptDeudaPorVencer.MdiParent = this;
            frmRptDeudaPorVencer.Show();
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
        }
    }
}

struct LASTINPUTINFO
{
     public int cbSize;
     public int dwTime;
}