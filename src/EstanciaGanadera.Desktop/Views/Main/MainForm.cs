using EstanciaGanadera.Desktop.Views.Dashboard;
using System.Windows.Forms;

namespace EstanciaGanadera.Desktop.Views.Main
{
    public partial class MainForm : Form, IMainFormView
    {
        private readonly Control dashboardMainView;

        public MainForm(IDashboardMainView dashboardMainView)
        {
            InitializeComponent();

            this.dashboardMainView = (Control)dashboardMainView;
            // https://stackoverflow.com/questions/22143440/winforms-fill-user-control-inside-panel
            this.dashboardMainView.Dock = DockStyle.Fill;
        }

        public void MostrarDashboard()
        {
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(this.dashboardMainView);
        }
    }
}
