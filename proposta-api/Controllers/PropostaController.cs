using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using proposta_api.Controllers.Requests;

namespace proposta_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropostaController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Gravar([FromBody] GravarPropostaRequest proposta)
    {
        return Ok();
    }
}