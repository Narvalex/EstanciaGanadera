using EstanciaGanadera.Client.Establecimientos;
using EstanciaGanadera.Desktop.Views.Dashboard;
using EstanciaGanadera.Desktop.Views.Establecimientos;
using EstanciaGanadera.Desktop.Views.Establecimientos.Views;
using EstanciaGanadera.Desktop.Views.Main;
using Eventing.Client.Http;
using Eventing.Core.Serialization;
using Eventing.OfflineClient.EntityFramework;
using System;
using System.Windows.Forms;

namespace EstanciaGanadera.Desktop
{
    internal static class Bootstrap
    {
        internal static Form ResolveAllAndReturnMainForm()
        {
            // Config
            var serverUrl = "http://localhost:8090";
            var dbName = "EstanciaGanaderaClientDb";

            // Common
            var http = new HttpLite(serverUrl);
            var serializer = new NewtonsoftJsonSerializer();
            var queue = new EntityFramworkPendingMessageQueue(flag => new PendingMessageQueueDbContext(flag, dbName));
#if DropDb
            queue.DropDb();
            queue.CreateDbIfNotExists();
#else
            queue.CreateDbIfNotExists();
#endif

            // Usuarios-------------------------------------------------------------------------------
            Func<string> tokenProvider = () => "Test";
            var jsonSerializer = new NewtonsoftJsonSerializer();

            // Establecimientos------------------------------------------------------------------------
            // Clients
            //var establecimientoClient = new FakeEstablecimientosClient();
            var establecimientoClient = new EstablecimientosClient(http, serializer, queue, tokenProvider, ex => MessageBox.Show(jsonSerializer.Serialize(ex), "Error en buzón salida de mensajes pendientes"));
            // Views
            var nuevoEstablecimientoForm = new NuevoEstablecimientoForm();
            var establecimientosMainView = new EstablecimientoMainView(nuevoEstablecimientoForm);
            // Presenters
            var establecimientosMainViewPresenter = new EstablecimientosMainViewPresenter(establecimientosMainView, nuevoEstablecimientoForm);
            var nuevoEstablecimientoPresenter = new NuevoEstablecimientoPresenter(nuevoEstablecimientoForm, establecimientoClient);

            // Main------------------------------------------------------------------------------------
            // Views
            var dashboardMainView = new DashboardMainView();
            var mainForm = new MainForm(dashboardMainView, establecimientosMainView);
            // Presenters
            var mainFormPresenter = new MainFormPresenter(mainForm, dashboardMainView);

            return mainForm;
        }
    }
}
