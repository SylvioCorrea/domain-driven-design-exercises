using CSharpFunctionalExtensions;
using proposta_api.Dominio.Proposta;

namespace proposta_api.Dominio.Proposta.Repositorio;

public interface IPropostaRepository
{
    Task<bool> ClienteTemPropostaAberta(string cpf);

    Task<bool> ClienteBloqueado(string cpf);

    Task<Maybe<Cliente>> ObterCliente(string cpf);

    Task<Maybe<DadosOperacao>> ObterDadosOperacao(long idOperacao);

    Task<Maybe<Agente>> ObterAgente(string agente);

    Task<Maybe<Conveniada>> ObterConveniada(int idConveniada);

    Task<Result> InserirProposta(Proposta proposta);

    Task<UnidadeFederativa> ObterUnidadeFederativa(string uf);
}
