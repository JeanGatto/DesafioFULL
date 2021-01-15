using Desafio.Aplicacao;
using Desafio.Aplicacao.Requisicoes;
using Desafio.Aplicacao.Respostas;
using Desafio.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Web.Pages
{
    public class AddModel : PageModel
    {
        public List<string> Errors { get; private set; } = new List<string>();

        [BindProperty]
        public DividaModel Divida { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var query = from state in ModelState.Values
                            from error in state.Errors
                            select error.ErrorMessage;

                Errors = query.Distinct().ToList();
                return Page();
            }

            Errors.Clear();

            var requisicao = new DividaRequisicao
            {
                Numero = Divida.Numero,
                Multa = Divida.Multa,
                JurosAoMes = Divida.JurosAoMes,
                NomeCompleto = Divida.NomeCompleto,
                CPF = Divida.CPF
            };

            requisicao.Parcelas = Divida.Parcelas.Select(p => new ParcelaRequisicao
            {
                Numero = p.Numero,
                DataVencimento = Convert.ToDateTime(p.DataVencimento),
                Valor = Convert.ToDecimal(p.Valor)
            }).ToList();

            var request = new RestRequest("dividas", Method.POST);
            request.AddJsonBody(requisicao);

            var response = await RestAPI.Client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return RedirectToPage("./Index", new { Successful = true });
            }
            else
            {
                var resultado = response.Content.FromJson<ApiResultado<DividaResposta>>();

                foreach (var notificao in resultado.Erros)
                {
                    Errors.Add(notificao.ToString());
                }

                return Page();
            }
        }
    }
}
