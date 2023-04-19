

namespace StoresG8.WEB.Shared.Responses
{
    using Newtonsoft.Json;

    namespace StoresG8.Shared.Responses
    {
        public class CountryResponse
    {
        // Consumimos por medio del postman
        // Son parametros que llegan de afuera de la api que vamos a consumir
        
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("iso2")]
        public string? Iso2 { get; set; }

        }
    }
}
