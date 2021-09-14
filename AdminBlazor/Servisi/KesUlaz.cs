using System;

namespace AdminBlazor.Servisi
{
    public class KesUlaz<T>
    {
        public KesUlaz(T stavka)
        {
            Vrijednost = stavka;
        }
        public KesUlaz()
        {

        }

        public T Vrijednost { get; set; }
        public DateTime DatumKreiran { get; set; } = DateTime.UtcNow;
    }
}
