using CSharpFunctionalExtensions;
using proposta_api.Dominio.Proposta.Comandos;
using proposta_api.Dominio.Proposta.Repositorio;

namespace proposta_api.Dominio.Proposta.Handlers;

public class GravacaoPropostaHandler
{
    private readonly IPropostaRepository _propostaRepositorio;

    public GravacaoPropostaHandler(IPropostaRepository propostaRepositorio)
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
        if (cliente.HasNoValue) return Result.Failure("Cliente não encontrado");

        var dadosOperacao = await _propostaRepositorio.ObterDadosOperacao(comando.IdOperacao);
        if (dadosOperacao.HasNoValue) return Result.Failure("Não foram encontrados dados da operação");

        var agente = await _propostaRepositorio.ObterAgente(dadosOperacao.Value.IdAgente);
        if (agente.HasNoValue) return Result.Failure("Agente não encontrado");

        var conveniada = await _propostaRepositorio.ObterConveniada(dadosOperacao.Value.Conveniada);
        if (conveniada.HasNoValue) return Result.Failure("Conveniada não encontrada");

        return await Proposta
            .Create(cliente.Value, dadosOperacao.Value, agente.Value, conveniada.Value)
            .Bind(_propostaRepositorio.InserirProposta);
    }
}
