using Ardalis.GuardClauses;

namespace eNakit.AplikacijskoJezgro.Entiteti.KorpaAgregacija
{
    public class KorpaStavka : BazniEntitet
    {

        public decimal JedinicnaCijena { get; private set; }
        public int Kolicina { get; private set; }
        public int KatalogStavkaId { get; private set; }
        public int KorpaId { get; private set; }

        public KorpaStavka(int katalogStavkaId, int kolicina, decimal jedinicnaCijena)
        {
            KatalogStavkaId = katalogStavkaId;
            JedinicnaCijena = jedinicnaCijena;
            PostaviKolicinu(kolicina);
        }

        public void DodajKolicinu(int kolicina)
        {
            Guard.Against.OutOfRange(kolicina, nameof(kolicina), 0, int.MaxValue);

            Kolicina += kolicina;
        }

        public void PostaviKolicinu(int kolicina)
        {
            Guard.Against.OutOfRange(kolicina, nameof(kolicina), 0, int.MaxValue);

            Kolicina = kolicina;
        }
    }
}
