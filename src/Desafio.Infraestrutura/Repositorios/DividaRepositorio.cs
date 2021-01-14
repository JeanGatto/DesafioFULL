using Desafio.Dominio.Entidades;
using Desafio.Dominio.Repositorios;
using Desafio.Infraestrutura.Contexto;
using Desafio.Infraestrutura.Repositorios.Comum;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Infraestrutura.Repositorios
{
    public class DividaRepositorio : RepositorioBase<Divida>, IDividaRepositorio
    {
        public DividaRepositorio(DesafioContexto contexto)
            : base(contexto)
        {
        }

        public override async Task<IEnumerable<Divida>> ListarAsync()
        {
            return await DbSet
                .AsNoTracking()
                .Include(divida => divida.Devedor)
                .OrderBy(divida => divida.CadastradoEm)
                .ThenBy(divida => divida.Devedor)
                .ToListAsync();
        }

        public override Task<Divida> ObterPorIdAsync(int id)
        {
            return DbSet
                .AsNoTracking()
                .Include(divida => divida.Parcelas)
                .Include(divida => divida.Devedor)
                .FirstOrDefaultAsync(divida => divida.Id == id);
        }

        public Task<Divida> ObterPorNumeroAsync(string numero)
        {
            return DbSet
                .AsNoTracking()
                .Include(divida => divida.Parcelas)
                .Include(divida => divida.Devedor)
                .FirstOrDefaultAsync(divida => divida.Numero == numero);
        }
    }
}