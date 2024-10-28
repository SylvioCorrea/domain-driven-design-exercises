using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using proposta_api.Aplicacao.Requests;
using proposta_api.Dominio.Comandos;
using proposta_api.Dominio.Handlers;

namespace proposta_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropostaController : ControllerBase
{

    private readonly GravacaoPorpostaHandler _handler;

    public PropostaController(GravacaoPorpostaHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Gravar([FromBody] GravacaoPropostaRequest proposta)
    {
        var comando = proposta.CriarComando();

        var resultado = await _handler.Handle(comando.Value);
        
        return Ok();
    }
}