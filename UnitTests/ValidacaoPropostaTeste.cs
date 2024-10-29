using CSharpFunctionalExtensions;
using proposta_api.Dominio.Proposta;
using proposta_api.Dominio.Proposta.Validacao;

namespace UnitTests;

public class ValidacaoPropostaTeste
{
    [Fact]
    public void LimitePrazoPorIdade_Valido()
    {
        var cliente = Cliente();
        var dadosOperacao = DadosOperacao();
        var agente = Agente();
        var conveniada = Conveniada();
        var contexto = new ValidacaoPropostaContext(cliente, dadosOperacao, agente, conveniada);
        
        var validadorLimitePrazoPorIdade = new LimitePrazoPorIdade();

        var result = validadorLimitePrazoPorIdade.Validar(contexto);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void LimitePrazoPorIdade_Invalido()
    {
        var cliente = Cliente() with { DataNascimento = DateOnly.Parse("1940-01-01")};
        var dadosOperacao = DadosOperacao();
        var agente = Agente();
        var conveniada = Conveniada();
        var contexto = new ValidacaoPropostaContext(cliente, dadosOperacao, agente, conveniada);

        var validadorLimitePrazoPorIdade = new LimitePrazoPorIdade();

        var result = validadorLimitePrazoPorIdade.Validar(contexto);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void LimiteValorConveniadaUf_Invalido()
    {
        var cliente = Cliente();
        var dadosOperacao = DadosOperacao() with { ValorEmprestimo = 10_001.00m };
        var agente = Agente();
        var conveniada = Conveniada();
        var contexto = new ValidacaoPropostaContext(cliente, dadosOperacao, agente, conveniada);

        var validador = new LimiteValorConveniadaUf();

        var result = validador.Validar(contexto);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void ConveniadaPermiteRefinanciamento_Invalido()
    {
        var cliente = Cliente();
        var dadosOperacao = DadosOperacao() with { TipoOperacao = TipoOperacao.Refinanciamento };
        var agente = Agente();
        var conveniada = Conveniada() with { AceitaRefinanciamento = false };
        var contexto = new ValidacaoPropostaContext(cliente, dadosOperacao, agente, conveniada);

        var validador = new ConveniadaPermiteRefinanciamento();

        var result = validador.Validar(contexto);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void AgenteAtivo_Invalido()
    {
        var cliente = Cliente();
        var dadosOperacao = DadosOperacao();
        var agente = Agente() with { Ativo = false };
        var conveniada = Conveniada();
        var contexto = new ValidacaoPropostaContext(cliente, dadosOperacao, agente, conveniada);

        var validador = new AgenteAtivo();

        var result = validador.Validar(contexto);

        Assert.False(result.IsSuccess);
    }

    private Cliente Cliente()
    {
        var uf = new UnidadeFederativa(
            Uf: "RS",
            Ddds: ["51", "53", "54", "55"],
            ValorMaximoConveniada: new Dictionary<int, decimal>
            {
                { 20, 10_000.00m }
            },
            SomenteAssinaturaHibrida: false
        );

        var ufNaturalidade = new UnidadeFederativa(
            Uf: "RS",
            Ddds: ["51", "53", "54", "55"],
            ValorMaximoConveniada: new Dictionary<int, decimal>
            {
                { 20, 10_000.00m }
            },
            SomenteAssinaturaHibrida: false
        );

        var endereco = new Endereco(
            Rua: "Rua das Pedras",
            Numero: "123",
            Bairro: "Centro",
            Cidade: "Porto Alegre",
            Uf: uf,
            CEP: "01000-000"
        );

        var contato = new Contato(
            Ddd: "51",
            Telefone: "987654321",
            Email: "joao@example.com"
        );

        var cliente = new Cliente(
            Cpf: "12345678900",
            Nome: "João da Silva",
            Sexo: "M",
            DataNascimento: new DateOnly(1960, 5, 23),
            UfNaturalidade: ufNaturalidade,
            CidadeNaturalidade: "Porto Alegre",
            Endereco: endereco,
            Contato: contato
        );

        return cliente;
    }

    private DadosOperacao DadosOperacao()
    {
        var dadosOperacao = new DadosOperacao(
            IdOperacao: 123456789,
            TipoOperacao: TipoOperacao.Novo,
            Conveniada: 20,
            Rendimento: "1122334455",
            ValorEmprestimo: 5000.00m,
            Prestacao: 230.00m,
            Prazo: 24,
            IdAgente: "AGT123"
        );

        return dadosOperacao;
    }

    private Conveniada Conveniada()
    {
        var conveniada = new Conveniada(
            IdConveniada: 20,
            AceitaRefinanciamento: true
        );

        return conveniada;
    }

    public Agente Agente()
    {
        var agente = new Agente(
            IdAgente: "AGT123",
            Loja: "0123",
            Ativo: true
        );

        return agente;
    }
}