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
    public class KatalogBrendServis : IKatalogBrendServis
    {
        private readonly HttpClient _httpKlijent;
        private readonly ILogger<KatalogBrendServis> _loger;
        private string _apiUrl;

        public KatalogBrendServis(HttpClient httpKlijent,
            KonfiguracijaBazniUrl konfiguracijaBazniUrl,
            ILogger<KatalogBrendServis> loger)
        {
            _httpKlijent = httpKlijent;
            _loger = loger;
            _apiUrl = konfiguracijaBazniUrl.BazniApi;
        }

        public async Task<KatalogBrend> DohvatiPoIdu(int id)
        {
            return (await Lista()).FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<KatalogBrend>> Lista()
        {
            _loger.LogInformation("Učitavanje brendova iz API-ja.");
            return (await _httpKlijent.GetFromJsonAsync<KatalogBrendOdgovor>($"{_apiUrl}catalog-brands"))?.KatalogBrendovi;
        }
    }
}
