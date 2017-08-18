using EstanciaGanadera.Desktop.Views.Dashboard;
using EstanciaGanadera.Desktop.Views.Establecimientos;
using Eventing;
using System;
using System.Windows.Forms;

namespace EstanciaGanadera.Desktop.Views.Main
{
    public partial class MainForm : Form, IMainFormView
    {
        private readonly Control dashboardMainView;
        private readonly Control establecimientosMainView;

        public MainForm(IDashboardMainView dashboardMainView, IEstablecimientosMainView establecimientosMainView)
        {
            InitializeComponent();

            Ensure.NotNull(dashboardMainView, nameof(dashboardMainView));
            Ensure.NotNull(establecimientosMainView, nameof(establecimientosMainView));

            this.dashboardMainView = (Control)dashboardMainView;
            // https://stackoverflow.com/questions/22143440/winforms-fill-user-control-inside-panel
            this.dashboardMainView.Dock = DockStyle.Fill;

            this.establecimientosMainView = (Control)establecimientosMainView;
            this.establecimientosMainView.Dock = DockStyle.Fill;
        }

        public void MostrarDashboard()
        {
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(this.dashboardMainView);
        }

        public void MostrarEstablecimientos()
        {
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(this.establecimientosMainView);
        }

        public event EventHandler Home
        {
            add { this.toolStripButton1.Click += value; }
            remove { this.toolStripButton1.Click -= value; }
        }
    }
}
