using System;

namespace EstanciaGanadera.Domain.Tests
{
    public static class FakeFirma
    {
        public static Firma New => new Firma("TestRunnerUser", DateTime.Now);
    }
}
