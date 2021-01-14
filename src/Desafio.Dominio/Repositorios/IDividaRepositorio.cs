using Desafio.Compartilhado.Interfaces;
using Desafio.Dominio.Entidades;
using System.Threading.Tasks;

namespace Desafio.Dominio.Repositorios
{
    public interface IDividaRepositorio : IRepositorioBase<Divida>
    {
        Task<Divida> ObterPorNumeroAsync(string numero);
    }
}