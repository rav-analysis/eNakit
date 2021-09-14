using Ardalis.GuardClauses;

namespace eNakit.AplikacijskoJezgro.Entiteti.NarudzbaAgregacija
{
   
    public class NarucenaKatalogStavka 
    {
        public NarucenaKatalogStavka(int katalogStavkaId, string nazivProizvoda, string slikaUri)
        {
            Guard.Against.OutOfRange(katalogStavkaId, nameof(katalogStavkaId), 1, int.MaxValue);
            Guard.Against.NullOrEmpty(nazivProizvoda, nameof(nazivProizvoda));
            Guard.Against.NullOrEmpty(slikaUri, nameof(slikaUri));

            KatalogStavkaId = katalogStavkaId;
            NazivProizvoda = nazivProizvoda;
            SlikaUri = slikaUri;
        }

        private NarucenaKatalogStavka()
        {
            
        }

        public int KatalogStavkaId { get; private set; }
        public string NazivProizvoda { get; private set; }
        public string SlikaUri { get; private set; }
    }
}
