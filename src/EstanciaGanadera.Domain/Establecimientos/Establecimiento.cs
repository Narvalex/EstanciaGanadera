using Eventing.Core.Domain;

namespace EstanciaGanadera.Domain.Establecimientos
{
    /// <summary>
    /// Decimos que es un establecimiento no mas, por que puede ser mas chico que una estancia. 
    /// El establecimiento puede contener cualquier animal, no solamente vacuno
    /// </summary>
    [StreamCategory("estanciaGanadera.establecimientos")]
    public class Establecimiento : EventSourced
    {
        public Establecimiento()
        {
            this.On<NuevoEstablecimientoRegistrado>(e =>
            {
                this.SetStreamNameById(e.Nombre);
            });
        }

        protected override void Rehydrate(ISnapshot snapshot)
        {
            base.Rehydrate(snapshot);
        }

        protected override ISnapshot TakeSnapshot()
        {
            return new EstablecimientoSnapshot(this.StreamName, this.Version);
        }
    }

    public class EstablecimientoSnapshot : Snapshot
    {
        public EstablecimientoSnapshot(string streamName, int version) : base(streamName, version)
        {
        }
    }
}
