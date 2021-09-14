using Blazored.LocalStorage;
using DijeljeniBlazor.Interfejsi;
using DijeljeniBlazor.Modeli;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminBlazor.Servisi
{
    public class KesiraniKatalogStavkaServisDekorator : IKatalogStavkaServis
    {
        private readonly ILocalStorageService _lokalnaPohranaServis;
        private readonly KatalogStavkaServis _katalogStavkaServis;
        private ILogger<KesiraniKatalogStavkaServisDekorator> _loger;

        public KesiraniKatalogStavkaServisDekorator(ILocalStorageService lokalnaPohranaServis,
            KatalogStavkaServis katalogStavkaServis,
            ILogger<KesiraniKatalogStavkaServisDekorator> loger)
        {
            _lokalnaPohranaServis = lokalnaPohranaServis;
            _katalogStavkaServis = katalogStavkaServis;
            _loger = loger;
        }

        public async Task<List<KatalogStavka>> ListaStranice(int velicinaStranice)
        {
            string kljuc = "items";
            var kesUlaz = await _lokalnaPohranaServis.GetItemAsync<KesUlaz<List<KatalogStavka>>>(kljuc);
            if (kesUlaz != null)
            {
                _loger.LogInformation("Učitavanje predmeta iz lokalnog skladišta.");
                if (kesUlaz.DatumKreiran.AddMinutes(1) > DateTime.UtcNow)
                {
                    return kesUlaz.Vrijednost;
                }
                else
                {
                    _loger.LogInformation($"Učitavanje {kljuc} iz lokalnog skladišta.");
                    await _lokalnaPohranaServis.RemoveItemAsync(kljuc);
                }
            }

            var stavke = await _katalogStavkaServis.ListaStranice(velicinaStranice);
            var ulaz= new KesUlaz<List<KatalogStavka>>(stavke);
            await _lokalnaPohranaServis.SetItemAsync(kljuc, ulaz);
            return stavke;
        }

        public async Task<List<KatalogStavka>> Lista()
        {
            string kljuc = "items";
            var kesUlaz = await _lokalnaPohranaServis.GetItemAsync<KesUlaz<List<KatalogStavka>>>(kljuc);
            if (kesUlaz != null)
            {
                _loger.LogInformation("Učitavanje predmeta iz lokalnog skladišta.");
                if (kesUlaz.DatumKreiran.AddMinutes(1) > DateTime.UtcNow)
                {
                    return kesUlaz.Vrijednost;
                }
                else
                {
                    _loger.LogInformation($"Učitavanje {kljuc} iz lokalnog skladišta.");
                    await _lokalnaPohranaServis.RemoveItemAsync(kljuc);
                }
            }

            var stavke = await _katalogStavkaServis.Lista();
            var ulaz = new KesUlaz<List<KatalogStavka>>(stavke);
            await _lokalnaPohranaServis.SetItemAsync(kljuc, ulaz);
            return stavke;
        }

        public async Task<KatalogStavka> DohvatiPoIdu(int id)
        {
            return (await Lista()).FirstOrDefault(x => x.Id == id);
        }

        public async Task<KatalogStavka> Kreiraj(KreirajKatalogStavkuZahtjev katalogStavka)
        {
            var rezultat = await _katalogStavkaServis.Kreiraj(katalogStavka);
            await OsvjeziListuLokalnaPohrana();

            return rezultat;
        }

        public async Task<KatalogStavka> Uredi(KatalogStavka katalogStavka)
        {
            var rezultat = await _katalogStavkaServis.Uredi(katalogStavka);
            await OsvjeziListuLokalnaPohrana();

            return rezultat;
        }

        public async Task<string> Obrisi(int id)
        {
            var rezultat = await _katalogStavkaServis.Obrisi(id);
            await OsvjeziListuLokalnaPohrana();
            return rezultat;
        }

        private async Task OsvjeziListuLokalnaPohrana()
        {
            string kljuc = "items";

            await _lokalnaPohranaServis.RemoveItemAsync(kljuc);
            var stavke = await _katalogStavkaServis.Lista();
            var ulaz = new KesUlaz<List<KatalogStavka>>(stavke);
            await _lokalnaPohranaServis.SetItemAsync(kljuc, ulaz);
        }
    }
}
