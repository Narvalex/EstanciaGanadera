using Eventing;

namespace EstanciaGanadera.Desktop.Views.Dashboard
{
    public class DashboardMainViewPresenter
    {
        private readonly IDashboardMainView dashboardMainView;

        public DashboardMainViewPresenter(IDashboardMainView dashboardMainView)
        {
            Ensure.NotNull(dashboardMainView, nameof(dashboardMainView));

            this.dashboardMainView = dashboardMainView;
        }
    }
}
