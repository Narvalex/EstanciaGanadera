using Eventing.Core.Domain;
using Eventing.Core.Persistence;
using System.Threading.Tasks;

namespace EstanciaGanadera.Domain.Establecimientos
{
    public class EstablecimientosService : EventSourcedService
    {
        public EstablecimientosService(IEventSourcedRepository repository) : base(repository)
        {
        }

        public async Task HandleAsync(RegistrarNuevoEstablecimiento cmd)
        {
            var establecimiento = new Establecimiento();
            establecimiento.Emit(new NuevoEstablecimientoRegistrado(cmd.Nombre, cmd.Firma));
            await this.repository.SaveAsync(establecimiento);
        }
    }
}
