using Desafio.Compartilhado.Entidades;
using System;

namespace Desafio.Dominio.Entidades
{
    public class Parcela : EntidadeBase
    {
        public Parcela(int numero, DateTime dataVencimento, decimal valor)
        {
            Numero = numero;
            DataVencimento = dataVencimento;
            Valor = valor;
        }

        protected Parcela()
        {
        }

        public int DividaId { get; private set; }
        public int Numero { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public decimal Valor { get; private set; }

        public Divida Divida { get; private set; }
    }
}
