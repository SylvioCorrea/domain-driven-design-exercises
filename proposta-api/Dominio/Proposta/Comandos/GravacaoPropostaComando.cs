using CSharpFunctionalExtensions;

namespace proposta_api.Dominio.Proposta.Comandos;

public class GravacaoPropostaComando
{
    public string CpfCliente { get; init; }

    public long IdOperacao { get; init; }

    private GravacaoPropostaComando(string cpfCliente, long idOperacao)
    {
        CpfCliente = cpfCliente;
        IdOperacao = idOperacao;
    }

    public static Result<GravacaoPropostaComando> Criar(string cpfCliente, long idOperacao) => Result
        .Combine(
            Result.FailureIf(string.IsNullOrEmpty(cpfCliente), "Cpf inválido"),
            Result.FailureIf(idOperacao <= 0, "Id da Operacao inválido"))
        .Bind(() => Result.Success<GravacaoPropostaComando>(new(cpfCliente, idOperacao)));
}