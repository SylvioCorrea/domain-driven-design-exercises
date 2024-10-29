using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using proposta_api.Aplicacao.Requests;
using proposta_api.Dominio.Proposta.Comandos;
using proposta_api.Dominio.Proposta.Handlers;

namespace proposta_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropostaController : ControllerBase
{

    private readonly GravacaoPropostaHandler _handler;

    public PropostaController(GravacaoPropostaHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Gravar([FromBody] GravacaoPropostaRequest proposta)
    {
        var result = await GravacaoPropostaComando
            .Criar(proposta.CpfCliente, proposta.IdOperacao)
            .Bind(_handler.Handle);

        return result.IsSuccess
            ? Ok()
            : BadRequest(result.Error);
    }
}