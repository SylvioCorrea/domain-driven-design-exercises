using CSharpFunctionalExtensions;
using proposta_api.Dominio.Proposta.Validacao;

namespace proposta_api.Dominio.Proposta;

public class Proposta
{
    public Cliente Cliente { get; init; }

    public TipoOperacao TipoOperacao { get; init; }

    public int Conveniada { get; init; }

    public string Rendimento { get; init; }

    public decimal ValorEmprestimo { get; init; }

    public decimal Prestacao { get; init; }

    public int Prazo { get; init; }

    public string IdAgente { get; init; }

    public TipoAssinatura TipoAssinatura { get; init; }

    private Proposta(
        Cliente cliente,
        TipoOperacao tipoOperacao,
        int conveniada,
        string rendimento,
        decimal valorEmprestimo,
        decimal prestacao,
        int prazo,
        string idAgente,
        TipoAssinatura tipoAssinatura)
    {
        Cliente = cliente;
        TipoOperacao = tipoOperacao;
        Conveniada = conveniada;
        Rendimento = rendimento;
        ValorEmprestimo = valorEmprestimo;
        Prestacao = prestacao;
        Prazo = prazo;
        IdAgente = idAgente;
        TipoAssinatura = tipoAssinatura;
    }

    public static Result<Proposta> Create(
        Cliente cliente,
        DadosOperacao dadosOperacao,
        Agente agente,
        Conveniada conveniada)
    {
        var validacaoContext = new ValidacaoPropostaContext(cliente, dadosOperacao, agente, conveniada);
        
        var validacoes = ValidacaoProposta.ObterValidacoes();

        var resultadoValidacao = Result.Combine(
            validacoes.Select(v => v.Validar(validacaoContext)));
        
        if (resultadoValidacao.IsFailure)
            return resultadoValidacao.ConvertFailure<Proposta>();
        
        var tipoAssinatura = ObterTipoAssinatura(cliente);

        return new Proposta(
            cliente: cliente,
            tipoOperacao: dadosOperacao.TipoOperacao,
            conveniada: conveniada.IdConveniada,
            rendimento: dadosOperacao.Rendimento,
            valorEmprestimo: dadosOperacao.ValorEmprestimo,
            prestacao: dadosOperacao.Prestacao,
            prazo: dadosOperacao.Prazo,
            idAgente: agente.IdAgente,
            tipoAssinatura: tipoAssinatura
        );
    }

    public static TipoAssinatura ObterTipoAssinatura(Cliente cliente)
    {
        if (cliente.UfNaturalidade.Ddds.Contains(cliente.Contato.Ddd))
            return TipoAssinatura.Eletronica;

        if (cliente.Endereco.Uf.SomenteAssinaturaHibrida)
            return TipoAssinatura.Hibrida;

        return TipoAssinatura.Figital;
    }
}

public record Cliente(
    string Cpf,
    string Nome,
    string Sexo,
    DateOnly DataNascimento,
    UnidadeFederativa UfNaturalidade,
    string CidadeNaturalidade,
    Endereco Endereco,
    Contato Contato
);

public record Endereco(
    string Rua,
    string Numero,
    string Bairro,
    string Cidade,
    UnidadeFederativa Uf,
    string CEP
);

public record UnidadeFederativa (
    string Uf,
    IEnumerable<string> Ddds,
    IDictionary<int, decimal> ValorMaximoConveniada,
    bool SomenteAssinaturaHibrida
);

public record Contato(
    string Ddd,
    string Telefone,
    string Email
);

public record DadosOperacao(
    long IdOperacao,
    TipoOperacao TipoOperacao,
    int Conveniada,
    string Rendimento,
    decimal ValorEmprestimo,
    decimal Prestacao,
    int Prazo,
    string IdAgente
);

public record Conveniada(
    int IdConveniada,
    bool AceitaRefinanciamento
);

public record Agente(
    string IdAgente,
    string Loja,
    bool Ativo
);

public enum TipoOperacao { Novo, Refinanciamento }

public enum TipoAssinatura { Eletronica, Figital, Hibrida }