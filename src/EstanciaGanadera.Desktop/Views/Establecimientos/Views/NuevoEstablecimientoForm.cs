using System;
using System.Windows.Forms;

namespace EstanciaGanadera.Desktop.Views.Establecimientos.Views
{
    public partial class NuevoEstablecimientoForm : UserControl, INuevoEstablecimientoForm
    {
        public NuevoEstablecimientoForm()
        {
            InitializeComponent();

            this.btnRegistrar.Click += (s, e) => this.RegistrarNuevoEstablecimiento(s, this.textBox.Text);
        }

        public void DefaultFocus()
        {
            this.textBox.Focus();
        }

        public event EventHandler<string> RegistrarNuevoEstablecimiento;
    }
}
