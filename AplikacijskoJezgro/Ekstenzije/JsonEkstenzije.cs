using System.Text.Json;

namespace eNakit
{
    public static class JsonEkstenzije
    {
        private static readonly JsonSerializerOptions _jsonOpcije = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public static T IzJsona<T>(this string json) =>
            JsonSerializer.Deserialize<T>(json, _jsonOpcije);

        public static string UJson<T>(this T obj) =>
            JsonSerializer.Serialize<T>(obj, _jsonOpcije);
    }
}

