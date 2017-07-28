using EstanciaGanadera.Domain.Establecimientos;
using Eventing.Core.Domain;
using Eventing.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace EstanciaGanadera.Domain.Tests.Establecimientos
{
    [TestClass]
    public class CuandoSeRegistroPrimerEstablecimiento : EstablecimientosSpec
    {
        private readonly RegistrarNuevoEstablecimiento command;

        public CuandoSeRegistroPrimerEstablecimiento()
        {
            var meta = new Firma("user1", DateTime.Now);
            this.command = new RegistrarNuevoEstablecimiento("Yvapovo", meta);
            this.sut.When(s => s.HandleAsync(this.command).Wait());
        }

        [Test]
        public void EntoncesSeRegistraElNombre()
        {
            this.sut.Then(events =>
            {
                var e = events.OfType<NuevoEstablecimientoRegistrado>().Single();

                Assert.AreEqual(this.command.Nombre, e.Nombre);
            })
            .And<EstablecimientoSnapshot>(s =>
            {
                Assert.AreEqual(StreamCategoryAttribute.GetFullStreamName<Establecimiento>(this.command.Nombre), s.StreamName);
            });
        }

        [Test]
        public void EntoncesSeRegistraLaAutoriaDelRegistrador()
        {
            this.sut.Then(events =>
            {
                var e = events.OfType<NuevoEstablecimientoRegistrado>().Single();

                Assert.AreEqual(this.command.Firma.Usuario, e.Firma.Usuario);
                Assert.AreEqual(this.command.Firma.Timestamp, e.Firma.Timestamp);
            });
        }
    }
}
