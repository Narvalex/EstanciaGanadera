using System;

namespace EstanciaGanadera.Desktop.Views.Main
{
    public interface IMainFormView
    {
        event EventHandler Load;
        event EventHandler Home;

        void MostrarDashboard();
        void MostrarEstablecimientos();
    }
}


