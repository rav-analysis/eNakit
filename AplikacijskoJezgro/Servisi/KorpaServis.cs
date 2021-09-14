using Ardalis.GuardClauses;
using eNakit.AplikacijskoJezgro.Entiteti.KorpaAgregacija;
using eNakit.AplikacijskoJezgro.Interfejsi;
using eNakit.AplikacijskoJezgro.Specifikacije;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eNakit.AplikacijskoJezgro.Servisi
{
    public class KorpaServis : IKorpaServis
    {
        private readonly IAsinhroniRepozitorij<Korpa> _korpaRepozitorij;
        private readonly IAplikacijskiLog<KorpaServis> _loger;

        public KorpaServis(IAsinhroniRepozitorij<Korpa> korpaRepozitorij,
            IAplikacijskiLog<KorpaServis> loger)
        {
            _korpaRepozitorij = korpaRepozitorij;
            _loger = loger;
        }

        public async Task DodajStavkuKorpa(int korpaId, int katalogStavkaId, decimal cijena, int kolicina = 1)
        {
            var korpaSpec = new KorpaSaStavkamaSpecifikacija(korpaId);
            var korpa = await _korpaRepozitorij.PrviIliDefaultAsinhrono(korpaSpec);
            Guard.Against.NullKorpa(korpaId, korpa);

            korpa.DodajStavku(katalogStavkaId, cijena, kolicina);

            await _korpaRepozitorij.AzurirajAsinhrono(korpa);
        }

        public async Task IzbrisiKorpuAsinhrono(int korpaId)
        {
            var korpa = await _korpaRepozitorij.DohvatiPoIduAsinhrono(korpaId);
            await _korpaRepozitorij.IzbrisiAsinhrono(korpa);
        }

        public async Task PostaviKolicine(int korpaId, Dictionary<string, int> kolicine)
        {
            Guard.Against.Null(kolicine, nameof(kolicine));
            var korpaSpec = new KorpaSaStavkamaSpecifikacija(korpaId);
            var korpa = await _korpaRepozitorij.PrviIliDefaultAsinhrono(korpaSpec);
            Guard.Against.NullKorpa(korpaId, korpa);

            foreach (var stavka in korpa.Stavke)
            {
                if (kolicine.TryGetValue(stavka.Id.ToString(), out var kolicina))
                {
                    if (_loger != null) _loger.LogInformacija($"Promjena količine proizvoda sa ID-em:{stavka.Id} u {kolicina}.");
                    stavka.PostaviKolicinu(kolicina);
                }
            }
            korpa.UkloniPrazneStavke();
            await _korpaRepozitorij.AzurirajAsinhrono(korpa);
        }

        public async Task PrebaciKorpu(string anonimniId, string korisnickoIme)
        {
            Guard.Against.NullOrEmpty(anonimniId, nameof(anonimniId));
            Guard.Against.NullOrEmpty(korisnickoIme, nameof(korisnickoIme));
            var anonimnaKorpaSpec = new KorpaSaStavkamaSpecifikacija(anonimniId);
            var anonimnaKorpa = await _korpaRepozitorij.PrviIliDefaultAsinhrono(anonimnaKorpaSpec);
            if (anonimnaKorpa == null) return;
            var korisnikKorpaSpec = new KorpaSaStavkamaSpecifikacija(korisnickoIme);
            var korisnikKorpa = await _korpaRepozitorij.PrviIliDefaultAsinhrono(korisnikKorpaSpec);
            if (korisnikKorpa == null)
            {
                korisnikKorpa = new Korpa(korisnickoIme);
                await _korpaRepozitorij.DodajAsinhrono(korisnikKorpa);
            }
            foreach (var stavka in anonimnaKorpa.Stavke)
            {
                korisnikKorpa.DodajStavku(stavka.KatalogStavkaId, stavka.JedinicnaCijena, stavka.Kolicina);
            }
            await _korpaRepozitorij.AzurirajAsinhrono(korisnikKorpa);
            await _korpaRepozitorij.IzbrisiAsinhrono(anonimnaKorpa);
        }
    }
}

