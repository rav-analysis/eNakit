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
    public class KesiraniKatalogTipServisDekorator : IKatalogTipServis
    {
        private readonly ILocalStorageService _lokalnaPohranaServis;
        private readonly KatalogTipServis _katalogTipServis;
        private ILogger<KesiraniKatalogTipServisDekorator> _loger;

        public KesiraniKatalogTipServisDekorator(ILocalStorageService lokalnaPohranaServis,
            KatalogTipServis katalogTipServis,
            ILogger<KesiraniKatalogTipServisDekorator> loger)
        {
            _lokalnaPohranaServis = lokalnaPohranaServis;
            _katalogTipServis = katalogTipServis;
            _loger = loger;
        }

        public async Task<KatalogTip> DohvatiPoIdu(int id)
        {
            return (await Lista()).FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<KatalogTip>> Lista()
        {
            string kljuc = "types";
            var kesUlaz = await _lokalnaPohranaServis.GetItemAsync<KesUlaz<List<KatalogTip>>>(kljuc);
            if (kesUlaz != null)
            {
                _loger.LogInformation("Učitavanje tipova iz lokalnog skladišta.");
                if (kesUlaz.DatumKreiran.AddMinutes(1) > DateTime.UtcNow)
                {
                    return kesUlaz.Vrijednost;
                }
                else
                {
                    _loger.LogInformation("Keš istekao, uklanjanje tipova iz lokalnog skladišta.");
                    await _lokalnaPohranaServis.RemoveItemAsync(kljuc);
                }
            }

            var tipovi = await _katalogTipServis.Lista();
            var ulaz = new KesUlaz<List<KatalogTip>>(tipovi);
            await _lokalnaPohranaServis.SetItemAsync(kljuc, ulaz);
            return tipovi;
        }
    }
}
