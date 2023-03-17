using IntelligentInvestor.Intermediary.Abstractions.Domain;

namespace IntelligentInvestor.Intermediary.Abstractions.Application;

public interface IIntermediaryPublisher
{
    Task SendCommand(IIntermediaryCommand command, CancellationToken cancellationToken = default);

    Task<TResponse> SendRequest<TResponse>(IIntermediaryRequest<TResponse> request, CancellationToken cancellationToken = default);

    Task PublishNotification(IIntermediaryNotification notification, CancellationToken cancellationToken = default);

    Task PublishEvent(IIntermediaryEvent eventArg, CancellationToken cancellationToken = default);
}
