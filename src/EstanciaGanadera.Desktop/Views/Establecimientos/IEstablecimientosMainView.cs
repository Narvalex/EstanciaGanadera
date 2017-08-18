using System;

namespace EstanciaGanadera.Desktop.Views.Establecimientos
{
    public interface IEstablecimientosMainView
    {
        event EventHandler NuevoEstablecimiento;

        void MostrarNuevoEstablecimientoForm();
    }
}
