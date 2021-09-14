using System;

namespace eNakit.AplikacijskoJezgro.Izuzeci
{
    public class PraznaKorpaTokomFinalizacijeIzuzetak : Exception
    {
        public PraznaKorpaTokomFinalizacijeIzuzetak()
            : base($"Ne možete uraditi potvrdu sa praznom korpom!")
        {
        }

        protected PraznaKorpaTokomFinalizacijeIzuzetak(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext kontekst) : base(info, kontekst)
        {
        }

        public PraznaKorpaTokomFinalizacijeIzuzetak(string poruka) : base(poruka)
        {
        }

        public PraznaKorpaTokomFinalizacijeIzuzetak(string poruka, Exception unutrasnjiIzuzetak) : base(poruka, unutrasnjiIzuzetak)
        {
        }
    }
}

