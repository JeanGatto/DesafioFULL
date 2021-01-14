using AutoMapper;
using Desafio.Aplicacao.Respostas;
using Desafio.Dominio.Entidades;

namespace Desafio.Aplicacao.Mapeador
{
    public class DominioParaRespotaPerfil : Profile
    {
        public DominioParaRespotaPerfil()
        {
            CreateMap<Devedor, DevedorResposta>(MemberList.Destination);
            CreateMap<Divida, DividaResposta>(MemberList.Destination);
            CreateMap<Parcela, ParcelaResposta>(MemberList.Destination);
        }
    }
}
