namespace proposta_api.Aplicacao.Requests;

public record GravacaoPropostaRequest
{
    public string CpfCliente { get; init; }

    public long IdOperacao { get; init; }
}