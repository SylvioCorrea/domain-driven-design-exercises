using CSharpFunctionalExtensions;

namespace proposta_api.Dominio.Proposta.Repositorio;

public class PropostaRepositoryMock : IPropostaRepository
{
    public async Task<bool> ClienteBloqueado(string cpf)
    {
        return false;
    }

    public async Task<bool> ClienteTemPropostaAberta(string cpf)
    {
        return false;
    }

    public async Task<Result> InserirProposta(Proposta proposta)
    {
        return Result.Success();
    }

    public async Task<Maybe<Agente>> ObterAgente(string idAgente)
    {
        var agente = new Agente(
            IdAgente: "AGT123",
            Loja: "0123",
            Ativo: true
        );

        return agente;
    }

    public async Task<Maybe<Cliente>> ObterCliente(string cpf)
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

    public async Task<Maybe<Conveniada>> ObterConveniada(int idConveniada)
    {
        var conveniada = new Conveniada(
            IdConveniada: 20,
            AceitaRefinanciamento: true
        );

        return conveniada;
    }

    public async Task<Maybe<DadosOperacao>> ObterDadosOperacao(long idOperacao)
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

    public async Task<UnidadeFederativa> ObterUnidadeFederativa(string uf)
    {
        var unidadeFederativa = new UnidadeFederativa(
            Uf: "RS",
            Ddds: ["51", "53", "54", "55"],
            ValorMaximoConveniada: new Dictionary<int, decimal>
            {
                { 20, 10_000.00m }
            },
            SomenteAssinaturaHibrida: false
        );

        return unidadeFederativa;
    }
}
