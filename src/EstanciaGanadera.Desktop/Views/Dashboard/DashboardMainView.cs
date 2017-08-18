using System;
using System.Windows.Forms;

namespace EstanciaGanadera.Desktop.Views.Dashboard
{
    public partial class DashboardMainView : UserControl, IDashboardMainView
    {
        public DashboardMainView()
        {
            InitializeComponent();

            this.linkEstablecimientos.Click += (s, e) => this.EstablecimientosClicked?.Invoke(s, e);
        }

        public event EventHandler EstablecimientosClicked;
    }
}
