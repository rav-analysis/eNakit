using System;

namespace eNakit.AplikacijskoJezgro.Izuzeci
{
    public class DupliciranaStavkaKatalogaIzuzetak : Exception
    {
        public DupliciranaStavkaKatalogaIzuzetak(string poruka, int dupliciranaStavkaId) : base(poruka)
        {
            DupliciranaStavkaId = dupliciranaStavkaId;
        }

        public int DupliciranaStavkaId { get; }
    }
}
