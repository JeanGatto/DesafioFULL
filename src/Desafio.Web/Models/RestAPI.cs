using RestSharp;

namespace Desafio.Web.Models
{
    public static class RestAPI
    {
        public static readonly RestClient Client = new RestClient("https://localhost:44397/api/")
        {
            ThrowOnAnyError = false
        };
    }
}