using CSharpFunctionalExtensions;
using proposta_api.Dominio.Comandos;
using proposta_api.Dominio.Repositorio;

namespace proposta_api.Dominio.Handlers;

public class GravacaoPorpostaHandler
{
    private readonly IPropostaRepositorio _propostaRepositorio;

    public GravacaoPorpostaHandler(IPropostaRepositorio propostaRepositorio)
    {
        _propostaRepositorio = propostaRepositorio;
    }

    public async Task<Result> Handle(GravacaoPropostaComando comando)
    {
        if (await _propostaRepositorio.ClienteBloqueado(comando.CpfCliente))
            return Result.Failure("Cliente bloqueado");

        if (await _propostaRepositorio.ClienteTemPropostaAberta(comando.CpfCliente))
            return Result.Failure("Cliente já possui proposta em adamento.");

        if (!await _propostaRepositorio.AgenteAtivo(comando.Agente))
            return Result.Failure("Agente da proposta não está ativo.");

        
        
        return Result.Success();
    }
}
