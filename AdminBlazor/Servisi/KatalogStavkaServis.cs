using DijeljeniBlazor;
using DijeljeniBlazor.Interfejsi;
using DijeljeniBlazor.Modeli;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AdminBlazor.Servisi
{
    public class KatalogStavkaServis : IKatalogStavkaServis
    {
        private readonly IKatalogBrendServis _brendServis;
        private readonly IKatalogTipServis _tipServis;
        private readonly HttpServis _httpServis;
        private readonly ILogger<KatalogStavkaServis> _loger;
        private string _apiUrl;

        public KatalogStavkaServis(IKatalogBrendServis brendServis,
            IKatalogTipServis tipServis,
            HttpServis httpServis,
            KonfiguracijaBazniUrl konfiguracijaBazniUrl,
            ILogger<KatalogStavkaServis> loger)
        {
            _brendServis = brendServis;
            _tipServis = tipServis;

            _httpServis = httpServis;
            _loger = loger;
            _apiUrl = konfiguracijaBazniUrl.BazniApi;
        }

        public async Task<KatalogStavka> Kreiraj(KreirajKatalogStavkuZahtjev katalogStavka)
        {
            return (await _httpServis.HttpPosalji<KreirajKatalogStavkuOdgovor>("catalog-items", katalogStavka)).KatalogStavka;
        }

        public async Task<KatalogStavka> Uredi(KatalogStavka katalogStavka)
        {
            return (await _httpServis.HttpIzmijeni<UrediKatalogStavkuOdgovor>("catalog-items", katalogStavka)).KatalogStavka;
        }

        public async Task<string> Obrisi(int katalogStavkaId)
        {
            return (await _httpServis.HttpObrisi<IzbrisiKatalogStavkuOdgovor>("catalog-items", katalogStavkaId)).Status;
        }

        public async Task<KatalogStavka> DohvatiPoIdu(int id)
        {
            var brendListaZadatak = _brendServis.Lista();
            var tipListaZadatak = _tipServis.Lista();
            var stavkaDohvatiZadatak = _httpServis.HttpDohvati<UrediKatalogStavkuOdgovor>($"catalog-items/{id}");
            await Task.WhenAll(brendListaZadatak, tipListaZadatak, stavkaDohvatiZadatak);
            var brendovi = brendListaZadatak.Result;
            var tipovi = tipListaZadatak.Result;
            var katalogStavka = stavkaDohvatiZadatak.Result.KatalogStavka;
            katalogStavka.KatalogBrend = brendovi.FirstOrDefault(b => b.Id == katalogStavka.KatalogBrendId)?.Naziv;
            katalogStavka.KatalogTip = tipovi.FirstOrDefault(t => t.Id == katalogStavka.KatalogTipId)?.Naziv;
            return katalogStavka;
        }

        public async Task<List<KatalogStavka>> ListaStranice(int velicinaStranice)
        {
            _loger.LogInformation("Učitavanje elemenata kataloga iz API-ja.");

            var brendListaZadatak = _brendServis.Lista();
            var tipListaZadatak = _tipServis.Lista();
            var stavkaListaZadatak = _httpServis.HttpDohvati<StranicaKatalogStavkaOdgovor>($"catalog-items?PageSize=10");
            await Task.WhenAll(brendListaZadatak, tipListaZadatak, stavkaListaZadatak);
            var brendovi = brendListaZadatak.Result;
            var tipovi = tipListaZadatak.Result;
            var stavke = stavkaListaZadatak.Result.KatalogStavke;
            foreach (var stavka in stavke)
            {
                stavka.KatalogBrend = brendovi.FirstOrDefault(b => b.Id == stavka.KatalogBrendId)?.Naziv;
                stavka.KatalogTip = tipovi.FirstOrDefault(t => t.Id == stavka.KatalogTipId)?.Naziv;
            }
            return stavke;
        }

        public async Task<List<KatalogStavka>> Lista()
        {
            _loger.LogInformation("Učitavanje elemenata kataloga iz API-ja.");

            var brendListaZadatak = _brendServis.Lista();
            var tipListaZadatak = _tipServis.Lista();
            var stavkaListaZadatak = _httpServis.HttpDohvati<StranicaKatalogStavkaOdgovor>($"catalog-items?PageSize=100");
            await Task.WhenAll(brendListaZadatak, tipListaZadatak, stavkaListaZadatak);
            var brendovi = brendListaZadatak.Result;
            var tipovi = tipListaZadatak.Result;
            var stavke = stavkaListaZadatak.Result.KatalogStavke;
            foreach (var stavka in stavke)
            {
                stavka.KatalogBrend = brendovi.FirstOrDefault(b => b.Id == stavka.KatalogBrendId)?.Naziv;
                stavka.KatalogTip = tipovi.FirstOrDefault(t => t.Id == stavka.KatalogTipId)?.Naziv;
            }
            return stavke;
        }
    }
}
