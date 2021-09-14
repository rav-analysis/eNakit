using DijeljeniBlazor;
using DijeljeniBlazor.Interfejsi;
using DijeljeniBlazor.Modeli;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AdminBlazor.Servisi
{
    public class KatalogTipServis : IKatalogTipServis
    {
        private readonly HttpClient _httpKlijent;
        private readonly ILogger<KatalogTipServis> _loger;
        private string _apiUrl;

        public KatalogTipServis(HttpClient httpKlijent,
            KonfiguracijaBazniUrl konfiguracijaBazniUrl,
            ILogger<KatalogTipServis> loger)
        {
            _httpKlijent = httpKlijent;
            _loger = loger;
            _apiUrl = konfiguracijaBazniUrl.BazniApi;
        }

        public async Task<KatalogTip> DohvatiPoIdu(int id)
        {
            return (await Lista()).FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<KatalogTip>> Lista()
        {
            _loger.LogInformation("Učitavanje tipova iz API-ja.");
            return (await _httpKlijent.GetFromJsonAsync<KatalogTipOdgovor>($"{_apiUrl}catalog-types"))?.KatalogTipovi;
        }
    }
}
