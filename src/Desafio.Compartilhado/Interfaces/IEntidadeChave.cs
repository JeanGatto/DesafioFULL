namespace Desafio.Compartilhado.Interfaces
{
    public interface IEntidadeChave<TChave>
    {
        public TChave Id { get; }
    }
}