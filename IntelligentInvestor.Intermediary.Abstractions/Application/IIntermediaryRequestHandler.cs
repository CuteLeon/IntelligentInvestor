using IntelligentInvestor.Intermediary.Abstractions.Domain;

namespace IntelligentInvestor.Intermediary.Abstractions.Application;

public interface IIntermediaryRequestHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IIntermediaryRequest<TResponse>
{
}
