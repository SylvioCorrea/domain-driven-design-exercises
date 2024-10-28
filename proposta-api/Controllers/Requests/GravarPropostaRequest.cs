namespace proposta_api.Controllers.Requests;

public record GravarPropostaRequest
{
    public string CpfCliente { get; init; }

    public EnderecoRequest Endereco { get; init; }

    public ContatoRequest Contato { get; init; }

    public string TipoOperacao { get; init; }

    public string MatriculaRendimento { get; init; }

    public string Conveniada { get; init; }

    public decimal ValorEmprestimo { get; init; }

    public decimal Prestacao { get; init; }

    public int Prazo { get; init; }
}

public record EnderecoRequest(
    string Rua,
    string Numero,
    string Bairro,
    string Cidade,
    string Estado,
    string CEP
);

public record ContatoRequest(
    string DDD,
    string Telefone,
    string Email
);
