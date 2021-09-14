using DijeljeniBlazor;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdminBlazor.Servisi
{
    public class HttpServis
    {
        private readonly HttpClient _httpKlijent;
        private readonly string _apiUrl;


        public HttpServis(HttpClient httpKlijent, KonfiguracijaBazniUrl konfiguracijaBazniUrl)
        {
            _httpKlijent = httpKlijent;
            _apiUrl = konfiguracijaBazniUrl.BazniApi;
        }

        public async Task<T> HttpDohvati<T>(string uri)
            where T : class
        {
            var rezultat = await _httpKlijent.GetAsync($"{_apiUrl}{uri}");
            if (!rezultat.IsSuccessStatusCode)
            {
                return null;
            }

            return await OdgovorOdHttpPoruka<T>(rezultat);
        }

        public async Task<T> HttpObrisi<T>(string uri, int id)
            where T : class
        {
            var rezultat = await _httpKlijent.DeleteAsync($"{_apiUrl}{uri}/{id}");
            if (!rezultat.IsSuccessStatusCode)
            {
                return null;
            }

            return await OdgovorOdHttpPoruka<T>(rezultat);
        }

        public async Task<T> HttpPosalji<T>(string uri, object podaciZaSlanje)
            where T : class
        {
            var sadrzaj = UJson(podaciZaSlanje);

            var rezultat = await _httpKlijent.PostAsync($"{_apiUrl}{uri}", sadrzaj);
            if (!rezultat.IsSuccessStatusCode)
            {
                return null;
            }

            return await OdgovorOdHttpPoruka<T>(rezultat);
        }

        public async Task<T> HttpIzmijeni<T>(string uri, object podaciZaSlanje)
            where T : class
        {
            var sadrzaj = UJson(podaciZaSlanje);

            var rezultat = await _httpKlijent.PutAsync($"{_apiUrl}{uri}", sadrzaj);
            if (!rezultat.IsSuccessStatusCode)
            {
                return null;
            }

            return await OdgovorOdHttpPoruka<T>(rezultat);
        }


        private StringContent UJson(object obj)
        {
            return new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
        }

        private async Task<T> OdgovorOdHttpPoruka<T>(HttpResponseMessage rezultat)
        {
            return JsonSerializer.Deserialize<T>(await rezultat.Content.ReadAsStringAsync(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
