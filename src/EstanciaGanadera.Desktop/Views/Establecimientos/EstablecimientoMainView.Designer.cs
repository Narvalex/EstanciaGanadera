namespace EstanciaGanadera.Desktop.Views.Establecimientos
{
    partial class EstablecimientoMainView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.btnNuevoEstablecimiento = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.btnNuevoEstablecimiento);
            this.splitContainer.Size = new System.Drawing.Size(698, 437);
            this.splitContainer.SplitterDistance = 232;
            this.splitContainer.TabIndex = 0;
            // 
            // btnNuevoEstablecimiento
            // 
            this.btnNuevoEstablecimiento.Location = new System.Drawing.Point(12, 19);
            this.btnNuevoEstablecimiento.Name = "btnNuevoEstablecimiento";
            this.btnNuevoEstablecimiento.Size = new System.Drawing.Size(137, 23);
            this.btnNuevoEstablecimiento.TabIndex = 0;
            this.btnNuevoEstablecimiento.Text = "Nuevo establecimiento";
            this.btnNuevoEstablecimiento.UseVisualStyleBackColor = true;
            // 
            // EstablecimientoMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "EstablecimientoMainView";
            this.Size = new System.Drawing.Size(698, 437);
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnNuevoEstablecimiento;
    }
}
