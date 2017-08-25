using System;

namespace EstanciaGanadera.Desktop.Views.Establecimientos
{
    public interface IEstablecimientosMainView
    {
        event EventHandler IrANuevoEstablecimiento;

        void MostrarNuevoEstablecimientoForm();
    }
}
