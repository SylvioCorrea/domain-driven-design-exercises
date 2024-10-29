using CSharpFunctionalExtensions;

namespace proposta_api.Dominio;

public class Proposta
{
    public Cliente Cliente { get; init; }

    public string Agente { get; init; }

    public long IdOperacao { get; init; }

    public string TipoOperacao { get; init; }

    public int Conveniada { get; init; }

    public string Rendimento { get; init; }

    public decimal ValorEmprestimo { get; init; }

    public decimal Prestacao { get; init; }

    public int Prazo { get; init; }

    public string IdAgente { get; init; }

    public TipoAssinatura TipoAssinatura { get; init; }

    private Proposta(
        Cliente cliente,
        string agente,
        long idOperacao,
        string tipoOperacao,
        int conveniada,
        string rendimento,
        decimal valorEmprestimo,
        decimal prestacao,
        int prazo,
        string idAgente)
    {
        Cliente = cliente;
        Agente = agente;
        IdOperacao = idOperacao;
        TipoOperacao = tipoOperacao;
        Conveniada = conveniada;
        Rendimento = rendimento;
        ValorEmprestimo = valorEmprestimo;
        Prestacao = prestacao;
        Prazo = prazo;
        IdAgente = idAgente;
    }

    public static Result<Proposta> Create(Cliente cliente, DadosOperacao dadosOperacao, Agente agente, Conveniada conveniada)
    {
        var result = Result.Combine(Result.Failure("1"), Result.Failure("2"));

        return new Proposta(
            cliente: cliente,
            agente: agente.Loja,
            idOperacao: dadosOperacao.IdOperacao,
            tipoOperacao: dadosOperacao.TipoOperacao,
            conveniada: conveniada.IdConveniada,
            rendimento: dadosOperacao.Rendimento,
            valorEmprestimo: dadosOperacao.ValorEmprestimo,
            prestacao: dadosOperacao.Prestacao,
            prazo: dadosOperacao.Prazo,
            idAgente: agente.IdAgente
        );
    }
}

public record Cliente(
    string Cpf,
    string Nome,
    string Sexo,
    DateOnly DataNascimento,
    string UfNaturalidade,
    string CidadeNaturalidade,
    Endereco Endereco,
    Contato Contato
);

public record Endereco(
    string Rua,
    string Numero,
    string Bairro,
    string Cidade,
    string Estado,
    string CEP
);

public record Contato(
    string Ddd,
    string Telefone,
    string Email
);

public record DadosOperacao(
    long IdOperacao,
    string TipoOperacao,
    int Conveniada,
    string Rendimento,
    decimal ValorEmprestimo,
    decimal Prestacao,
    int Prazo,
    string IdAgente
);

public record Conveniada(
    int IdConveniada,
    bool AceitaRefinanciamento,
    IDictionary<string, decimal> LimiteValorPorUf
);

public record Agente(
    string IdAgente,
    string Loja,
    bool Ativo
);

public enum TipoAssinatura
{
    Eletronica,
    Figital,
    Fisica
}