namespace EstanciaGanadera.Desktop.Views.Establecimientos.Views
{
    partial class NuevoEstablecimientoForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre del establecimiento:";
            // 
            // textBox1
            // 
            this.textBox.Location = new System.Drawing.Point(6, 23);
            this.textBox.Name = "textBox1";
            this.textBox.Size = new System.Drawing.Size(137, 20);
            this.textBox.TabIndex = 2;
            // 
            // button1
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(68, 49);
            this.btnRegistrar.Name = "button1";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 3;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            // 
            // NuevoEstablecimientoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label2);
            this.Name = "NuevoEstablecimientoForm";
            this.Size = new System.Drawing.Size(156, 83);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button btnRegistrar;
    }
}
