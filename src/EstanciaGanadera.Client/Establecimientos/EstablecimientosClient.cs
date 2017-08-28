using EstanciaGanadera.Common;
using EstanciaGanadera.Domain.Establecimientos;
using Eventing.Client.Http;
using Eventing.Core.Serialization;
using Eventing.OfflineClient;
using System;
using System.Threading.Tasks;

namespace EstanciaGanadera.Client.Establecimientos
{
    public class EstablecimientosClient : OfflineClientBase, IEstablecimientosClient
    {
        public EstablecimientosClient(IHttpLite httpClient, IJsonSerializer serializer, IPendingMessagesQueue queue, Func<string> tokenProvider, Action<Exception> onError)
            : base(httpClient, serializer, queue, tokenProvider, Endpoints.Establecimientos.Prefix, onError)
        { }

        public async Task RegistrarNuevoEstablecimiento(string nombreDeEstablecimiento)
        {
            var cmd = new RegistrarNuevoEstablecimiento(nombreDeEstablecimiento);
            await base.Send(Endpoints.Establecimientos.RegistrarNuevoEstablecimiento, cmd);
        }
    }

    public class FakeEstablecimientosClient : IEstablecimientosClient
    {
        public Task RegistrarNuevoEstablecimiento(string nombreDeEstablecimiento)
        {
            return Task.CompletedTask;
        }
    }
}
