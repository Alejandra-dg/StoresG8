// clase generica para todas las apis 
namespace StoresG8.WEB.Shared.Responses
{
    public class Response
    {
        // variable booleana si ocurrio o no
        public bool IsSuccess { get; set; }

        // un mensaje
        public string? Message { get; set; }

        // un resultado 
        public object? Result { get; set; }

    }
}
