using System;

namespace EstanciaGanadera.Desktop.Views.Main
{
    public interface IMainFormView
    {
        event EventHandler Load;

        void MostrarDashboard();
    }
}


