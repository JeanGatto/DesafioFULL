using Desafio.Aplicacao.Respostas;
using Desafio.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Web.Pages
{
    public class IndexModel : PageModel
    {
        public bool IsSuccessful { get; private set; }
        public IEnumerable<DividaGridResposta> Grid { get; private set; }

        public async Task OnGetAsync(bool? Successful)
        {
            if (Successful.HasValue)
            {
                IsSuccessful = true;
            }

            var request = new RestRequest("dividas", Method.GET, DataFormat.Json);
            var response = await RestAPI.Client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                Grid = response.Content.FromJson<IEnumerable<DividaGridResposta>>();
            }
        }
    }
}