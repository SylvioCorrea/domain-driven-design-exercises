namespace proposta_api.Dominio.Proposta.Validacao;

public record ValidacaoPropostaContext (
    Cliente Cliente,
    DadosOperacao DadosOperacao,
    Agente Agente,
    Conveniada Conveniada
);
