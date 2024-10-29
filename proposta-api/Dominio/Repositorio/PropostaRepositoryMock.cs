using CSharpFunctionalExtensions;

namespace proposta_api.Dominio.Repositorio;

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

    public async Task<bool> InserirProposta(Proposta proposta)
    {
        return true;
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
        var endereco = new Endereco(
            Rua: "Rua das Flores",
            Numero: "123",
            Bairro: "Centro",
            Cidade: "Porto Alegre",
            Estado: "SP",
            CEP: "01000-000"
        );

        // Creating an instance of Contato
        var contato = new Contato(
            Ddd: "11",
            Telefone: "987654321",
            Email: "cliente@example.com"
        );

        // Creating an instance of Cliente
        var cliente = new Cliente(
            Cpf: "12345678900",
            Nome: "João da Silva",
            Sexo: "M",
            DataNascimento: new DateOnly(1985, 5, 23),
            UfNaturalidade: "RS",
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
            AceitaRefinanciamento: true,
            LimiteValorPorUf: new Dictionary<string, decimal>
            {
                { "RS", 10_000.00m },
                { "RJ", 15000.00m },
                { "MG", 18000.00m }
            }
        );

        return conveniada;
    }

    public async Task<Maybe<DadosOperacao>> ObterDadosOperacao(long idOperacao)
    {
        var dadosOperacao = new DadosOperacao(
            IdOperacao: 123456789,
            TipoOperacao: "Novo",
            Conveniada: 20,
            Rendimento: "1122334455",
            ValorEmprestimo: 5000.00m,
            Prestacao: 230.00m,
            Prazo: 24,
            IdAgente: "AGT123"
        );

        return dadosOperacao;
    }
}
