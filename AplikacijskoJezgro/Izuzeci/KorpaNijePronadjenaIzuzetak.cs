using System;

namespace eNakit.AplikacijskoJezgro.Izuzeci
{
    public class KorpaNijePronadjenaIzuzetak : Exception
    {
        public KorpaNijePronadjenaIzuzetak(int korpaId) : base($"Nije pronađena korpa sa id-em {korpaId}")
        {
        }

        protected KorpaNijePronadjenaIzuzetak(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext kontekst) : base(info, kontekst)
        {
        }

        public KorpaNijePronadjenaIzuzetak(string poruka) : base(poruka)
        {
        }

        public KorpaNijePronadjenaIzuzetak(string poruka, Exception unutrasnjiIzuzetak) : base(poruka, unutrasnjiIzuzetak)
        {
        }
    }
}
