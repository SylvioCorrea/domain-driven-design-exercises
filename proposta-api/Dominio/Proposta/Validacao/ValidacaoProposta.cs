using CSharpFunctionalExtensions;

namespace proposta_api.Dominio.Proposta.Validacao;

public class ValidacaoProposta
{
    public static IEnumerable<IValidacaoProposta> ObterValidacoes() =>
    [
        new ConveniadaPermiteRefinanciamento(),
        new AgenteAtivo(),
        new LimiteValorConveniadaUf(),
        new LimitePrazoPorIdade(),
    ];
}

public class ConveniadaPermiteRefinanciamento : IValidacaoProposta
{
    public Result Validar(ValidacaoPropostaContext ctx) => Result.FailureIf(
        ctx.DadosOperacao.TipoOperacao == TipoOperacao.Refinanciamento
        && !ctx.Conveniada.AceitaRefinanciamento,
        "Conveniada não permite operação de refinanciamento.");
}

public class AgenteAtivo : IValidacaoProposta
{
    public Result Validar(ValidacaoPropostaContext ctx) => Result.FailureIf(
        !ctx.Agente.Ativo,
        "Agente inativo não pode digitar proposta.");
}

public class LimiteValorConveniadaUf : IValidacaoProposta
{
    public Result Validar(ValidacaoPropostaContext ctx)
    {
        var conveniada = ctx.DadosOperacao.Conveniada;
        
        var existeValorMaximo = ctx.Cliente.Endereco.Uf.ValorMaximoConveniada.TryGetValue(conveniada, out decimal valorMaximo);

        return Result.FailureIf(existeValorMaximo && ctx.DadosOperacao.ValorEmprestimo > valorMaximo,
            "Valor da operação ultrapassa o limite permitido para a conveniada no estado.");
    }
}

public class LimitePrazoPorIdade : IValidacaoProposta
{
    private const int LimiteIdade = 80;
    
    public Result Validar(ValidacaoPropostaContext ctx)
    {
        var dataUltimaParcela = DateOnly.FromDateTime(DateTime.Now.AddMonths(ctx.DadosOperacao.Prazo));

        var dataMaxima = ctx.Cliente.DataNascimento.AddYears(LimiteIdade);

        return Result.FailureIf(dataMaxima < dataUltimaParcela,
            $"Prazo de pagamento da operação excede o limite de {LimiteIdade} anos de idade do cliente.");
    }
}

public interface IValidacaoProposta
{
    Result Validar(ValidacaoPropostaContext ctx);
}
