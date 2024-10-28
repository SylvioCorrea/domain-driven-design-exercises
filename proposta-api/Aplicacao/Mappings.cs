using AutoMapper;
using proposta_api.Aplicacao.Requests;
using proposta_api.Dominio.Comandos;

namespace proposta_api.Aplicacao;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<EnderecoRequest, EnderecoComando>().ReverseMap();
        CreateMap<ContatoRequest, ContatoComando>().ReverseMap();
        CreateMap<DadosOperacaoRequest, DadosOperacaoComando>().ReverseMap();
    }
}
