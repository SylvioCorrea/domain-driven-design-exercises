using CSharpFunctionalExtensions;

namespace proposta_api.Dominio.Comandos;

public class GravacaoPropostaComando
{
    public string CpfCliente { get; init; }

    public string Agente { get; init; }

    public EnderecoComando Endereco { get; init; }

    public ContatoComando Contato { get; init; }

    public DadosOperacaoComando DadosOperacao { get; init; }

    private GravacaoPropostaComando(
        string cpfCliente,
        string agente,
        EnderecoComando endereco,
        ContatoComando contato,
        DadosOperacaoComando dadosOperacao)
    {
        CpfCliente = cpfCliente;
        Agente = agente;
        Endereco = endereco;
        Contato = contato;
        DadosOperacao = dadosOperacao;
    }

    public static Result<GravacaoPropostaComando> Criar(
        string cpfCliente,
        string agente,
        EnderecoComando endereco,
        ContatoComando contato,
        DadosOperacaoComando dadosOperacao)
    {
        return Result.Success<GravacaoPropostaComando>(new(
            cpfCliente,
            agente,
            endereco,
            contato,
            dadosOperacao));
    }
}

public record EnderecoComando(
    string Rua,
    string Numero,
    string Bairro,
    string Cidade,
    string Estado,
    string CEP
);

public record ContatoComando(
    string DDD,
    string Telefone,
    string Email
);

public record DadosOperacaoComando(
    string TipoOperacao,
    string MatriculaRendimento,
    string Conveniada,
    decimal ValorEmprestimo,
    decimal Prestacao,
    int Prazo
);
