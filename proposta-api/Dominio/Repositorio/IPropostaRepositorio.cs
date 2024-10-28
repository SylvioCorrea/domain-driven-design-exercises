namespace proposta_api.Dominio.Repositorio;

public interface IPropostaRepositorio
{
    Task<bool> ClienteTemPropostaAberta(string cpf);

    Task<bool> ClienteBloqueado(string cpf);

    Task<bool> AgenteAtivo(string agente);
}
