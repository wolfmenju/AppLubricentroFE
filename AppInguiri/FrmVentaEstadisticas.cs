using Comun;
using Entidad;
using Negocio;
using Newtonsoft.Json;
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
    public partial class FrmVentaEstadisticas : Form
    {
        private static FrmVentaEstadisticas frmInstance = null;
        private VentaNegocio obj = new VentaNegocio();
        private List<Venta> list = null;

        public FrmVentaEstadisticas()
        {
            InitializeComponent();
        }

        //Singleton
        public static FrmVentaEstadisticas Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmVentaEstadisticas();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }
                
        private void GenerarGrafico( int xtipo)
        {
            lblTotal.Text = "S/. 0.00";
            chGrafico.Series["Venta"].Points.Clear();
            list = new List<Venta>();
            list = obj.ListarVentas(new Venta { nTipo = xtipo });

            decimal suma = 0M;

            for (int i = 0; i < list.Count; i++)
            {
                if(xtipo==12) chGrafico.Series["Venta"].Points.AddXY(list[i].sProducto, list[i].fTotal);
                else chGrafico.Series["Venta"].Points.AddXY(list[i].nCodigo, list[i].fTotal);
                suma = suma + list[i].fTotal;
            }

            lblTotal.Text = suma.ToString("C");
        }

        private void FrmVentaEstadisticas_Load(object sender, EventArgs e)
        {
            cbxTipoGrafico.SelectedIndex = 0;
            GenerarGrafico(12);
        }

        private void cbxTipoGrafico_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GenerarGrafico(cbxTipoGrafico.SelectedIndex == 0 ? 12 : 11);
        }
    }
}
