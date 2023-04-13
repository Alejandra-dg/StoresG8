using StoresG8.WEB.Shared.Responses;

namespace StoresG8.API.Services
{ 
// Creamos services cuando vamos a consumir una api
    namespace StoresG8.API.Services
    {
    
        public interface IApiService
        {
            Task<Response> GetListAsync<T>(string servicePrefix, string controller);
        }
    }
}
