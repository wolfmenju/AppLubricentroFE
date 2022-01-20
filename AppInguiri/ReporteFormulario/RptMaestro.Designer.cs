namespace AppInguiri.ReporteFormulario
{
    partial class RptMaestro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cReporte = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cReporte
            // 
            this.cReporte.ActiveViewIndex = -1;
            this.cReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cReporte.Cursor = System.Windows.Forms.Cursors.Default;
            this.cReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cReporte.Location = new System.Drawing.Point(0, 0);
            this.cReporte.Name = "cReporte";
            this.cReporte.ShowCloseButton = false;
            this.cReporte.ShowCopyButton = false;
            this.cReporte.ShowGroupTreeButton = false;
            this.cReporte.ShowLogo = false;
            this.cReporte.ShowParameterPanelButton = false;
            this.cReporte.ShowRefreshButton = false;
            this.cReporte.ShowTextSearchButton = false;
            this.cReporte.Size = new System.Drawing.Size(905, 486);
            this.cReporte.TabIndex = 0;
            this.cReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // RptMaestro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 486);
            this.Controls.Add(this.cReporte);
            this.KeyPreview = true;
            this.Name = "RptMaestro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Maestro";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer cReporte;
    }
}