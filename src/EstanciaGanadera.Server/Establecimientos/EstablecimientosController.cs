using EstanciaGanadera.Common;
using EstanciaGanadera.Domain.Establecimientos;
using System.Threading.Tasks;
using System.Web.Http;

namespace EstanciaGanadera.Server.Establecimientos
{
    [RoutePrefix(Endpoints.Establecimientos.Prefix)]
    public class EstablecimientosController : ApiController
    {
        private readonly EstablecimientosService service = ServiceLocator.ResolveSingleton<EstablecimientosService>();

        [HttpPost]
        [Route(Endpoints.Establecimientos.RegistrarNuevoEstablecimiento)]
        public async Task<IHttpActionResult> RegistrarNuevoEstablecimiento(RegistrarNuevoEstablecimiento cmd)
        {
            await this.service.HandleAsync(cmd.ConFirma(this.ActionContext));
            return this.Ok();
        }
    }
}
