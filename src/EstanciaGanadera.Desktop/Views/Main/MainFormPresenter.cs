namespace EstanciaGanadera.Desktop.Views.Main
{
    public class MainFormPresenter
    {
        private readonly IMainFormView mainFormView;

        public MainFormPresenter(IMainFormView mainFormView)
        {
            this.mainFormView = mainFormView;

            this.mainFormView.Load += (s, e) => this.mainFormView.MostrarDashboard();
        }
    }
}


