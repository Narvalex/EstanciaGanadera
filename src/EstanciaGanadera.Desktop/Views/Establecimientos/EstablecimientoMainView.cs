using EstanciaGanadera.Desktop.Views.Establecimientos.Views;
using Eventing;
using System;
using System.Windows.Forms;

namespace EstanciaGanadera.Desktop.Views.Establecimientos
{
    public partial class EstablecimientoMainView : UserControl, IEstablecimientosMainView
    {
        private readonly Control nuevoEstablecimientoForm;

        public EstablecimientoMainView(INuevoEstablecimientoForm nuevoEstablecimientoForm)
        {
            InitializeComponent();

            Ensure.NotNull(nuevoEstablecimientoForm, nameof(nuevoEstablecimientoForm));

            this.nuevoEstablecimientoForm = (Control)nuevoEstablecimientoForm;
            this.nuevoEstablecimientoForm.Dock = DockStyle.Fill;

            this.btnNuevoEstablecimiento.Click += (s, e) =>
            {
                //this.NuevoEstablecimiento?.Invoke(s, e);
                // It should explode if nobody is listening to tihs event
                this.IrANuevoEstablecimiento.Invoke(s, e);
            };
        }

        public event EventHandler IrANuevoEstablecimiento;

        public void MostrarNuevoEstablecimientoForm()
        {
            this.splitContainer.Panel2.Controls.Clear();
            this.splitContainer.Panel2.Controls.Add(this.nuevoEstablecimientoForm);
        }
    }
}
