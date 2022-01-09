using IntelligentInvestor.Intermediary.Domain;

namespace IntelligentInvestor.Intermediary.Application;

public interface IIntermediaryRequestHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IIntermediaryRequest<TResponse>
{
}
