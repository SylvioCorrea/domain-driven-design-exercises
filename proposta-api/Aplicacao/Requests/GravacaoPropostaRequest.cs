using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using proposta_api.Dominio.Comandos;

namespace proposta_api.Aplicacao.Requests;

public record GravacaoPropostaRequest
{
    public string CpfCliente { get; init; }

    public string Agente { get; init; }

    public EnderecoRequest Endereco { get; init; }

    public ContatoRequest Contato { get; init; }

    public DadosOperacaoRequest DadosOperacao { get; init; }

    public Result<GravacaoPropostaComando> CriarComando()
    {
        var enderecoComando = new EnderecoComando(
            Endereco.Rua,
            Endereco.Numero,
            Endereco.Bairro,
            Endereco.Cidade,
            Endereco.Estado,
            Endereco.CEP
        );

        var contatoComando = new ContatoComando(
            Contato.DDD,
            Contato.Telefone,
            Contato.Email
        );

        var dadosOperacaoComando = new DadosOperacaoComando(
            DadosOperacao.TipoOperacao,
            DadosOperacao.MatriculaRendimento,
            DadosOperacao.Conveniada,
            DadosOperacao.ValorEmprestimo,
            DadosOperacao.Prestacao,
            DadosOperacao.Prazo
        );

        return GravacaoPropostaComando.Criar(CpfCliente, Agente, enderecoComando, contatoComando, dadosOperacaoComando);
    }
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

public record DadosOperacaoRequest(
    string TipoOperacao,
    string MatriculaRendimento,
    string Conveniada,
    decimal ValorEmprestimo,
    decimal Prestacao,
    int Prazo
);
