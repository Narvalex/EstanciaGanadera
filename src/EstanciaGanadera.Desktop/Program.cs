using EstanciaGanadera.Desktop.Views.Dashboard;
using EstanciaGanadera.Desktop.Views.Establecimientos;
using EstanciaGanadera.Desktop.Views.Establecimientos.Views;
using EstanciaGanadera.Desktop.Views.Main;
using System;
using System.Threading;
using System.Windows.Forms;

namespace EstanciaGanadera.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationOnThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Views----------------------------------------------------------------------------------------------
            // Establecimientos
            var nuevoEstablecimientoForm = new NuevoEstablecimientoForm();
            var establecimientosMainView = new EstablecimientoMainView(nuevoEstablecimientoForm);

            var dashboardMainView = new DashboardMainView();
            var mainForm = new MainForm(dashboardMainView, establecimientosMainView);

            // Presenters-------------------------------------------------------------------------------------------
            var mainFormPresenter = new MainFormPresenter(mainForm, dashboardMainView);
            var establecimientosMainViewPresenter = new EstablecimientosMainViewPresenter(establecimientosMainView);

            Application.Run(mainForm);
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var message = String.Format("Sorry, something went wrong.\r\n" +
                "{0}\r\n" +
                "Please contact support.",
                ((Exception)e.ExceptionObject).Message);

            Console.WriteLine("ERROR {0}: {1}",
                DateTimeOffset.Now, e.ExceptionObject);

            MessageBox.Show(message, "Unexpected Error");

        }

        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var message = String.Format("Sorry, something went wrong.\r\n" +
              "{0}\r\n" +
              "Please contact support.",
                e.Exception.Message);

            Console.WriteLine("ERROR {0}: {1}",
                DateTimeOffset.Now, e.Exception);

            MessageBox.Show(message, "Unexpected Error");
        }
    }
}
