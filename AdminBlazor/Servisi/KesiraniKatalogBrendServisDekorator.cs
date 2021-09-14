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
    public class KesiraniKatalogBrendServisDekorator : IKatalogBrendServis
    {
        private readonly ILocalStorageService _lokalnaPohranaServis;
        private readonly KatalogBrendServis _katalogBrendServis;
        private ILogger<KesiraniKatalogBrendServisDekorator> _loger;

        public KesiraniKatalogBrendServisDekorator(ILocalStorageService lokalnaPohranaServis,
            KatalogBrendServis katalogBrendServis,
            ILogger<KesiraniKatalogBrendServisDekorator> loger)
        {
            _lokalnaPohranaServis = lokalnaPohranaServis;
            _katalogBrendServis = katalogBrendServis;
            _loger = loger;

        }

        public async Task<KatalogBrend> DohvatiPoIdu(int id)
        {
            return (await Lista()).FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<KatalogBrend>> Lista()
        {
            string kljuc = "brands";
            var kesUlaz = await _lokalnaPohranaServis.GetItemAsync<KesUlaz<List<KatalogBrend>>>(kljuc);
            if (kesUlaz != null)
            {
                _loger.LogInformation("Učitavanje brendova iz lokalnog skladišta.");
                if (kesUlaz.DatumKreiran.AddMinutes(1) > DateTime.UtcNow)
                {
                    return kesUlaz.Vrijednost;
                }
                else
                {
                    _loger.LogInformation("Keš istekao, uklanjanje brendova iz lokalnog skladišta.");
                    await _lokalnaPohranaServis.RemoveItemAsync(kljuc);
                }
            }

            var brendovi = await _katalogBrendServis.Lista();
            var ulaz = new KesUlaz<List<KatalogBrend>>(brendovi);
            await _lokalnaPohranaServis.SetItemAsync(kljuc, ulaz);
            return brendovi;
        }
    }
}
