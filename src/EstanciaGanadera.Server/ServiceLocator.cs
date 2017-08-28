using EstanciaGanadera.Common.IoC;
using EstanciaGanadera.Domain;
using EstanciaGanadera.Domain.Establecimientos;
using Eventing.Core.Persistence;
using Eventing.Core.Serialization;
using Eventing.GetEventStore;
using System;

namespace EstanciaGanadera.Server
{
    public static class ServiceLocator
    {
        private static ISimpleContainer _container;

        public static T ResolveSingleton<T>() => _container.ResolveSingleton<T>();

        public static T ResolveNewOf<T>() => _container.ResolveNewOf<T>();

        public static void Initialize()
        {
            var container = new SimpleContainer();
            _container = container;

            // Event Store
            var esm = new EventStoreManager();
            container.Register<EventStoreManager>(esm);

            // Serializer
            var jsonSerializer = new NewtonsoftJsonSerializer();

            // Firma Provider
            var firmaProvider = new FakeFirmaProvider();
            container.Register<IProveedorDeFirmaDelUsuario>(firmaProvider);

            // Event Sourced Repository
            var snapshotCache = new SnapshotCache();
            var esRepo = new EventStoreEventSourcedRepository(esm.GetFailFastConnection, jsonSerializer, snapshotCache);

            // Establecimientos
            var establecimientosService = new EstablecimientosService(esRepo);
            container.Register<EstablecimientosService>(establecimientosService);
        }
    }

    public class FakeFirmaProvider : IProveedorDeFirmaDelUsuario
    {
        public Firma ObtenerFirmaDelUsuario(string token)
        {
            return new Firma(token, DateTime.Now);
        }
    }
}
