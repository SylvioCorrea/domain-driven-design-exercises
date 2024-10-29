using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using proposta_api.Dominio.Comandos;

namespace proposta_api.Aplicacao.Requests;

public record GravacaoPropostaRequest
{
    public string CpfCliente { get; init; }

    public string Agente { get; init; }

    public long idOperacao { get; init; }

    public Result<GravacaoPropostaComando> CriarComando()
    {
        return GravacaoPropostaComando.Criar(CpfCliente, Agente, idOperacao);
    }
}