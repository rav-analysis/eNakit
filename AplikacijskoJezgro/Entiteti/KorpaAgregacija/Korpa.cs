using eNakit.AplikacijskoJezgro.Interfejsi;
using System.Collections.Generic;
using System.Linq;

namespace eNakit.AplikacijskoJezgro.Entiteti.KorpaAgregacija
{
    public class Korpa : BazniEntitet, IAgregacijaKorijen
    {
        public string KupacId { get; private set; }
        private readonly List<KorpaStavka> _stavke = new List<KorpaStavka>();
        public IReadOnlyCollection<KorpaStavka> Stavke => _stavke.AsReadOnly();

        public Korpa(string kupacId)
        {
            KupacId = kupacId;
        }

        public void DodajStavku(int katalogStavkaId, decimal jedinicnaCijena, int kolicina = 1)
        {
            if (!Stavke.Any(i => i.KatalogStavkaId == katalogStavkaId))
            {
                _stavke.Add(new KorpaStavka(katalogStavkaId, kolicina, jedinicnaCijena));
                return;
            }
            var postojecaStavka = Stavke.FirstOrDefault(i => i.KatalogStavkaId == katalogStavkaId);
            postojecaStavka.DodajKolicinu(kolicina);
        }

        public void UkloniPrazneStavke()
        {
            _stavke.RemoveAll(i => i.Kolicina == 0);
        }

        public void PostaviNoviKupacId(string kupacId)
        {
            KupacId = kupacId;
        }
    }
}
