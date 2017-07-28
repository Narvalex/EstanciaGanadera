using EstanciaGanadera.Domain.Establecimientos;
using Eventing.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace EstanciaGanadera.Domain.Tests.Establecimientos
{
    [TestClass]
    public class DadoNingunEstablecimiento : EstablecimientosSpec
    {
        [Test]
        public void EntoncesSePuedeCrearElPrimerEstablecimiento()
        {
            var nombre = "Yvapovo";
            this.sut.When(s =>
            {
                s.HandleAsync(new RegistrarNuevoEstablecimiento(nombre, FakeFirma.New)).Wait();
            })
            .Then(events =>
            {
                Assert.AreEqual(1, events.Count);
                Assert.AreEqual(1, events.OfType<NuevoEstablecimientoRegistrado>().Count());

                var e = events.OfType<NuevoEstablecimientoRegistrado>().Single();
            });
        }
    }
}
