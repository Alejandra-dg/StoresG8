using Newtonsoft.Json;

using StoresG8.Shared.Responses;
using StoresG8.API.Services.Stores.API.Services;
using StoresG8.WEB.Shared.Responses;

namespace Stores.API.Services
{
    public class ApiService : IApiService
    {
        private readonly IConfiguration _configuration;
        private readonly string _urlBase;
        private readonly string _tokenName;
        private readonly string _tokenValue;

        public ApiService(IConfiguration configuration)
        {
            _configuration = configuration;
            _urlBase = _configuration["CountriesAPI:urlBase"]!; // Nombre del Api que elejimos y la Url
            _tokenName = _configuration["CountriesAPI:tokenName"]!; // Nombre del token
            _tokenValue = _configuration["CountriesAPI:tokenValue"]!; // Valor de token 
        }

        public async Task<Response> GetListAsync<T>(string servicePrefix, string controller)
        {
            try
            {
                HttpClient client = new()
                {
                    BaseAddress = new Uri(_urlBase),
                };

                client.DefaultRequestHeaders.Add(_tokenName, _tokenValue);
                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                List<T> list = JsonConvert.DeserializeObject<List<T>>(result)!;
                return new Response
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
       
            
            }
        
        
        }
    }
}

