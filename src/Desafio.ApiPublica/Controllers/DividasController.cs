using Desafio.Aplicacao;
using Desafio.Aplicacao.Interfaces;
using Desafio.Aplicacao.Requisicoes;
using Desafio.Aplicacao.Respostas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Desafio.ApiPublica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class DividasController : ControllerBase
    {
        private readonly IDividaServico _servico;

        public DividasController(IDividaServico servico)
        {
            _servico = servico;
        }

        // POST: api/dividas
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResultado<DividaResposta>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResultado<DividaResposta>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Criar([FromBody] DividaRequisicao requisicao)
        {
            var resultado = await _servico.CriarAsync(requisicao);
            if (!resultado.BemSucedido)
            {
                return BadRequest(resultado);
            }

            return Ok(resultado.Dados);
        }

        // GET: api/dividas/{id}
        [HttpGet("{id:int}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(DividaResposta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResultado<DividaResposta>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            var resultado = await _servico.ObterPorIdAsync(id);
            if (!resultado.BemSucedido)
            {
                return NotFound(resultado);
            }

            return Ok(resultado.Dados);
        }

        // GET: api/dividas/{numero}/numero
        [HttpGet("{numero}/numero")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(DividaResposta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResultado<DividaResposta>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResultado<DividaResposta>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterPorNumero([FromRoute] string numero)
        {
            var resultado = await _servico.ObterPorNumeroAsync(new ObterDividaPorNumeroRequisicao(numero));
            if (!resultado.BemSucedido)
            {
                if (resultado.RecursoNaoEncontrado)
                {
                    return NotFound(resultado);
                }

                return BadRequest(resultado);
            }

            return Ok(resultado.Dados);
        }

        // GET: api/dividas
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<DividaResposta>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _servico.ListarAsync());
        }
    }
}
