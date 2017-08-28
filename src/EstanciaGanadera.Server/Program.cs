using Eventing.GetEventStore;
using Eventing.Log;
using Microsoft.Owin.Hosting;
using System;

namespace EstanciaGanadera.Server
{
    partial class Program
    {
        private static ILogLite _log = LogManager.GlobalLogger;

        static void Main(string[] args)
        {
            SetConsoleCtrlHandler(signal =>
            {
                OnExit();
                // Shutdown right away
                Environment.Exit(-1);
                return true;
            }, true);

            var log = _log;
            Console.WriteLine("Estancia Ganadera Server");

            // Dependencies
            log.Verbose("Resolviendo dependencias...");
            ServiceLocator.Initialize();
            log.Verbose("Dependencias listas!");

            // Event Store
            log.Verbose("Initializing Event Store");
            var es = ServiceLocator.ResolveSingleton<EventStoreManager>();
#if DropDb
            log.Info("Dabase initialization config: DROP AND CREATE");
            es.DropAndCreateDb();
#else
            log.Info("Dabase initialization config: CREATE IF NOT EXISTS");
            es.CreateDbIfNotExists();
#endif
            log.Verbose("Event Store is ready!");

            // Web Api
            log.Verbose("Starting web server...");
            var baseUri = "http://localhost:8090";
            WebApiStartup.OnAppDisposing = () => OnExit();
            WebApp.Start<WebApiStartup>(baseUri);
            _log.Success($"Web server is ready! Server running at {baseUri}");

            EnterCommandLoop();
        }

        private static void EnterCommandLoop()
        {
            string line;
            do
            {
                Console.WriteLine("Type exit to shut down");
                line = Console.ReadLine();
            }
            while (!line.Equals("exit", StringComparison.InvariantCultureIgnoreCase));

            OnExit();
        }

        private static void OnExit()
        {
            ServiceLocator
                .ResolveSingleton<EventStoreManager>()
                .TearDown();
        }
    }
}
