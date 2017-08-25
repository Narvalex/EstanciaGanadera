using EstanciaGanadera.Desktop.Views.Establecimientos.Views;
using Eventing;

namespace EstanciaGanadera.Desktop.Views.Establecimientos
{
    public class EstablecimientosMainViewPresenter
    {
        private readonly IEstablecimientosMainView view;
        private readonly INuevoEstablecimientoForm nuevoForm;

        public EstablecimientosMainViewPresenter(IEstablecimientosMainView view, INuevoEstablecimientoForm nuevoForm)
        {
            Ensure.NotNull(view, nameof(view));
            Ensure.NotNull(nuevoForm, nameof(nuevoForm));

            this.view = view;
            this.nuevoForm = nuevoForm;

            this.view.IrANuevoEstablecimiento += (s, e) =>
            {
                this.view.MostrarNuevoEstablecimientoForm();
                this.nuevoForm.DefaultFocus();
            };
        }
    }
}
