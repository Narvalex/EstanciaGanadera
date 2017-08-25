using System;

namespace EstanciaGanadera.Desktop.Views.Establecimientos.Views
{
    public interface INuevoEstablecimientoForm
    {
        event EventHandler<string> RegistrarNuevoEstablecimiento;

        void DefaultFocus();
    }
}
