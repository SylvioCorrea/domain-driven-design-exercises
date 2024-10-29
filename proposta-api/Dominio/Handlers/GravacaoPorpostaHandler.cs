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

        var cliente = await _propostaRepositorio.ObterCliente(comando.CpfCliente);
        if (cliente.HasValue) return Result.Failure("Cliente não encontrado");

        var dadosOperacao = await _propostaRepositorio.ObterDadosOperacao(comando.IdOperacao);
        if (dadosOperacao.HasNoValue) return Result.Failure("Não foram encontrados dados da operação");

        var conveniada = await _propostaRepositorio.ObterConveniada(dadosOperacao.Value.Conveniada);
        if (conveniada.HasNoValue) return Result.Failure("Conveniada não encontrada");

        var agente = await _propostaRepositorio.ObterAgente(dadosOperacao.Value.IdAgente);
        if (agente.HasNoValue) return Result.Failure("Agente não encontrado");

        var proposta = Proposta.Create(cliente.Value, dadosOperacao.Value, agente.Value, conveniada.Value);
        
        return Result.Success();
    }
}
