namespace EstanciaGanadera.Domain.Establecimientos
{
    public class NuevoEstablecimientoRegistrado : MensajeAuditable
    {
        public NuevoEstablecimientoRegistrado(string nombre, Firma firma = null) : base(firma)
        {
            this.Nombre = nombre;
        }

        public string Nombre { get; }
    }
}
