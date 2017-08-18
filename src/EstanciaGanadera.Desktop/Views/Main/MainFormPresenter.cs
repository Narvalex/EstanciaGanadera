using EstanciaGanadera.Desktop.Views.Dashboard;
using Eventing;

namespace EstanciaGanadera.Desktop.Views.Main
{
    public class MainFormPresenter
    {
        private readonly IMainFormView mainFormView;
        private readonly IDashboardMainView dashboardMainView;

        public MainFormPresenter(IMainFormView mainFormView, IDashboardMainView dashboardMainView)
        {
            Ensure.NotNull(mainFormView, nameof(mainFormView));
            Ensure.NotNull(dashboardMainView, nameof(dashboardMainView));

            this.mainFormView = mainFormView;
            this.dashboardMainView = dashboardMainView;

            this.mainFormView.Load += (s, e) => this.mainFormView.MostrarDashboard();
            this.mainFormView.Home += (s, e) => this.mainFormView.MostrarDashboard();

            this.dashboardMainView.EstablecimientosClicked += (s, e) => this.mainFormView.MostrarEstablecimientos();
        }
    }
}


