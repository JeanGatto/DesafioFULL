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

            CreateMap<Divida, DividaGridResposta>(MemberList.Destination)
                .ForMember(dest => dest.NomeCompleto, opt => opt.MapFrom(src => src.Devedor.NomeCompleto))
                .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.Devedor.CPF));

            CreateMap<Parcela, ParcelaResposta>(MemberList.Destination);
        }
    }
}
