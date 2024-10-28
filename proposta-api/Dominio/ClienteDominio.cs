namespace proposta_api.Dominio;

public class ClienteDominio
{
    public string Cpf { get; init; }

    public string Nome { get; init; }

    public string Sexo { get; init; }

    public DateOnly DataNascimento { get; init; }

    public string UfNaturalidade { get; init; }
}