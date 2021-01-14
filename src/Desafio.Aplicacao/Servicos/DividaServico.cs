using AutoMapper;
using Desafio.Aplicacao.Interfaces;
using Desafio.Aplicacao.Requisicoes;
using Desafio.Aplicacao.Respostas;
using Desafio.Dominio.Entidades;
using Desafio.Dominio.Repositorios;
using Desafio.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Aplicacao.Servicos
{
    public class DividaServico : IDividaServico
    {
        private readonly IMapper _mapeador;
        private readonly IDividaRepositorio _repositorio;

        public DividaServico(IMapper mapeador, IDividaRepositorio repositorio)
        {
            _mapeador = mapeador;
            _repositorio = repositorio;
        }

        public async Task<ApiResultado<DividaResposta>> CriarAsync(DividaRequisicao requisicao)
        {
            var resultado = new ApiResultado<DividaResposta>();

            requisicao.Validar();
            if (requisicao.Invalido)
            {
                return resultado.Falha(requisicao.Notificacoes);
            }

            var devedor = new Devedor(
                requisicao.NomeCompleto.Trim(),
                requisicao.CPF.SomenteNumeros());

            var divida = new Divida(
                requisicao.Numero.Trim(),
                requisicao.Multa,
                requisicao.JurosAoMes,
                devedor);

            foreach (var parcelaReq in requisicao.Parcelas)
            {
                divida.AdicionarParcela(new Parcela(
                    parcelaReq.Numero,
                    parcelaReq.DataVencimento,
                    parcelaReq.Valor));
            }

            _repositorio.Adicionar(divida);
            await _repositorio.SalvarAlteracoesAsync();

            var resposta = _mapeador.Map<DividaResposta>(divida);
            return resultado.Sucesso("Cadastrado com sucesso.", resposta);
        }

        public async Task<IEnumerable<DividaGridResposta>> ListarAsync()
        {
            var dividas = await _repositorio.ListarAsync();
            return _mapeador.Map<IEnumerable<DividaGridResposta>>(dividas);
        }

        public async Task<ApiResultado<DividaResposta>> ObterPorIdAsync(int id)
        {
            var resultado = new ApiResultado<DividaResposta>();

            var divida = await _repositorio.ObterPorIdAsync(id);
            if (divida == null)
            {
                return resultado.Falha($"Registro não encontrado: {id}.", true);
            }

            var resposta = _mapeador.Map<DividaResposta>(divida);
            return resultado.Sucesso(resposta);
        }

        public async Task<ApiResultado<DividaResposta>> ObterPorNumeroAsync(ObterDividaPorNumeroRequisicao requisicao)
        {
            var resultado = new ApiResultado<DividaResposta>();

            requisicao.Validar();
            if (requisicao.Invalido)
            {
                return resultado.Falha(requisicao.Notificacoes);
            }

            var divida = await _repositorio.ObterPorNumeroAsync(requisicao.Numero);
            if (divida == null)
            {
                return resultado.Falha($"Registro não encontrado: {requisicao.Numero}", true);
            }

            var resposta = _mapeador.Map<DividaResposta>(divida);
            return resultado.Sucesso(resposta);
        }

        #region Dispose

        // Flag: Has Dispose already been called?
        private bool _disposed = false;

        ~DividaServico()
        {
            Dispose(false);
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Free any other managed objects here.
                _repositorio.Dispose();
            }

            // Free any unmanaged objects here.
            _disposed = true;
        }

        #endregion
    }
}