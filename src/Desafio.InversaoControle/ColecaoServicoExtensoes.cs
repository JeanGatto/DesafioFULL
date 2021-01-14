using AutoMapper;
using Desafio.Aplicacao.Interfaces;
using Desafio.Aplicacao.Mapeador;
using Desafio.Aplicacao.Servicos;
using Desafio.Dominio.Repositorios;
using Desafio.Infraestrutura.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Desafio.InversaoControle
{
    public static class ColecaoServicoExtensoes
    {
        public static void AdicionarInjecaoNativa(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(cfg => cfg.AddProfile<DominioParaRespotaPerfil>());
            services.AddScoped<IDividaRepositorio, DividaRepositorio>();
            services.AddScoped<IDividaServico, DividaServico>();
        }
    }
}