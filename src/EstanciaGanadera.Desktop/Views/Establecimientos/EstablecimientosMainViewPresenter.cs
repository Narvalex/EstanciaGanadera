using Eventing;

namespace EstanciaGanadera.Desktop.Views.Establecimientos
{
    public class EstablecimientosMainViewPresenter
    {
        private readonly IEstablecimientosMainView view;

        public EstablecimientosMainViewPresenter(IEstablecimientosMainView view)
        {
            Ensure.NotNull(view, nameof(view));

            this.view = view;

            this.view.NuevoEstablecimiento += (s, e) => this.view.MostrarNuevoEstablecimientoForm();
        }
    }
}
