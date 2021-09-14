using Ardalis.GuardClauses;
using eNakit.AplikacijskoJezgro.Entiteti;
using eNakit.AplikacijskoJezgro.Entiteti.KorpaAgregacija;
using eNakit.AplikacijskoJezgro.Entiteti.NarudzbaAgregacija;
using eNakit.AplikacijskoJezgro.Interfejsi;
using eNakit.AplikacijskoJezgro.Specifikacije;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    public class OrderService : INarudzbaServis
    {
        private readonly IAsinhroniRepozitorij<Narudzba> _narudzbaRepozitorij;
        private readonly IUriSastavljac _uriSastavljac;
        private readonly IAsinhroniRepozitorij<Korpa> _korpaRepozitorij;
        private readonly IAsinhroniRepozitorij<KatalogStavka> _stavkaRepozitorij;

        public OrderService(IAsinhroniRepozitorij<Korpa> korpaRepozitorij,
            IAsinhroniRepozitorij<KatalogStavka> stavkaRepozitorij,
            IAsinhroniRepozitorij<Narudzba> narudzbaRepozitorij,
            IUriSastavljac uriSastavljac)
        {
            _narudzbaRepozitorij = narudzbaRepozitorij;
            _uriSastavljac = uriSastavljac;
            _korpaRepozitorij = korpaRepozitorij;
            _stavkaRepozitorij = stavkaRepozitorij;
        }

        public async Task KreirajNarudzbuAsinhrono(int korpaId, Adresa adresaDostave)
        {
            var korpaSpec = new KorpaSaStavkamaSpecifikacija(korpaId);
            var korpa= await _korpaRepozitorij.PrviIliDefaultAsinhrono(korpaSpec);

            Guard.Against.NullKorpa(korpaId, korpa);
            Guard.Against.PraznaKorpaTokomFinalizacije(korpa.Stavke);

            var katalogStavkeSpecifikacija = new KatalogStavkeSpecifikacija(korpa.Stavke.Select(item => item.KatalogStavkaId).ToArray());
            var katalogStavke = await _stavkaRepozitorij.IzlistajAsinhrono(katalogStavkeSpecifikacija);

            var stavke = korpa.Stavke.Select(korpaStavka =>
            {
                var katalogStavka = katalogStavke.First(c => c.Id == korpaStavka.KatalogStavkaId);
                var narucenaStavka = new NarucenaKatalogStavka(katalogStavka.Id, katalogStavka.Naziv, _uriSastavljac.SastaviUriSlike(katalogStavka.SlikaUri));
                var narudzbaStavka = new NarudzbaStavka(narucenaStavka, korpaStavka.JedinicnaCijena, korpaStavka.Kolicina);
                return narudzbaStavka;
            }).ToList();

            var narudzba = new Narudzba(korpa.KupacId, adresaDostave, stavke);

            await _narudzbaRepozitorij.DodajAsinhrono(narudzba);
        }
    }
}

