using Desafio.Compartilhado.Entidades;
using Desafio.Compartilhado.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Dominio.Entidades
{
    public class Divida : EntidadeBase, IRaizAgregacao
    {
        private readonly List<Parcela> _parcelas = new List<Parcela>();

        public Divida(string numero, decimal multa, decimal jurosAoMes, Devedor devedor)
        {
            Numero = numero;
            Multa = multa;
            JurosAoMes = jurosAoMes;
            Devedor = devedor;
        }

        protected Divida()
        {
        }

        public int DevedorId { get; private set; }
        public string Numero { get; private set; }
        public decimal Multa { get; private set; }
        public decimal JurosAoMes { get; private set; }

        public int QuantidadeParcelas => _parcelas.Count;

        public int DiasEmAtraso
        {
            get
            {
                if (_parcelas.Count == 0)
                    return 0;

                var dataHoje = DateTime.Now;
                var primeiraParcela = _parcelas.OrderBy(p => p.DataVencimento).FirstOrDefault();
                return (int)dataHoje.Subtract(primeiraParcela.DataVencimento).TotalDays;
            }
        }

        public decimal ValorOriginal => _parcelas.Sum(p => p.Valor);

        public decimal TotalMulta
        {
            get
            {
                var multa = ValorOriginal * Multa;
                return Arredondar(multa);
            }
        }

        public decimal TotalJurosDataHoje
        {
            get
            {
                if (_parcelas.Count == 0)
                    return decimal.Zero;

                var dataHoje = DateTime.Now;
                var totalJuros = decimal.Zero;

                foreach (var parcela in _parcelas.OrderBy(p => p.DataVencimento).ThenBy(p => p.Numero))
                {
                    var diasEmAtraso = (int)dataHoje.Subtract(parcela.DataVencimento).TotalDays;
                    var juros = (JurosAoMes / 30) * diasEmAtraso * parcela.Valor;
                    totalJuros += Arredondar(juros);
                }

                return totalJuros;
            }
        }

        public decimal ValorAtualizadoDataHoje
        {
            get
            {
                if (_parcelas.Count == 0)
                    return decimal.Zero;

                var totalJurosMaisMulta = TotalJurosDataHoje + TotalMulta;
                return ValorOriginal + totalJurosMaisMulta;
            }
        }

        public Devedor Devedor { get; private set; }
        public IReadOnlyList<Parcela> Parcelas => _parcelas.AsReadOnly();

        public void AdicionarParcela(Parcela parcela)
        {
            if (parcela == null)
                throw new ArgumentNullException(nameof(parcela));

            _parcelas.Add(parcela);
        }

        private static decimal Arredondar(decimal valor)
            => decimal.Round(valor / 100, 2, MidpointRounding.AwayFromZero);
    }
}