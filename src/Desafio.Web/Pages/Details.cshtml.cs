using Desafio.Aplicacao.Respostas;
using Desafio.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;
using System.Threading.Tasks;

namespace Desafio.Web.Pages
{
    public class DetailsModel : PageModel
    {
        public DividaResposta Divida { get; private set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var request = new RestRequest($"dividas/{id}", Method.GET, DataFormat.Json);
            var response = await RestAPI.Client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                Divida = response.Content.FromJson<DividaResposta>();
                return Page();
            }
            else
            {
                return RedirectToPage("./NotFound");
            }
        }
    }
}
