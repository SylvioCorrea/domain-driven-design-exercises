using proposta_api.Dominio.Comandos;

namespace proposta_api.Dominio;

public class Proposta
{
    public Cliente Cliente { get; init; }

    public string Agente { get; init; }

    public Endereco Endereco { get; init; }

    public Contato Contato { get; init; }

    public DadosOperacao DadosOperacao { get; init; }

}

public record Endereco(
    string Rua,
    string Numero,
    string Bairro,
    string Cidade,
    string Estado,
    string CEP
);

public record Contato(
    string DDD,
    string Telefone,
    string Email
);

public record DadosOperacao(
    string TipoOperacao,
    string MatriculaRendimento,
    string Conveniada,
    decimal ValorEmprestimo,
    decimal Prestacao,
    int Prazo
);