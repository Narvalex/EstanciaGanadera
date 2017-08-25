using System.Threading.Tasks;

namespace EstanciaGanadera.Client.Establecimientos
{
    public interface IEstablecimientosClient
    {
        Task RegistrarNuevoEstablecimiento(string nombreDeEstablecimiento);
    }
}
