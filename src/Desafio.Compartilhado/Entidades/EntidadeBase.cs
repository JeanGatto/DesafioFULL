using Desafio.Compartilhado.Interfaces;
using System;

namespace Desafio.Compartilhado.Entidades
{
    public abstract class EntidadeBase : IEntidadeChave<int>
    {
        protected EntidadeBase()
        {
            CadastradoEm = DateTime.Now;
        }

        public int Id { get; }
        public DateTime CadastradoEm { get; }
    }
}