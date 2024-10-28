namespace proposta_api.Dominio;

public record EnderecoDominio(
    string Rua,
    string Numero,
    string Bairro,
    string Cidade,
    string Estado,
    string CEP
);
