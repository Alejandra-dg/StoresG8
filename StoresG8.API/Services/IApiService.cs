
namespace StoresG8.API.Services
{
    using StoresG8.Shared.Responses;
    using StoresG8.WEB.Shared.Responses;

    // Creamos services cuando vamos a consumir una api
    namespace Stores.API.Services
    {

        public interface IApiService
        {
            Task<Response> GetListAsync<T>(string servicePrefix, string controller);
        }
    }
}
