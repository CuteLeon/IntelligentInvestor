namespace IntelligentInvestor.Intermediary.Abstractions.Domain;

public interface IIntermediaryRequest<out TResponse> : IRequest<TResponse>
{
}
