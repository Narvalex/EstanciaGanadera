namespace EstanciaGanadera.Domain.Establecimientos
{
    public class RegistrarNuevoEstablecimiento : MensajeAuditable
    {
        public RegistrarNuevoEstablecimiento(string nombre, Firma firma = null) : base(firma)
        {
            this.Nombre = nombre;
        }

        public string Nombre { get; }
    }
}
