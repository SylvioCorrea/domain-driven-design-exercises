using CSharpFunctionalExtensions;

namespace proposta_api.Dominio.Repositorio;

public interface IPropostaRepositorio
{
    Task<bool> ClienteTemPropostaAberta(string cpf);

    Task<bool> ClienteBloqueado(string cpf);

    Task<bool> AgenteAtivo(string agente);

    Task<Maybe<Cliente>> ObterCliente(string cpf);

    Task<Maybe<DadosOperacao>> ObterDadosOperacao(long idOperacao);

    Task<Maybe<Agente>> ObterAgente(string agente);

    Task<Maybe<Conveniada>> ObterConveniada(int idConveniada);
}
