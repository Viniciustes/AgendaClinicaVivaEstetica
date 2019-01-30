using AgendaClinicaVivaEstetica.Apresentacao.Models;
using AgendaClinicaVivaEstetica.Dominio.Entidades;
using AutoMapper;

namespace AgendaClinicaVivaEstetica.Apresentacao.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteViewModel>()
                .ForMember(x => x.IdCliente, y => y.MapFrom(z => z.IdCliente))
                .ForMember(x => x.IdCliente, y => y.MapFrom(z => z.Endereco.IdCliente))
                .ForMember(x => x.IdEndereco, y => y.MapFrom(z => z.Endereco.IdEndereco))
                .ForMember(x => x.Logradouro, y => y.MapFrom(z => z.Endereco.Logradouro))
                .ForMember(x => x.Numero, y => y.MapFrom(z => z.Endereco.Numero))
                .ForMember(x => x.Complemento, y => y.MapFrom(z => z.Endereco.Complemento))
                .ForMember(x => x.Cidade, y => y.MapFrom(z => z.Endereco.Cidade))
                .ForMember(x => x.Estado, y => y.MapFrom(z => z.Endereco.Estado))
                .ForMember(x => x.CEP, y => y.MapFrom(z => z.Endereco.CEP))
                .ReverseMap();

            CreateMap<Marcacao, MarcacaoViewModel>()
                .ForMember(x=> x.EnumTipoServico, y=> y.MapFrom(z=> z.EnumTipoServico))
                .ForPath(x => x.Marcacao.DataMarcacao, y => y.MapFrom(z => z.DataMarcacao))
                .ForPath(x => x.Marcacao.IdMarcacao, y => y.MapFrom(z => z.IdMarcacao))
                .ForPath(x => x.Marcacao.IdCliente, y => y.MapFrom(z => z.IdCliente))
                .ForPath(x => x.Marcacao.Cliente, y => y.MapFrom(z => z.Cliente))
                .ReverseMap();
        }
    }
}
