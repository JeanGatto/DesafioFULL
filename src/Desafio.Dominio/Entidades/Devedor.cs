using Desafio.Compartilhado.Entidades;
using System.Collections.Generic;

namespace Desafio.Dominio.Entidades
{
    public class Devedor : EntidadeBase
    {
        public Devedor(string nomeCompleto, string cpf)
        {
            NomeCompleto = nomeCompleto;
            CPF = cpf;
        }

        protected Devedor()
        {
        }

        public string NomeCompleto { get; private set; }
        public string CPF { get; private set; }

        public IReadOnlyCollection<Divida> Dividas { get; private set; }
    }
}