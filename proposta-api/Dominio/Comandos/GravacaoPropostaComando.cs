using CSharpFunctionalExtensions;

namespace proposta_api.Dominio.Comandos;

public class GravacaoPropostaComando
{
    public string CpfCliente { get; init; }

    public string Agente { get; init; }

    public long IdOperacao { get; init; }

    private GravacaoPropostaComando(
        string cpfCliente,
        string agente,
        long idOperacao)
    {
        CpfCliente = cpfCliente;
        Agente = agente;
        IdOperacao = idOperacao;
    }

    public static Result<GravacaoPropostaComando> Criar(
        string cpfCliente,
        string agente,
        long idOperacao)
    {
        return Result.Success<GravacaoPropostaComando>(new(
            cpfCliente,
            agente,
            idOperacao));
    }
}