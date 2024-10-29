using CSharpFunctionalExtensions;

namespace proposta_api.Dominio.Repositorio;

public interface IPropostaRepository
{
    Task<bool> ClienteTemPropostaAberta(string cpf);

    Task<bool> ClienteBloqueado(string cpf);

    Task<Maybe<Cliente>> ObterCliente(string cpf);

    Task<Maybe<DadosOperacao>> ObterDadosOperacao(long idOperacao);

    Task<Maybe<Agente>> ObterAgente(string agente);

    Task<Maybe<Conveniada>> ObterConveniada(int idConveniada);

    Task<bool> InserirProposta(Proposta proposta);
}
