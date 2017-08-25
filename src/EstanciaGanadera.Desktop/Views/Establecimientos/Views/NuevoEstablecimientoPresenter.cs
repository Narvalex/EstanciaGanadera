using EstanciaGanadera.Client.Establecimientos;
using Eventing;

namespace EstanciaGanadera.Desktop.Views.Establecimientos.Views
{
    public class NuevoEstablecimientoPresenter
    {
        private readonly INuevoEstablecimientoForm form;
        private readonly IEstablecimientosClient client;

        public NuevoEstablecimientoPresenter(INuevoEstablecimientoForm form, IEstablecimientosClient client)
        {
            Ensure.NotNull(form, nameof(form));
            Ensure.NotNull(client, nameof(client));

            this.form = form;
            this.client = client;

            this.form.RegistrarNuevoEstablecimiento += async (s, e) => await this.client.RegistrarNuevoEstablecimiento(e);
        }
    }
}
