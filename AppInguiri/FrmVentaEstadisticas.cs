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
        private List<Venta> list = new List<Venta>();

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
                
        private void GenerarGrafico()
        {
            list = obj.ListarVentas(new Venta { nTipo = 11 });

            decimal suma = 0M;

            for (int i = 0; i < list.Count; i++)
            {
                chart1.Series["Fecha"].Points.AddXY(list[i].fTotal, list[i].nCodigo);

            }

            //for (int i = 0; i < list.Count; i++)
            //{
            //    chart1.Series["Fecha"].Points.AddXY(list[i].nCodigo, list[i].fTotal);

            //}
        }

        private void FrmVentaEstadisticas_Load(object sender, EventArgs e)
        {
            GenerarGrafico();
        }
    }
}
