using EstanciaGanadera.Domain.Establecimientos;
using Eventing.TestHelpers;

namespace EstanciaGanadera.Domain.Tests.Establecimientos
{
    public class EstablecimientosSpec
    {
        protected TestableEventSourcedService<EstablecimientosService> sut;

        public EstablecimientosSpec()
        {
            this.sut = new TestableEventSourcedService<EstablecimientosService>(r =>
                new EstablecimientosService(r));
        }
    }
}
